namespace WindowsFormsApp1
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblPass;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblPass = new System.Windows.Forms.Label();
            this.SuspendLayout();

            this.txtUsername.Location = new System.Drawing.Point(120, 30);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(150, 23);

            this.txtPassword.Location = new System.Drawing.Point(120, 70);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(150, 23);

            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(40, 33);
            this.lblUser.Text = "用户名:";

            this.lblPass.AutoSize = true;
            this.lblPass.Location = new System.Drawing.Point(40, 73);
            this.lblPass.Text = "密码:";

            this.btnLogin.Location = new System.Drawing.Point(120, 110);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(150, 30);
            this.btnLogin.Text = "登录";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

            this.ClientSize = new System.Drawing.Size(350, 180);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Name = "LoginForm";
            this.Text = "登录";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}