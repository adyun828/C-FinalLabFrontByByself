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
        private List<ImageInfo> _images; // 缓存当前的图片列表
        private int _currentIndex = 0;

        // [API] 基础地址
        private const string BaseUrl = "http://localhost:5000/api";
        private static readonly HttpClient client = new HttpClient();

        public MainForm(string token, string username)
        {
            InitializeComponent();
            _token = token;
            _username = username;

            // [关键] 设置全局 JWT 认证头
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", _token);

            this.Text = $"图像筛选系统 - 操作员: {_username}";

            // 窗体加载后自动获取图片
            this.Load += (s, e) => LoadImages();
        }

        // [API] 获取图片列表
        private async void LoadImages()
        {
            string url = $"{BaseUrl}/Images?count=5"; // 一次请求5张
            try
            {
                lblImageId.Text = "正在获取数据...";
                var response = await client.GetStringAsync(url);

                // 反序列化
                _images = JsonConvert.DeserializeObject<List<ImageInfo>>(response);

                if (_images != null && _images.Count > 0)
                {
                    _currentIndex = 0;
                    ShowImage(_currentIndex);
                }
                else
                {
                    MessageBox.Show("服务端没有返回任何图片。");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"无法连接服务器: {ex.Message}\n请检查 http://localhost:5000 是否运行。");
            }
        }

        // 显示图片逻辑
        private void ShowImage(int index)
        {
            if (_images != null && index >= 0 && index < _images.Count)
            {
                var img = _images[index];
                lblImageId.Text = $"ID: {img.Id} | 标题: {img.Title}";

                try
                {
                    // [关键] Base64 转 Image
                    if (!string.IsNullOrEmpty(img.IMageBase64))
                    {
                        byte[] imageBytes = Convert.FromBase64String(img.IMageBase64);
                        using (var ms = new MemoryStream(imageBytes))
                        {
                            // 必须复制流，否则可能会在Dispose后无法重绘
                            picMain.Image = Image.FromStream(ms);
                        }
                    }
                }
                catch
                {
                    lblImageId.Text += " (图像数据损坏)";
                    picMain.Image = null;
                }
            }
        }

        // [API] 提交评价
        private async void SubmitDecision(string apiOption)
        {
            if (_images == null || _images.Count == 0 || _currentIndex >= _images.Count) return;

            var currentImage = _images[_currentIndex];
            string url = $"{BaseUrl}/Selections";

            // 构造 Payload
            var payload = new
            {
                imageId = currentImage.Id,
                selectedOption = apiOption // 只能是 "优", "良", "差"
            };

            var json = JsonConvert.SerializeObject(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await client.PostAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    // 成功后，自动显示下一张
                    _currentIndex++;
                    if (_currentIndex < _images.Count)
                    {
                        ShowImage(_currentIndex);
                    }
                    else
                    {
                        var result = MessageBox.Show("本批图片已处理完毕，是否加载新图片？", "完成", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            LoadImages();
                        }
                        else
                        {
                            lblImageId.Text = "等待新任务...";
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
                MessageBox.Show("提交错误: " + ex.Message);
            }
        }

        // --- 按钮事件映射 ---

        // "保留" 映射为 "优"
        private void btnKeep_Click(object sender, EventArgs e) => SubmitDecision("优");

        // "丢弃" 映射为 "差"
        private void btnDiscard_Click(object sender, EventArgs e) => SubmitDecision("差");

        // 图像增强 (纯客户端演示功能)
        private void btnEnhance_Click(object sender, EventArgs e)
        {
            if (picMain.Image == null) return;
            MessageBox.Show("图像增强处理已完成 (模拟)。", "系统提示");
        }
    }

    // [Model] 图片数据模型
    public class ImageInfo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        // 注意：Newtonsoft.Json 默认不区分大小写，可以自动匹配 iMageBase64
        public string IMageBase64 { get; set; }
        public string Type { get; set; }
    }
}