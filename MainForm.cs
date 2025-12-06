using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace WindowsFormsApp1
{
    public partial class MainForm : Form
    {
        private string _token;
        private string _username;
        private List<ImageInfo> _images; // 缓存下载的图片列表
        private int _currentIndex = 0;

        // 基础 API 地址
        private const string BaseUrl = "http://localhost:5000/api";
        private static readonly HttpClient client = new HttpClient();

        // 构造函数接收 Token
        public MainForm(string token, string username)
        {
            InitializeComponent();
            _token = token;
            _username = username;

            // [修改 1] 配置全局认证头 (JWT)
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", _token);

            this.Text = $"图像筛选器 - 当前用户: {_username}";

            // 启动时加载图片
            LoadImages();
        }

        // 获取图片列表
        private async void LoadImages()
        {
            // [修改 2] 调用获取随机图片接口
            string url = $"{BaseUrl}/Images?count=5"; // 一次取5张
            try
            {
                lblImageId.Text = "正在从服务器加载数据...";
                var response = await client.GetStringAsync(url);

                // 反序列化为对象列表
                _images = JsonConvert.DeserializeObject<List<ImageInfo>>(response);

                if (_images != null && _images.Count > 0)
                {
                    _currentIndex = 0;
                    ShowImage(_currentIndex);
                }
                else
                {
                    MessageBox.Show("没有获取到图片数据。");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("无法加载图片 (请确保后端已启动): " + ex.Message);
            }
        }

        // 显示单张图片
        private void ShowImage(int index)
        {
            if (_images != null && index >= 0 && index < _images.Count)
            {
                var img = _images[index];
                lblImageId.Text = $"ID: {img.Id} | 标题: {img.Title}";

                // [修改 3] Base64 字符串转图片
                try
                {
                    if (!string.IsNullOrEmpty(img.IMageBase64))
                    {
                        byte[] imageBytes = Convert.FromBase64String(img.IMageBase64);
                        using (var ms = new MemoryStream(imageBytes))
                        {
                            // 注意: 需要复制流或保持流打开，这里简单处理
                            picMain.Image = Image.FromStream(ms);
                        }
                    }
                }
                catch
                {
                    lblImageId.Text += " (图片数据损坏)";
                    picMain.Image = null;
                }
            }
        }

        // 提交评价通用方法
        private async void SubmitDecision(string apiOption)
        {
            if (_images == null || _images.Count == 0 || _currentIndex >= _images.Count) return;

            var currentImage = _images[_currentIndex];
            string url = $"{BaseUrl}/Selections";

            // [修改 4] 构造符合 API 要求的 Payload
            var payload = new
            {
                imageId = currentImage.Id,
                selectedOption = apiOption // 必须是 "优", "良", "差"
            };

            var json = JsonConvert.SerializeObject(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await client.PostAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    // 评价成功，自动切换下一张
                    _currentIndex++;
                    if (_currentIndex < _images.Count)
                    {
                        ShowImage(_currentIndex);
                    }
                    else
                    {
                        var result = MessageBox.Show("本批次图片已完成，是否加载新图片？", "完成", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            LoadImages();
                        }
                        else
                        {
                            lblImageId.Text = "已完成所有任务";
                            picMain.Image = null;
                        }
                    }
                }
                else
                {
                    MessageBox.Show($"提交失败: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误: " + ex.Message);
            }
        }

        // 按钮事件映射
        // "保留" -> 对应 API 的 "优"
        private void btnKeep_Click(object sender, EventArgs e) => SubmitDecision("优");

        // "丢弃" -> 对应 API 的 "差"
        private void btnDiscard_Click(object sender, EventArgs e) => SubmitDecision("差");

        // 图像增强模拟 (保留您原有的演示逻辑)
        private void btnEnhance_Click(object sender, EventArgs e)
        {
            if (picMain.Image == null) return;
            MessageBox.Show("正在应用光照折射校正算法...\n\n图像增强已完成。", "图像处理系统");
            // 实际开发中，这里可以调用 PUT /Images 接口上传处理后的 Base64
        }
    }

    // [修改 5] 对应 API.md 的 Image 数据模型
    public class ImageInfo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        // 注意：API文档中这里是大写的 IMageBase64，Newtonsoft.Json 默认不区分大小写，但最好保持一致
        public string IMageBase64 { get; set; }
        public string Type { get; set; }
    }
}