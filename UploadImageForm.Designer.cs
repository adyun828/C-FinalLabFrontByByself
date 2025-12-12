namespace WindowsFormsApp1
{
    partial class UploadImageForm
    {
        private System.ComponentModel.IContainer components = null;

        // UI 控件
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblIcon;

        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.TextBox txtImagePath;
        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.Button btnSelectImage;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnCancel;

        private System.Windows.Forms.Label lblTitleLabel;
        private System.Windows.Forms.Label lblTypeLabel;
        private System.Windows.Forms.Label lblImageLabel;
        private System.Windows.Forms.Label lblPreviewLabel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblIcon = new System.Windows.Forms.Label();

            this.lblTitleLabel = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            
            this.lblTypeLabel = new System.Windows.Forms.Label();
            this.txtType = new System.Windows.Forms.TextBox();
            
            this.lblImageLabel = new System.Windows.Forms.Label();
            this.txtImagePath = new System.Windows.Forms.TextBox();
            this.btnSelectImage = new System.Windows.Forms.Button();
            
            this.lblPreviewLabel = new System.Windows.Forms.Label();
            this.picPreview = new System.Windows.Forms.PictureBox();
            
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.SuspendLayout();

            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.pnlHeader.Controls.Add(this.lblIcon);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(600, 60);
            this.pnlHeader.TabIndex = 0;

            // 
            // lblIcon
            // 
            this.lblIcon.AutoSize = true;
            this.lblIcon.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblIcon.ForeColor = System.Drawing.Color.White;
            this.lblIcon.Location = new System.Drawing.Point(20, 15);
            this.lblIcon.Name = "lblIcon";
            this.lblIcon.Size = new System.Drawing.Size(32, 31);
            this.lblIcon.TabIndex = 0;
            this.lblIcon.Text = "?";

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft YaHei UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(60, 17);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(135, 30);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "上传图片";

            // 
            // lblTitleLabel
            // 
            this.lblTitleLabel.AutoSize = true;
            this.lblTitleLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
            this.lblTitleLabel.Location = new System.Drawing.Point(30, 85);
            this.lblTitleLabel.Name = "lblTitleLabel";
            this.lblTitleLabel.Size = new System.Drawing.Size(93, 20);
            this.lblTitleLabel.TabIndex = 1;
            this.lblTitleLabel.Text = "图片标题：";

            // 
            // txtTitle
            // 
            this.txtTitle.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
            this.txtTitle.Location = new System.Drawing.Point(130, 82);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(430, 25);
            this.txtTitle.TabIndex = 2;

            // 
            // lblTypeLabel
            // 
            this.lblTypeLabel.AutoSize = true;
            this.lblTypeLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
            this.lblTypeLabel.Location = new System.Drawing.Point(30, 125);
            this.lblTypeLabel.Name = "lblTypeLabel";
            this.lblTypeLabel.Size = new System.Drawing.Size(93, 20);
            this.lblTypeLabel.TabIndex = 3;
            this.lblTypeLabel.Text = "MIME类型：";

            // 
            // txtType
            // 
            this.txtType.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
            this.txtType.Location = new System.Drawing.Point(130, 122);
            this.txtType.Name = "txtType";
            this.txtType.ReadOnly = true;
            this.txtType.Size = new System.Drawing.Size(430, 25);
            this.txtType.TabIndex = 4;
            this.txtType.Text = "请先选择图片";
            this.txtType.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);

            // 
            // lblImageLabel
            // 
            this.lblImageLabel.AutoSize = true;
            this.lblImageLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
            this.lblImageLabel.Location = new System.Drawing.Point(30, 165);
            this.lblImageLabel.Name = "lblImageLabel";
            this.lblImageLabel.Size = new System.Drawing.Size(93, 20);
            this.lblImageLabel.TabIndex = 5;
            this.lblImageLabel.Text = "选择图片：";

            // 
            // txtImagePath
            // 
            this.txtImagePath.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
            this.txtImagePath.Location = new System.Drawing.Point(130, 162);
            this.txtImagePath.Name = "txtImagePath";
            this.txtImagePath.ReadOnly = true;
            this.txtImagePath.Size = new System.Drawing.Size(320, 25);
            this.txtImagePath.TabIndex = 6;

            // 
            // btnSelectImage
            // 
            this.btnSelectImage.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnSelectImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectImage.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSelectImage.ForeColor = System.Drawing.Color.White;
            this.btnSelectImage.Location = new System.Drawing.Point(460, 160);
            this.btnSelectImage.Name = "btnSelectImage";
            this.btnSelectImage.Size = new System.Drawing.Size(100, 30);
            this.btnSelectImage.TabIndex = 7;
            this.btnSelectImage.Text = "浏览...";
            this.btnSelectImage.UseVisualStyleBackColor = false;
            this.btnSelectImage.Click += new System.EventHandler(this.btnSelectImage_Click);

            // 
            // lblPreviewLabel
            // 
            this.lblPreviewLabel.AutoSize = true;
            this.lblPreviewLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
            this.lblPreviewLabel.Location = new System.Drawing.Point(30, 210);
            this.lblPreviewLabel.Name = "lblPreviewLabel";
            this.lblPreviewLabel.Size = new System.Drawing.Size(93, 20);
            this.lblPreviewLabel.TabIndex = 8;
            this.lblPreviewLabel.Text = "图片预览：";

            // 
            // picPreview
            // 
            this.picPreview.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.picPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPreview.Location = new System.Drawing.Point(130, 210);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(430, 300);
            this.picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPreview.TabIndex = 9;
            this.picPreview.TabStop = false;

            // 
            // btnUpload
            // 
            this.btnUpload.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpload.Font = new System.Drawing.Font("Microsoft YaHei UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnUpload.ForeColor = System.Drawing.Color.White;
            this.btnUpload.Location = new System.Drawing.Point(340, 530);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(120, 40);
            this.btnUpload.TabIndex = 10;
            this.btnUpload.Text = "上  传";
            this.btnUpload.UseVisualStyleBackColor = false;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);

            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(149, 165, 166);
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft YaHei UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(470, 530);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 40);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "取  消";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // 
            // UploadImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(600, 590);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.picPreview);
            this.Controls.Add(this.lblPreviewLabel);
            this.Controls.Add(this.btnSelectImage);
            this.Controls.Add(this.txtImagePath);
            this.Controls.Add(this.lblImageLabel);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.lblTypeLabel);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblTitleLabel);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "UploadImageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "上传图片";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
