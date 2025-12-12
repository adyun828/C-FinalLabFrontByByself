namespace WindowsFormsApp1
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        // 控件声明
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label lblAppTitle;
        private System.Windows.Forms.Label lblUserInfo; // 新增：用户信息标签
        private System.Windows.Forms.Button btnUploadImage; // 新增：上传图片按钮
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.PictureBox picMain;
        private System.Windows.Forms.Label lblImageId;
        private System.Windows.Forms.Button btnKeep;
        private System.Windows.Forms.Button btnDiscard;
        private System.Windows.Forms.Button btnEnhance;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.topPanel = new System.Windows.Forms.Panel();
            this.lblAppTitle = new System.Windows.Forms.Label();
            this.lblUserInfo = new System.Windows.Forms.Label(); // 实例化
            this.btnUploadImage = new System.Windows.Forms.Button(); // 实例化上传按钮
            this.contentPanel = new System.Windows.Forms.Panel();
            this.picMain = new System.Windows.Forms.PictureBox();
            this.lblImageId = new System.Windows.Forms.Label();
            this.btnKeep = new System.Windows.Forms.Button();
            this.btnDiscard = new System.Windows.Forms.Button();
            this.btnEnhance = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.picMain)).BeginInit();
            this.topPanel.SuspendLayout();
            this.contentPanel.SuspendLayout();
            this.SuspendLayout();

            // 
            // 窗体基础设置
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(900, 650); // 稍微调大一点
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Name = "MainForm";
            this.Text = "图像筛选工作站";

            // 
            // topPanel (顶部深色栏)
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.topPanel.Controls.Add(this.lblUserInfo); // 添加用户信息标签
            this.topPanel.Controls.Add(this.lblAppTitle);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Height = 60;

            // 
            // lblAppTitle (左侧标题)
            // 
            this.lblAppTitle.AutoSize = true;
            this.lblAppTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblAppTitle.ForeColor = System.Drawing.Color.White;
            this.lblAppTitle.Location = new System.Drawing.Point(20, 15);
            this.lblAppTitle.Text = "Image Review Workstation";

            // 
            // lblUserInfo (右上角用户信息 - 新增核心部分)
            // 
            this.lblUserInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right))); // 关键：锚定右上方
            this.lblUserInfo.AutoSize = true;
            this.lblUserInfo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblUserInfo.ForeColor = System.Drawing.Color.Gainsboro; // 浅灰色，比标题稍微暗一点，有层次感
            this.lblUserInfo.Location = new System.Drawing.Point(700, 22);
            this.lblUserInfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblUserInfo.Size = new System.Drawing.Size(200, 20);
            this.lblUserInfo.Text = "加载中...";
            this.lblUserInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // 
            // contentPanel (白色卡片)
            // 
            this.contentPanel.BackColor = System.Drawing.Color.White;
            this.contentPanel.Controls.Add(this.picMain);
            this.contentPanel.Location = new System.Drawing.Point(25, 80);
            this.contentPanel.Size = new System.Drawing.Size(850, 460);
            this.contentPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));

            // 
            // picMain (图片)
            // 
            this.picMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));

            // 
            // lblImageId (底部信息)
            // 
            this.lblImageId.AutoSize = true;
            this.lblImageId.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblImageId.ForeColor = System.Drawing.Color.DimGray;
            this.lblImageId.Location = new System.Drawing.Point(25, 555);
            this.lblImageId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblImageId.Text = "等待加载...";

            // 
            // 按钮布局 (使用相对坐标)
            // 
            int btnY = 585;
            int btnHeight = 45;

            // btnKeep
            this.btnKeep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnKeep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKeep.FlatAppearance.BorderSize = 0;
            this.btnKeep.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnKeep.ForeColor = System.Drawing.Color.White;
            this.btnKeep.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKeep.Location = new System.Drawing.Point(25, btnY);
            this.btnKeep.Size = new System.Drawing.Size(150, btnHeight);
            this.btnKeep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnKeep.Text = "✓ 保留 (Keep)";
            this.btnKeep.Click += new System.EventHandler(this.btnKeep_Click);

            // btnDiscard
            this.btnDiscard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnDiscard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDiscard.FlatAppearance.BorderSize = 0;
            this.btnDiscard.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnDiscard.ForeColor = System.Drawing.Color.White;
            this.btnDiscard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDiscard.Location = new System.Drawing.Point(190, btnY);
            this.btnDiscard.Size = new System.Drawing.Size(150, btnHeight);
            this.btnDiscard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDiscard.Text = "✕ 丢弃 (Discard)";
            this.btnDiscard.Click += new System.EventHandler(this.btnDiscard_Click);

            // 
            // btnUploadImage (上传图片按钮 - 调整到底部，增强按钮左侧)
            // 
            this.btnUploadImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUploadImage.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnUploadImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUploadImage.FlatAppearance.BorderSize = 0;
            this.btnUploadImage.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnUploadImage.ForeColor = System.Drawing.Color.White;
            this.btnUploadImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUploadImage.Location = new System.Drawing.Point(560, btnY); // 放在增强按钮左侧
            this.btnUploadImage.Name = "btnUploadImage";
            this.btnUploadImage.Size = new System.Drawing.Size(150, btnHeight);
            this.btnUploadImage.TabIndex = 100;
            this.btnUploadImage.Text = "📤 上传图片";
            this.btnUploadImage.UseVisualStyleBackColor = false;
            this.btnUploadImage.Click += new System.EventHandler(this.btnUploadImage_Click);

            // btnEnhance
            this.btnEnhance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnEnhance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnhance.FlatAppearance.BorderSize = 0;
            this.btnEnhance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnEnhance.ForeColor = System.Drawing.Color.White;
            this.btnEnhance.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEnhance.Location = new System.Drawing.Point(725, btnY); // 靠右
            this.btnEnhance.Size = new System.Drawing.Size(150, btnHeight);
            this.btnEnhance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnhance.Text = "✨ 增强 (Enhance)";
            this.btnEnhance.Click += new System.EventHandler(this.btnEnhance_Click);

            // 添加控件
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.lblImageId);
            this.Controls.Add(this.btnKeep);
            this.Controls.Add(this.btnDiscard);
            this.Controls.Add(this.btnUploadImage); // 添加到窗体底部
            this.Controls.Add(this.btnEnhance);

            ((System.ComponentModel.ISupportInitialize)(this.picMain)).EndInit();
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.contentPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}