using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        // 显示/隐藏密码
        private void chkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            char echoChar = chkShowPass.Checked ? '\0' : '●';
            txtPass1.PasswordChar = echoChar;
            txtPass2.PasswordChar = echoChar;
        }

        // 提交注册
        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text.Trim();
            string p1 = txtPass1.Text;
            string p2 = txtPass2.Text;

            // 基础校验
            if (string.IsNullOrEmpty(user)) { MessageBox.Show("请输入用户名"); return; }
            if (string.IsNullOrEmpty(p1)) { MessageBox.Show("请输入密码"); return; }
            if (p1 != p2) { MessageBox.Show("两次密码输入不一致！"); return; }

            // 真实注册API调用
            btnSubmit.Enabled = false;
            btnSubmit.Text = "注册中...";

            try
            {
                string url = "http://localhost:5000/api/Auth/register";
                var data = new { username = user, password = p1 };
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                var content = new System.Net.Http.StringContent(json, System.Text.Encoding.UTF8, "application/json");

                using (var client = new System.Net.Http.HttpClient())
                {
                    var response = await client.PostAsync(url, content);
                    var responseContent = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        var result = Newtonsoft.Json.JsonConvert.DeserializeObject<RegisterResponse>(responseContent);
                        if (result != null && result.Success)
                        {
                            MessageBox.Show($"注册成功！用户ID: {result.UserId}\n请返回登录。", "恭喜");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("注册失败: " + (result?.Message ?? "未知错误"), "错误");
                        }
                    }
                    else
                    {
                        MessageBox.Show($"注册失败，状态码: {response.StatusCode}\n{responseContent}", "错误");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("无法连接服务器: " + ex.Message, "错误");
            }
            finally
            {
                btnSubmit.Enabled = true;
                btnSubmit.Text = "提  交";
            }
        }

        public class RegisterResponse
        {
            public bool Success { get; set; }
            public string Message { get; set; } = string.Empty;
            public int UserId { get; set; }
            public string Username { get; set; } = string.Empty;
        }

        // 取消按钮
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}