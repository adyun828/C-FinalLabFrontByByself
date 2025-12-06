namespace WindowsFormsApp1
{
    partial class register
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Button btnClose;
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.regTitle = new System.Windows.Forms.Label();
            this.reg_panel = new System.Windows.Forms.Panel();
            this.btnlogin = new System.Windows.Forms.Button();
            this.btnregister = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.text_password2 = new System.Windows.Forms.TextBox();
            this.text_password1 = new System.Windows.Forms.TextBox();
            this.text_user = new System.Windows.Forms.TextBox();
            btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.reg_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            btnClose.BackColor = System.Drawing.SystemColors.ControlLight;
            btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnClose.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            btnClose.ForeColor = System.Drawing.SystemColors.HotTrack;
            btnClose.Image = global::WindowsFormsApp1.Properties.Resources.屏幕截图_2025_12_06_154800;
            btnClose.Location = new System.Drawing.Point(773, 0);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(34, 48);
            btnClose.TabIndex = 3;
            btnClose.Text = "×";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox.Image = global::WindowsFormsApp1.Properties.Resources.bg_login;
            this.pictureBox.Location = new System.Drawing.Point(-1, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(808, 539);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            // 
            // regTitle
            // 
            this.regTitle.AutoSize = true;
            this.regTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.regTitle.Font = new System.Drawing.Font("微软雅黑", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.regTitle.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.regTitle.Image = global::WindowsFormsApp1.Properties.Resources.屏幕截图_2025_12_06_154800;
            this.regTitle.Location = new System.Drawing.Point(322, 61);
            this.regTitle.Name = "regTitle";
            this.regTitle.Size = new System.Drawing.Size(144, 75);
            this.regTitle.TabIndex = 1;
            this.regTitle.Text = "注册";
            // 
            // reg_panel
            // 
            this.reg_panel.Controls.Add(this.btnlogin);
            this.reg_panel.Controls.Add(this.btnregister);
            this.reg_panel.Controls.Add(this.checkBox1);
            this.reg_panel.Controls.Add(this.text_password2);
            this.reg_panel.Controls.Add(this.text_password1);
            this.reg_panel.Controls.Add(this.text_user);
            this.reg_panel.Location = new System.Drawing.Point(234, 167);
            this.reg_panel.Name = "reg_panel";
            this.reg_panel.Size = new System.Drawing.Size(311, 332);
            this.reg_panel.TabIndex = 2;
            // 
            // btnlogin
            // 
            this.btnlogin.Location = new System.Drawing.Point(33, 276);
            this.btnlogin.Name = "btnlogin";
            this.btnlogin.Size = new System.Drawing.Size(251, 32);
            this.btnlogin.TabIndex = 5;
            this.btnlogin.Text = "登录";
            this.btnlogin.UseVisualStyleBackColor = true;
            this.btnlogin.Click += new System.EventHandler(this.btnlogin_Click);
            // 
            // btnregister
            // 
            this.btnregister.Location = new System.Drawing.Point(33, 238);
            this.btnregister.Name = "btnregister";
            this.btnregister.Size = new System.Drawing.Size(250, 32);
            this.btnregister.TabIndex = 4;
            this.btnregister.Text = "注册";
            this.btnregister.UseVisualStyleBackColor = true;
            this.btnregister.Click += new System.EventHandler(this.btnregister_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(32, 194);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(106, 22);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "显示密码";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // text_password2
            // 
            this.text_password2.Location = new System.Drawing.Point(32, 151);
            this.text_password2.Name = "text_password2";
            this.text_password2.Size = new System.Drawing.Size(252, 28);
            this.text_password2.TabIndex = 2;
            this.text_password2.Enter += new System.EventHandler(this.text_password2_GotFocus);
            this.text_password2.Leave += new System.EventHandler(this.text_password2_LostFocus);
            // 
            // text_password1
            // 
            this.text_password1.Location = new System.Drawing.Point(32, 92);
            this.text_password1.Name = "text_password1";
            this.text_password1.Size = new System.Drawing.Size(252, 28);
            this.text_password1.TabIndex = 1;
            this.text_password1.Enter += new System.EventHandler(this.text_password1_GotFocus);
            this.text_password1.Leave += new System.EventHandler(this.text_password1_LostFocus);
            // 
            // text_user
            // 
            this.text_user.Location = new System.Drawing.Point(32, 28);
            this.text_user.Name = "text_user";
            this.text_user.Size = new System.Drawing.Size(252, 28);
            this.text_user.TabIndex = 0;
            this.text_user.TextChanged += new System.EventHandler(this.text_user_TextChanged);
            this.text_user.Enter += new System.EventHandler(this.text_user_GotFocus);
            this.text_user.Leave += new System.EventHandler(this.text_user_LostFocus);
            // 
            // register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 530);
            this.Controls.Add(btnClose);
            this.Controls.Add(this.reg_panel);
            this.Controls.Add(this.regTitle);
            this.Controls.Add(this.pictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "register";
            this.Text = "register";
            this.Load += new System.EventHandler(this.register_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.reg_panel.ResumeLayout(false);
            this.reg_panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label regTitle;
        private System.Windows.Forms.Panel reg_panel;
        private System.Windows.Forms.TextBox text_password2;
        private System.Windows.Forms.TextBox text_password1;
        private System.Windows.Forms.TextBox text_user;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btnlogin;
        private System.Windows.Forms.Button btnregister;
    }
}