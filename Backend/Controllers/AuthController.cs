using Backend.DTOs;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
  {
        private readonly IUserService _userService;
        private readonly ILogger<AuthController> _logger;

   public AuthController(IUserService userService, ILogger<AuthController> logger)
        {
   _userService = userService;
       _logger = logger;
   }

        [HttpPost("login")]
        public ActionResult<LoginResponse> Login([FromBody] LoginRequest request)
        {
try
            {
              if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
      {
                 return BadRequest(new LoginResponse
        {
       Success = false,
           Message = "用户名和密码不能为空"
  });
         }

  var user = _userService.ValidateUser(request.Username, request.Password);
          
          if (user == null)
 {
      return Unauthorized(new LoginResponse
           {
          Success = false,
               Message = "用户名或密码错误"
    });
    }

       var token = _userService.GenerateJwtToken(user);

      return Ok(new LoginResponse
    {
     Success = true,
           Message = "登录成功",
         Token = token,
         Username = user.Username
                });
            }
     catch (Exception ex)
         {
                _logger.LogError(ex, "登录过程中发生错误");
       return StatusCode(500, new LoginResponse
       {
        Success = false,
          Message = "服务器错误"
      });
         }
   }

        [HttpPost("register")]
        public ActionResult<RegisterResponse> Register([FromBody] RegisterRequest request)
        {
            try
            {
                // 验证请求参数
                if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
                {
                    return BadRequest(new RegisterResponse
                    {
                        Success = false,
                        Message = "用户名和密码不能为空"
                    });
                }

                // 调用Service层注册用户
                var user = _userService.RegisterUser(request.Username, request.Password);

                return StatusCode(201, new RegisterResponse
                {
                    Success = true,
                    Message = "注册成功",
                    UserId = user.Id,
                    Username = user.Username
                });
            }
            catch (ArgumentException ex)
            {
                // 处理验证错误
                return BadRequest(new RegisterResponse
                {
                    Success = false,
                    Message = ex.Message
                });
            }
            catch (Exception ex) when (ex.Message.Contains("用户名已存在"))
            {
                // 处理用户名已存在的情况
                _logger.LogWarning(ex, "用户名已存在: {Username}", request.Username);
                return BadRequest(new RegisterResponse
                {
                    Success = false,
                    Message = "用户名已存在"
                });
            }
            catch (Exception ex)
            {
                // 处理其他异常
                _logger.LogError(ex, "注册过程中发生错误");
                return StatusCode(500, new RegisterResponse
                {
                    Success = false,
                    Message = "服务器错误"
                });
            }
        }
    }
}
