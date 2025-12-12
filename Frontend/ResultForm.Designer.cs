using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend
{
    partial class ResultForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            bottomPanel = new Panel();
            btnExit = new Button();
            btnContinue = new Button();
            flowLayoutPanelMain = new FlowLayoutPanel();
            bottomPanel.SuspendLayout();
            SuspendLayout();
            // 
            // bottomPanel
            // 
            bottomPanel.BackColor = Color.WhiteSmoke;
            bottomPanel.Controls.Add(btnExit);
            bottomPanel.Controls.Add(btnContinue);
            bottomPanel.Dock = DockStyle.Bottom;
            bottomPanel.Location = new Point(0, 556);
            bottomPanel.Margin = new Padding(4, 5, 4, 5);
            bottomPanel.Name = "bottomPanel";
            bottomPanel.Size = new Size(1116, 128);
            bottomPanel.TabIndex = 0;
            // 
            // btnExit
            // 
            btnExit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExit.BackColor = Color.LightSalmon;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnExit.Location = new Point(935, 35);
            btnExit.Margin = new Padding(4, 5, 4, 5);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(137, 56);
            btnExit.TabIndex = 1;
            btnExit.Text = "退出";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // btnContinue
            // 
            btnContinue.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnContinue.BackColor = Color.LightGreen;
            btnContinue.FlatStyle = FlatStyle.Flat;
            btnContinue.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnContinue.Location = new Point(742, 35);
            btnContinue.Margin = new Padding(4, 5, 4, 5);
            btnContinue.Name = "btnContinue";
            btnContinue.Size = new Size(165, 56);
            btnContinue.TabIndex = 0;
            btnContinue.Text = "继续选择";
            btnContinue.UseVisualStyleBackColor = false;
            btnContinue.Click += btnContinue_Click;
            // 
            // flowLayoutPanelMain
            // 
            flowLayoutPanelMain.AutoScroll = true;
            flowLayoutPanelMain.BackColor = Color.White;
            flowLayoutPanelMain.Dock = DockStyle.Fill;
            flowLayoutPanelMain.Location = new Point(0, 0);
            flowLayoutPanelMain.Margin = new Padding(4, 5, 4, 5);
            flowLayoutPanelMain.Name = "flowLayoutPanelMain";
            flowLayoutPanelMain.Padding = new Padding(13, 16, 13, 16);
            flowLayoutPanelMain.Size = new Size(1116, 556);
            flowLayoutPanelMain.TabIndex = 1;
            // 
            // ResultForm
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1116, 684);
            Controls.Add(flowLayoutPanelMain);
            Controls.Add(bottomPanel);
            Margin = new Padding(4, 5, 4, 5);
            Name = "ResultForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "筛选结果概览";
            bottomPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMain;
    }
}
