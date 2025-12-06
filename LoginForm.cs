using System;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace WindowsFormsApp1
{
    public partial class LoginForm : Form
    {
        // 建议使用单例 HttpClient (生产环境最佳实践)
        private static readonly HttpClient client = new HttpClient();

        public LoginForm()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // [修改 1] 匹配 API 文档的端口 5000 和路径
            string backendUrl = "http://localhost:5000/api/Auth/login";

            var loginData = new { username = username, password = password };
            var json = JsonConvert.SerializeObject(loginData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                // 发送 POST 请求
                var response = await client.PostAsync(backendUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();

                    // [修改 2] 使用正确的响应模型解析
                    var result = JsonConvert.DeserializeObject<LoginResponse>(responseString);

                    if (result != null && !string.IsNullOrEmpty(result.Token))
                    {
                        MessageBox.Show("登录成功!");

                        // [修改 3] 将 Token 传递给主窗口 (而不是 UserId)
                        MainForm mainForm = new MainForm(result.Token, result.Username);
                        this.Hide();
                        mainForm.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("登录失败: 无法获取 Token");
                    }
                }
                else
                {
                    MessageBox.Show($"登录失败: {response.StatusCode}\n请检查后端是否运行在端口 5000");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("连接错误: " + ex.Message);
            }
        }
    }

    // [修改 4] 对应 API.md 的登录响应结构
    public class LoginResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string Token { get; set; } // 核心字段
        public string Username { get; set; }
    }
}