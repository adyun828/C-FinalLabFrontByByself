using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using Frontend.Models;

namespace WindowsFormsApp1
{
    public partial class MainForm : Form
    {
        private string _token;
        private string _username;
        private List<ImageInfo>? _images;
        private int _currentIndex = 0;

        private const string BaseUrl = "http://localhost:5000/api";
        private static readonly HttpClient client = new HttpClient();

        public MainForm(string token, string username)
        {
            InitializeComponent();
            _token = token;
            _username = username;

            // 设置 Token
            if (client.DefaultRequestHeaders.Authorization == null)
            {
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", _token);
            }

            // --- 1. 更新右上角用户信息 ---
            lblUserInfo.Text = $"👤 操作员: {_username}";

            // ---------------------------

            this.Load += (s, e) => LoadImages();
        }

        private async void LoadImages()
        {
            // 获取图片逻辑 (保持不变)
            string url = $"{BaseUrl}/Images?count=5";
            try
            {
                lblImageId.Text = "正在从云端获取任务...";
                var response = await client.GetStringAsync(url);
                _images = JsonConvert.DeserializeObject<List<ImageInfo>>(response) ?? new List<ImageInfo>();

                if (_images != null && _images.Count > 0)
                {
                    _currentIndex = 0;
                    ShowImage(_currentIndex);
                }
                else
                {
                    MessageBox.Show("当前没有待处理的图片任务。");
                    lblImageId.Text = "暂无任务";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"连接服务器失败: {ex.Message}");
                lblImageId.Text = "服务器连接断开";
            }
        }

        private void ShowImage(int index)
        {
            if (_images != null && index >= 0 && index < _images.Count)
            {
                var img = _images[index];
                lblImageId.Text = $"ID: {img.Id} | 标题: {img.Title}";

                try
                {
                    if (!string.IsNullOrEmpty(img.IMageBase64))
                    {
                        byte[] imageBytes = Convert.FromBase64String(img.IMageBase64);
                        using (var ms = new MemoryStream(imageBytes))
                        {
                            picMain.Image = Image.FromStream(ms);
                        }
                    }
                }
                catch
                {
                    picMain.Image = null;
                }
            }
        }

        private async void SubmitDecision(string apiOption)
        {
            if (_images == null || _images.Count == 0) return;

            var currentImage = _images[_currentIndex];
            string url = $"{BaseUrl}/Selections";

            var payload = new
            {
                imageId = currentImage.Id,
                selectedOption = apiOption
            };

            var json = JsonConvert.SerializeObject(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await client.PostAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    _currentIndex++;
                    if (_currentIndex < _images.Count)
                    {
                        ShowImage(_currentIndex);
                    }
                    else
                    {
                        var result = MessageBox.Show("本批次任务已完成，是否加载新任务？", "完成", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            LoadImages();
                        }
                        else
                        {
                            lblImageId.Text = "任务完成";
                            picMain.Image = null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("提交失败: " + ex.Message);
            }
        }

        // 按钮事件
        private void btnKeep_Click(object sender, EventArgs e) => SubmitDecision("优");
        private void btnDiscard_Click(object sender, EventArgs e) => SubmitDecision("差");
        private void btnEnhance_Click(object sender, EventArgs e)
        {
            if (picMain.Image == null || _images == null || _currentIndex >= _images.Count) return;
            MessageBox.Show($"正在对图片 [ID:{_images[_currentIndex].Id}] 进行AI增强处理...", "系统处理中");
        }

        // 上传图片按钮事件
        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            UploadImageForm uploadForm = new UploadImageForm(_token);
            DialogResult result = uploadForm.ShowDialog();
            
            // 如果上传成功，重新加载图片列表
            if (result == DialogResult.OK)
            {
                LoadImages();
            }
        }
    }
}