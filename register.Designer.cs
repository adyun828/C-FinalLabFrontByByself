namespace WindowsFormsApp1
{
    partial class RegisterForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblIcon;

        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox txtUser;

        private System.Windows.Forms.Label lblPass1;
        private System.Windows.Forms.TextBox txtPass1;

        private System.Windows.Forms.Label lblPass2;
        private System.Windows.Forms.TextBox txtPass2;

        private System.Windows.Forms.CheckBox chkShowPass;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblIcon = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblPass1 = new System.Windows.Forms.Label();
            this.txtPass1 = new System.Windows.Forms.TextBox();
            this.lblPass2 = new System.Windows.Forms.Label();
            this.txtPass2 = new System.Windows.Forms.TextBox();
            this.chkShowPass = new System.Windows.Forms.CheckBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();

            // 
            // 窗体设置 (加长一点，因为内容多)
            // 
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.ClientSize = new System.Drawing.Size(380, 550);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.White;
            this.Text = "新用户注册";

            // 
            // 顶部栏
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.MediumSeaGreen; // 注册用绿色，区分登录
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblIcon);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 100;

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 30);
            this.lblTitle.Text = "创建账号";

            this.lblIcon.AutoSize = true;
            this.lblIcon.Font = new System.Drawing.Font("Segoe UI", 40F);
            this.lblIcon.Location = new System.Drawing.Point(260, 15);
            this.lblIcon.Text = "📝";

            // 
            // 输入控件群
            // 
            // 用户名
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblUser.Location = new System.Drawing.Point(40, 130);
            this.lblUser.Text = "用户名";

            this.txtUser.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtUser.Location = new System.Drawing.Point(44, 155);
            this.txtUser.Size = new System.Drawing.Size(290, 29);

            // 密码
            this.lblPass1.AutoSize = true;
            this.lblPass1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPass1.Location = new System.Drawing.Point(40, 200);
            this.lblPass1.Text = "设置密码";

            this.txtPass1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPass1.Location = new System.Drawing.Point(44, 225);
            this.txtPass1.Size = new System.Drawing.Size(290, 29);
            this.txtPass1.PasswordChar = '●';

            // 确认密码
            this.lblPass2.AutoSize = true;
            this.lblPass2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPass2.Location = new System.Drawing.Point(40, 270);
            this.lblPass2.Text = "确认密码";

            this.txtPass2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPass2.Location = new System.Drawing.Point(44, 295);
            this.txtPass2.Size = new System.Drawing.Size(290, 29);
            this.txtPass2.PasswordChar = '●';

            // 显示密码
            this.chkShowPass.AutoSize = true;
            this.chkShowPass.Location = new System.Drawing.Point(44, 335);
            this.chkShowPass.Text = "显示密码";
            this.chkShowPass.CheckedChanged += new System.EventHandler(this.chkShowPass_CheckedChanged);

            // 
            // 提交按钮 (绿色)
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.FlatAppearance.BorderSize = 0;
            this.btnSubmit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubmit.Location = new System.Drawing.Point(44, 380);
            this.btnSubmit.Size = new System.Drawing.Size(290, 45);
            this.btnSubmit.Text = "立即注册";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);

            // 
            // 取消按钮
            // 
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCancel.ForeColor = System.Drawing.Color.Gray;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Location = new System.Drawing.Point(44, 440);
            this.btnCancel.Size = new System.Drawing.Size(290, 30);
            this.btnCancel.Text = "取消返回";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // 
            // 添加控件
            // 
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.lblPass1);
            this.Controls.Add(this.txtPass1);
            this.Controls.Add(this.lblPass2);
            this.Controls.Add(this.txtPass2);
            this.Controls.Add(this.chkShowPass);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnCancel);

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}