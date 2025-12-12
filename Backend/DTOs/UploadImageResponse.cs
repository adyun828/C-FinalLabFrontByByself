namespace Backend.DTOs
{
    public class UploadImageResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public int ImageId { get; set; }
    }
}
