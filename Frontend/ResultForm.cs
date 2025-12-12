using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend
{
    public partial class ResultForm : Form
    {
        // 构造函数：接收主界面传来的图片列表
        public ResultForm(List<Image> selectedImages)
        {
            InitializeComponent(); // 调用 Designer.cs 里定义的界面初始化
            LoadImages(selectedImages);
        }

        // 加载图片到流式布局面板
        private void LoadImages(List<Image> images)
        {
            // 清空旧控件
            if (flowLayoutPanelMain.Controls.Count > 0)
                flowLayoutPanelMain.Controls.Clear();

            if (images == null || images.Count == 0)
            {
                Label lbl = new Label
                {
                    Text = "本轮没有选中任何图片",
                    AutoSize = true,
                    Font = new Font("微软雅黑", 12),
                    Padding = new Padding(20)
                };
                flowLayoutPanelMain.Controls.Add(lbl);
                return;
            }

            foreach (var img in images)
            {
                PictureBox pb = new PictureBox();
                pb.Image = img;
                pb.SizeMode = PictureBoxSizeMode.Zoom; // 保持比例缩放
                pb.Size = new Size(150, 150);          // 统一缩略图大小
                pb.Margin = new Padding(10);           // 图片间距
                pb.BorderStyle = BorderStyle.FixedSingle; // 加边框
                pb.BackColor = Color.White;

                flowLayoutPanelMain.Controls.Add(pb);
            }
        }

        // “继续选择”按钮逻辑
        private void btnContinue_Click(object sender, EventArgs e)
        {
            // 返回 OK，告诉主界面用户想继续
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // “退出”按钮逻辑
        private void btnExit_Click(object sender, EventArgs e)
        {
            // 弹出提示
            MessageBox.Show("筛选流程已终止，将返回主界面待机。", "结束提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // 返回 Cancel，告诉主界面用户想退出
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
