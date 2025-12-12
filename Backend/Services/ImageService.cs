using Backend.Database;
using Backend.Models;

namespace Backend.Services
{
    public class ImageService : IImageService
    {
        private readonly DataRepository _repository;
        private readonly Random _random;

        public ImageService(DataRepository repository)
        {
            _repository = repository;
            _random = new Random();
        }

        // 获取随机图片（count限制1-10）
        public List<ImageInfo> GetRandomImages(int count = 3)
        {
            // 参数验证
            if (count < 1) count = 1;
            if (count > 10) count = 10;

            // 从数据库获取所有图片
            var allImages = _repository.GetAllImages();

            // 随机打乱并取指定数量
            return allImages
                .OrderBy(x => _random.Next())
                .Take(count)
                .ToList();
        }

        // 根据ID获取图片
        public ImageInfo? GetImageById(int id)
        {
            var allImages = _repository.GetAllImages();
            return allImages.FirstOrDefault(img => img.Id == id);
        }

        // 上传/添加新图片
        public int AddImage(string title, string base64Data, string type)
        {
            // 参数验证
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("图片标题不能为空");

            if (string.IsNullOrWhiteSpace(base64Data))
                throw new ArgumentException("图片数据不能为空");

            if (string.IsNullOrWhiteSpace(type))
                throw new ArgumentException("图片类型不能为空");

            // 验证图片类型
            var validTypes = new[] { "image/png", "image/jpeg", "image/jpg", "image/gif", "image/webp" };
            if (!validTypes.Contains(type.ToLower()))
                throw new ArgumentException("不支持的图片类型");

            // 调用仓储保存图片
            return _repository.AddImage(title, base64Data, type);
        }
    }
}
