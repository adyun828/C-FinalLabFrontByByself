namespace WindowsFormsApp1
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox picMain;
        private System.Windows.Forms.Button btnKeep;
        private System.Windows.Forms.Button btnDiscard;
        private System.Windows.Forms.Button btnEnhance;
        private System.Windows.Forms.Label lblImageId;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label lblAppTitle;
        private System.Windows.Forms.Panel contentPanel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.picMain = new System.Windows.Forms.PictureBox();
            this.btnKeep = new System.Windows.Forms.Button();
            this.btnDiscard = new System.Windows.Forms.Button();
            this.btnEnhance = new System.Windows.Forms.Button();
            this.lblImageId = new System.Windows.Forms.Label();
            this.topPanel = new System.Windows.Forms.Panel();
            this.lblAppTitle = new System.Windows.Forms.Label();
            this.contentPanel = new System.Windows.Forms.Panel();

            ((System.ComponentModel.ISupportInitialize)(this.picMain)).BeginInit();
            this.topPanel.SuspendLayout();
            this.contentPanel.SuspendLayout();
            this.SuspendLayout();

            // 
            // 窗体基础设置
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245))))); // 浅灰背景
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Name = "MainForm";
            this.Text = "图像筛选工作站";

            // 
            // topPanel (顶部深色导航栏)
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.topPanel.Controls.Add(this.lblAppTitle);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Height = 60;

            // 
            // lblAppTitle (顶部标题)
            // 
            this.lblAppTitle.AutoSize = true;
            this.lblAppTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblAppTitle.ForeColor = System.Drawing.Color.White;
            this.lblAppTitle.Location = new System.Drawing.Point(20, 15);
            this.lblAppTitle.Text = "Image Review Workstation";

            // 
            // contentPanel (白色卡片区域，用于放置图片)
            // 
            this.contentPanel.BackColor = System.Drawing.Color.White;
            this.contentPanel.Controls.Add(this.picMain);
            this.contentPanel.Location = new System.Drawing.Point(25, 80);
            this.contentPanel.Size = new System.Drawing.Size(750, 420);
            this.contentPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));

            // 
            // picMain (图片显示)
            // 
            this.picMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom; // 保持比例完整显示
            this.picMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));

            // 
            // lblImageId (放在图片上方显示信息)
            // 
            this.lblImageId.AutoSize = true;
            this.lblImageId.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblImageId.ForeColor = System.Drawing.Color.DimGray;
            this.lblImageId.Location = new System.Drawing.Point(25, 510);
            this.lblImageId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblImageId.Text = "等待加载...";

            // 
            // 按钮通用样式设置方法 (为了代码整洁，直接在属性里写)
            // 
            int btnHeight = 45;
            int btnY = 540;

            // 
            // btnKeep (保留 - 绿色)
            // 
            this.btnKeep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113))))); // 翡翠绿
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

            // 
            // btnDiscard (丢弃 - 红色)
            // 
            this.btnDiscard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60))))); // 鲜红
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
            // btnEnhance (增强 - 蓝色)
            // 
            this.btnEnhance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219))))); // 亮蓝
            this.btnEnhance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnhance.FlatAppearance.BorderSize = 0;
            this.btnEnhance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnEnhance.ForeColor = System.Drawing.Color.White;
            this.btnEnhance.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEnhance.Location = new System.Drawing.Point(625, btnY);
            this.btnEnhance.Size = new System.Drawing.Size(150, btnHeight);
            this.btnEnhance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right))); // 靠右对齐
            this.btnEnhance.Text = "✨ 增强 (Enhance)";
            this.btnEnhance.Click += new System.EventHandler(this.btnEnhance_Click);

            // 
            // 添加控件
            // 
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.lblImageId);
            this.Controls.Add(this.btnKeep);
            this.Controls.Add(this.btnDiscard);
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