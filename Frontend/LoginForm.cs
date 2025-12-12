using System;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using Frontend.Models;

namespace WindowsFormsApp1
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        // 登录按钮点击
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("请输入账号和密码", "提示");
                return;
            }

            // 简单的防重复点击
            btnLogin.Enabled = false;
            btnLogin.Text = "登录中...";

            try
            {
                // API 地址
                string url = "http://localhost:5000/api/Auth/login";
                var data = new { username = username, password = password };
                var json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(30);
                    var response = await client.PostAsync(url, content);
                    var responseContent = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        var result = JsonConvert.DeserializeObject<LoginResponse>(responseContent);

                        if (result != null && result.Success)
                        {
                            // 登录成功 -> 跳转到主界面
                            MainForm mainForm = new MainForm(result.Token ?? "", result.Username ?? "");
                            this.Hide();
                            mainForm.ShowDialog();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("登录失败：" + (result?.Message ?? "未知原因"), "错误");
                        }
                    }
                    else
                    {
                        MessageBox.Show($"登录请求失败，状态码：{response.StatusCode}\n{responseContent}", "错误");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("无法连接服务器：" + ex.Message + "\n\n详细信息：" + ex.ToString(), "错误");
            }
            finally
            {
                // 恢复按钮状态
                btnLogin.Enabled = true;
                btnLogin.Text = "登  录";
            }
        }

        // 注册按钮点击 -> 跳出注册窗口
        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm regForm = new RegisterForm();
            this.Hide(); // 隐藏登录窗
            regForm.ShowDialog(); // 显示注册窗（等待它关闭）
            this.Show(); // 注册窗关闭后，显示回登录窗
        }
    }
}