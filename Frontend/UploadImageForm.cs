using System;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace WindowsFormsApp1
{
    public partial class UploadImageForm : Form
    {
        private string _token;
        private Image? _selectedImage;
        private string _imageFormat = ""; // 存储图片格式
        private const string BaseUrl = "http://localhost:5000/api";

        public UploadImageForm(string token)
        {
            InitializeComponent();
            _token = token;
        }

        // 选择图片按钮
        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "图片文件|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                openFileDialog.Title = "选择要上传的图片";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _selectedImage = Image.FromFile(openFileDialog.FileName);
                        picPreview.Image = _selectedImage;
                        txtImagePath.Text = openFileDialog.FileName;
                        
                        // 自动检测图片格式并设置MIME类型
                        string extension = Path.GetExtension(openFileDialog.FileName).ToLower();
                        _imageFormat = extension switch
                        {
                            ".png" => "image/png",
                            ".jpg" => "image/jpeg",
                            ".jpeg" => "image/jpeg",
                            ".gif" => "image/gif",
                            ".bmp" => "image/bmp",
                            _ => "image/jpeg"
                        };
                        
                        // 显示格式信息
                        txtType.Text = _imageFormat;
                        
                        // 自动填充标题（文件名）
                        if (string.IsNullOrEmpty(txtTitle.Text))
                        {
                            txtTitle.Text = Path.GetFileNameWithoutExtension(openFileDialog.FileName);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("无法加载图片: " + ex.Message, "错误");
                    }
                }
            }
        }

        // 上传图片按钮
        private async void btnUpload_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text.Trim();

            // 验证输入
            if (string.IsNullOrEmpty(title))
            {
                MessageBox.Show("请输入图片标题", "提示");
                txtTitle.Focus();
                return;
            }

            if (_selectedImage == null || string.IsNullOrEmpty(_imageFormat))
            {
                MessageBox.Show("请先选择图片", "提示");
                return;
            }

            // 禁用按钮防止重复提交
            btnUpload.Enabled = false;
            btnUpload.Text = "上传中...";

            try
            {
                // 将图片转换为Base64
                string base64Image;
                using (MemoryStream ms = new MemoryStream())
                {
                    _selectedImage.Save(ms, _selectedImage.RawFormat);
                    byte[] imageBytes = ms.ToArray();
                    base64Image = Convert.ToBase64String(imageBytes);
                }

                // 构建请求数据
                var uploadData = new
                {
                    title = title,
                    imageBase64 = base64Image,
                    type = _imageFormat // 使用自动检测的MIME类型
                };

                var json = JsonConvert.SerializeObject(uploadData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // 发送请求
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
                    
                    var response = await client.PostAsync($"{BaseUrl}/Images", content);
                    var responseContent = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        var result = JsonConvert.DeserializeObject<UploadImageResponse>(responseContent);
                        if (result != null && result.Success)
                        {
                            MessageBox.Show($"上传成功！图片ID: {result.ImageId}", "成功");
                            
                            // 清空表单
                            txtTitle.Clear();
                            txtType.Text = "请先选择图片";
                            txtImagePath.Clear();
                            picPreview.Image = null;
                            _selectedImage = null;
                            _imageFormat = "";
                            
                            // 设置对话框结果为OK，通知主窗体刷新
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            MessageBox.Show("上传失败: " + (result?.Message ?? "未知错误"), "错误");
                        }
                    }
                    else
                    {
                        MessageBox.Show($"上传失败，状态码: {response.StatusCode}\n{responseContent}", "错误");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("上传出错: " + ex.Message, "错误");
            }
            finally
            {
                btnUpload.Enabled = true;
                btnUpload.Text = "上  传";
            }
        }

        // 取消按钮
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // 响应模型
        public class UploadImageResponse
        {
            public bool Success { get; set; }
            public string Message { get; set; } = string.Empty;
            public int ImageId { get; set; }
        }
    }
}
