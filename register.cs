using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class register : Form
    {
        // 输入框提示文字
        private const string UserTip = "请输入用户名";
        private const string PwdTip1 = "请输入密码";
        private const string PwdTip2 = "请再次输入密码";

        // 窗体拖拽变量
        private Point mouseDownPoint;

        public register()
        {
            InitializeComponent();
            // 初始化输入框提示文字
            InitInputTips();
        }

        #region 1. 初始化输入框提示文字
        private void InitInputTips()
        {
            // 用户名输入框
            if (string.IsNullOrEmpty(text_user.Text))
            {
                text_user.Text = UserTip;
                text_user.ForeColor = Color.Gray;
            }
            // 密码输入框
            if (string.IsNullOrEmpty(text_password1.Text))
            {
                text_password1.Text = PwdTip1;
                text_password1.PasswordChar = '\0'; // 初始不隐藏
                text_password1.ForeColor = Color.Gray;
            }
            // 确认密码输入框（注册页特有）
            if (string.IsNullOrEmpty(text_password2.Text))
            {
                text_password2.Text = PwdTip2;
                text_password2.PasswordChar = '\0';
                text_password2.ForeColor = Color.Gray;
            }
        }
        #endregion

        #region 2. 输入框焦点事件
        // 用户名输入框 - 获焦
        private void text_user_GotFocus(object sender, EventArgs e)
        {
            if (text_user.Text == UserTip)
            {
                text_user.Text = "";
                text_user.ForeColor = Color.Black;
            }
        }
        // 用户名输入框 - 失焦
        private void text_user_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(text_user.Text))
            {
                text_user.Text = UserTip;
                text_user.ForeColor = Color.Gray;
            }
        }

        // 密码输入框 - 获焦
        private void text_password1_GotFocus(object sender, EventArgs e)
        {
            if (text_password1.Text == PwdTip1)
            {
                text_password1.Text = "";
                text_password1.ForeColor = Color.Black;
                text_password1.PasswordChar = '*'; // 获焦后隐藏
            }
        }
        // 密码输入框 - 失焦
        private void text_password1_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(text_password1.Text))
            {
                text_password1.Text = PwdTip1;
                text_password1.ForeColor = Color.Gray;
                text_password1.PasswordChar = '\0'; // 失焦后显示提示文字
            }
        }

        // 确认密码输入框 - 获焦
        private void text_password2_GotFocus(object sender, EventArgs e)
        {
            if (text_password2.Text == PwdTip2)
            {
                text_password2.Text = "";
                text_password2.ForeColor = Color.Black;
                text_password2.PasswordChar = '*';
            }
        }
        // 确认密码输入框 - 失焦
        private void text_password2_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(text_password2.Text))
            {
                text_password2.Text = PwdTip2;
                text_password2.ForeColor = Color.Gray;
                text_password2.PasswordChar = '\0';
            }
        }
        #endregion

        #region 3. 显示密码复选框事件
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // 密码框1
            if (text_password1.Text != PwdTip1)
            {
                text_password1.PasswordChar = checkBox1.Checked ? '\0' : '*';
            }
            // 密码框2
            if (text_password2.Text != PwdTip2)
            {
                text_password2.PasswordChar = checkBox1.Checked ? '\0' : '*';
            }
        }
        #endregion

        #region 4. 按钮点击事件
        // 注册按钮 - 点击
        private void btnregister_Click(object sender, EventArgs e)
        {
            string userName = text_user.Text.Trim();
            string pwd1 = text_password1.Text.Trim();
            string pwd2 = text_password2.Text.Trim();

            // 基础验证
            if (userName == UserTip || string.IsNullOrEmpty(userName))
            {
                MessageBox.Show("请输入用户名！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                text_user.Focus();
                return;
            }
            if (pwd1 == PwdTip1 || string.IsNullOrEmpty(pwd1))
            {
                MessageBox.Show("请输入密码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                text_password1.Focus();
                return;
            }
            if (pwd2 == PwdTip2 || string.IsNullOrEmpty(pwd2))
            {
                MessageBox.Show("请再次输入密码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                text_password2.Focus();
                return;
            }
            if (pwd1 != pwd2)
            {
                MessageBox.Show("两次输入的密码不一致！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                text_password2.Focus();
                return;
            }

            // 注册成功（后续可对接API）
            MessageBox.Show("注册成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close(); // 关闭注册页返回登录页
        }

        // 登录按钮 - 点击（返回登录页）
        private void btnlogin_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // 关闭按钮 - 点击
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要关闭吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.Close();
            }
        }
        #endregion

        #region 5. 窗体拖拽事件
        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseDownPoint = new Point(e.X, e.Y);
            }
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(
                    this.Location.X + e.X - mouseDownPoint.X,
                    this.Location.Y + e.Y - mouseDownPoint.Y
                );
            }
        }
        #endregion

        private void register_Load(object sender, EventArgs e)
        {
            // 窗体加载事件（暂无逻辑，保留）
        }

        private void text_user_TextChanged(object sender, EventArgs e)
        {

        }
    }
}