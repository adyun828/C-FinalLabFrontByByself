namespace WindowsFormsApp1
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox picMain;
        private System.Windows.Forms.Button btnKeep;
        private System.Windows.Forms.Button btnDiscard;
        private System.Windows.Forms.Button btnEnhance; // 新增
        private System.Windows.Forms.Label lblImageId;

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
            this.btnEnhance = new System.Windows.Forms.Button(); // 新增
            this.lblImageId = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picMain)).BeginInit();
            this.SuspendLayout();

            // picMain
            this.picMain.Location = new System.Drawing.Point(20, 50);
            this.picMain.Name = "picMain";
            this.picMain.Size = new System.Drawing.Size(400, 300);
            this.picMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // lblImageId
            this.lblImageId.AutoSize = true;
            this.lblImageId.Location = new System.Drawing.Point(20, 20);
            this.lblImageId.Name = "lblImageId";
            this.lblImageId.Size = new System.Drawing.Size(60, 17);
            this.lblImageId.Text = "加载中...";

            // btnKeep
            this.btnKeep.Location = new System.Drawing.Point(40, 370);
            this.btnKeep.Name = "btnKeep";
            this.btnKeep.Size = new System.Drawing.Size(100, 40);
            this.btnKeep.Text = "保留 (Keep)";
            this.btnKeep.UseVisualStyleBackColor = true;
            this.btnKeep.Click += new System.EventHandler(this.btnKeep_Click);

            // btnDiscard
            this.btnDiscard.Location = new System.Drawing.Point(160, 370);
            this.btnDiscard.Name = "btnDiscard";
            this.btnDiscard.Size = new System.Drawing.Size(100, 40);
            this.btnDiscard.Text = "丢弃 (Discard)";
            this.btnDiscard.UseVisualStyleBackColor = true;
            this.btnDiscard.Click += new System.EventHandler(this.btnDiscard_Click);

            // btnEnhance (新增: 满足实验图像增强要求)
            this.btnEnhance.Location = new System.Drawing.Point(280, 370);
            this.btnEnhance.Name = "btnEnhance";
            this.btnEnhance.Size = new System.Drawing.Size(120, 40);
            this.btnEnhance.Text = "增强 (Enhance)";
            this.btnEnhance.UseVisualStyleBackColor = true;
            this.btnEnhance.Click += new System.EventHandler(this.btnEnhance_Click);

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 450);
            this.Controls.Add(this.btnEnhance); // 新增
            this.Controls.Add(this.lblImageId);
            this.Controls.Add(this.btnDiscard);
            this.Controls.Add(this.btnKeep);
            this.Controls.Add(this.picMain);
            this.Name = "MainForm";
            this.Text = "图像筛选器";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.picMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}