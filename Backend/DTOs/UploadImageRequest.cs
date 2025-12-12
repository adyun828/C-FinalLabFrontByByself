namespace Backend.DTOs
{
    public class UploadImageRequest
    {
        public string Title { get; set; } = string.Empty;
        public string ImageBase64 { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
    }
}
