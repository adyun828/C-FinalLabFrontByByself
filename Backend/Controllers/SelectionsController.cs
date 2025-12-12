using Backend.DTOs;
using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class SelectionsController : ControllerBase
    {
        private readonly ISelectionService _selectionService;
        private readonly ILogger<SelectionsController> _logger;

        public SelectionsController(ISelectionService selectionService, ILogger<SelectionsController> logger)
      {
   _selectionService = selectionService;
   _logger = logger;
        }

        [HttpPost]
        public ActionResult SaveSelection([FromBody] SelectionRequest request)
        {
            try
            {
                // 从JWT Token中获取用户名
                var username = User.FindFirst(ClaimTypes.Name)?.Value;
                if (string.IsNullOrEmpty(username))
                {
                    return Unauthorized("无效的用户身份");
                }

                if (request.ImageId <= 0 || string.IsNullOrWhiteSpace(request.SelectedOption))
                {
                    return BadRequest(new { Success = false, Message = "无效的选择数据" });
                }

                // 验证 SelectedOption 的值（优/良/差）
                var allowedOptions = new[] { "优", "良", "差" };
                if (!allowedOptions.Contains(request.SelectedOption))
                {
                    return BadRequest(new 
                    { 
                        Success = false, 
                        Message = "selectedOption 必须是以下值之一：优、良、差" 
                    });
                }

                var selection = new UserSelection
                {
                    Username = username,
                    ImageId = request.ImageId,
                    SelectedOption = request.SelectedOption
                };

                var result = _selectionService.SaveSelection(selection);

                if (result)
                {
                    return Ok(new { Success = true, Message = "选择已保存" });
                }
                else
                {
                    return StatusCode(500, new { Success = false, Message = "保存失败" });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "保存选择时发生错误");
                return StatusCode(500, new { Success = false, Message = "服务器错误" });
            }
        }

        [HttpGet]
     public ActionResult<List<UserSelection>> GetMySelections()
      {
            try
    {
       var username = User.FindFirst(ClaimTypes.Name)?.Value;
              if (string.IsNullOrEmpty(username))
     {
 return Unauthorized("无效的用户身份");
  }

     var selections = _selectionService.GetUserSelections(username);
        return Ok(selections);
            }
         catch (Exception ex)
  {
    _logger.LogError(ex, "获取选择记录时发生错误");
        return StatusCode(500, "服务器错误");
}
    }
    }
}
