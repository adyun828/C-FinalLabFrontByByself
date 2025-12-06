using System;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace WindowsFormsApp1
{
    public partial class LoginForm : Form
    {
        // 使用静态 HttpClient 复用连接
        private static readonly HttpClient client = new HttpClient();

        public LoginForm()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // [API] 登录接口地址 (根据 API.md)
            string backendUrl = "http://localhost:5000/api/Auth/login";

            var loginData = new { username = username, password = password };
            var json = JsonConvert.SerializeObject(loginData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                btnLogin.Enabled = false; // 防止重复点击
                var response = await client.PostAsync(backendUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();

                    // 反序列化响应
                    var result = JsonConvert.DeserializeObject<LoginResponse>(responseString);

                    if (result != null && result.Success && !string.IsNullOrEmpty(result.Token))
                    {
                        MessageBox.Show($"登录成功! 欢迎 {result.Username}");

                        // [关键] 传递 Token 到主窗口
                        MainForm mainForm = new MainForm(result.Token, result.Username);
                        this.Hide();
                        mainForm.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("登录失败: " + (result?.Message ?? "未知错误"));
                    }
                }
                else
                {
                    MessageBox.Show($"请求失败: {response.StatusCode} (请确认后端已启动)");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("连接错误: " + ex.Message);
            }
            finally
            {
                btnLogin.Enabled = true;
            }
        }
    }

    // [Model] 对应 API 登录响应结构
    public class LoginResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
        public string Username { get; set; }
    }
}