using Backend.Models;

namespace Backend.Services
{
    public interface IImageService
    {
        List<ImageInfo> GetRandomImages(int count = 3);
        ImageInfo? GetImageById(int id);
        int AddImage(string title, string base64Data, string type);
    }
}
