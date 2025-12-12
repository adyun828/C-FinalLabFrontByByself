using Backend.DTOs;
using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ImagesController : ControllerBase
    {
        private readonly IImageService _imageService;
        private readonly ILogger<ImagesController> _logger;

        public ImagesController(IImageService imageService, ILogger<ImagesController> logger)
        {
            _imageService = imageService;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<List<ImageInfo>> GetImages([FromQuery] int count = 3)
        {
            try
            {
                var images = _imageService.GetRandomImages(count);
                return Ok(images);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "获取图像时发生错误");
                return StatusCode(500, "服务器错误");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<ImageInfo> GetImageById(int id)
        {
            try
            {
                var image = _imageService.GetImageById(id);
                if (image == null)
                {
                    return NotFound("图像不存在");
                }
                return Ok(image);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "获取图像时发生错误");
                return StatusCode(500, "服务器错误");
            }
        }

        [HttpPost]
        public ActionResult<UploadImageResponse> UploadImage([FromBody] UploadImageRequest request)
        {
            try
            {
                // 参数验证
                if (string.IsNullOrWhiteSpace(request.Title))
                {
                    return BadRequest(new UploadImageResponse
                    {
                        Success = false,
                        Message = "图片标题不能为空"
                    });
                }

                if (string.IsNullOrWhiteSpace(request.ImageBase64))
                {
                    return BadRequest(new UploadImageResponse
                    {
                        Success = false,
                        Message = "图片数据不能为空"
                    });
                }

                if (string.IsNullOrWhiteSpace(request.Type))
                {
                    return BadRequest(new UploadImageResponse
                    {
                        Success = false,
                        Message = "图片类型不能为空"
                    });
                }

                // 调用服务层上传图片
                var imageId = _imageService.AddImage(request.Title, request.ImageBase64, request.Type);

                return StatusCode(201, new UploadImageResponse
                {
                    Success = true,
                    Message = "图片上传成功",
                    ImageId = imageId
                });
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning(ex, "图片上传参数错误");
                return BadRequest(new UploadImageResponse
                {
                    Success = false,
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "上传图片时发生错误");
                return StatusCode(500, new UploadImageResponse
                {
                    Success = false,
                    Message = "服务器错误"
                });
            }
        }
    }
}
