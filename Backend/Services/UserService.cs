using Backend.Database;
using Backend.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Backend.Services
{
    public class UserService : IUserService
    {
        private readonly DataRepository _repository;
        private readonly IConfiguration _configuration;

        public UserService(DataRepository repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }

        public User? ValidateUser(string username, string password)
        {
            var user = _repository.GetUserByUsername(username);
            if (user == null)
                return null;

            // 计算输入密码的哈希值
            string passwordHash = ComputeSha256Hash(password);

            // 比对哈希值
            if (user.PasswordHash == passwordHash)
            {
                return user;
            }

            return null;
        }

        public string GenerateJwtToken(User user)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var secretKey = jwtSettings["SecretKey"] ?? throw new Exception("JWT密钥未配置");
            var issuer = jwtSettings["Issuer"];
            var audience = jwtSettings["Audience"];
            var expirationMinutes = int.Parse(jwtSettings["ExpirationMinutes"] ?? "60");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.IsAdmin ? "Admin" : "User")
            };

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(expirationMinutes),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        // SHA256 哈希工具方法
        private string ComputeSha256Hash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                return Convert.ToHexString(bytes);
            }
        }

        public User RegisterUser(string username, string password)
        {
            // 验证用户名长度
            if (string.IsNullOrWhiteSpace(username) || username.Length < 3 || username.Length > 50)
            {
                throw new ArgumentException("用户名长度必须在3到50个字符之间");
            }

            // 验证用户名格式：字母、数字、下划线
            if (!System.Text.RegularExpressions.Regex.IsMatch(username, @"^[a-zA-Z0-9_]+$"))
            {
                throw new ArgumentException("用户名只能包含字母、数字和下划线");
            }

            // 验证密码长度
            if (string.IsNullOrWhiteSpace(password) || password.Length < 8)
            {
                throw new ArgumentException("密码长度至少为8个字符");
            }

            // 验证密码复杂度：必须包含字母和数字
            bool hasLetter = System.Text.RegularExpressions.Regex.IsMatch(password, @"[a-zA-Z]");
            bool hasDigit = System.Text.RegularExpressions.Regex.IsMatch(password, @"\d");
            if (!hasLetter || !hasDigit)
            {
                throw new ArgumentException("密码必须包含字母和数字");
            }

            // 计算密码哈希
            string passwordHash = ComputeSha256Hash(password);

            // 调用Repository添加用户（如果用户名已存在，Repository会抛出异常）
            var user = _repository.AddUser(username, passwordHash, isAdmin: false);

            return user;
        }
    }
}
