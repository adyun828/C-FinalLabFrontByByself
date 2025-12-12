using Backend.Database;
using Backend.Models;

namespace Backend.Services
{
    public class SelectionService : ISelectionService
    {
        private readonly DataRepository _repository;
        private readonly ILogger<SelectionService> _logger;

        public SelectionService(DataRepository repository, ILogger<SelectionService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        // 保存选择（验证用户名和图片ID）
        public bool SaveSelection(UserSelection selection)
        {
            try
            {
                // 业务验证
                if (string.IsNullOrWhiteSpace(selection.Username))
                {
                    _logger.LogWarning("用户名为空，无法保存选择");
                    return false;
                }

                if (selection.ImageId <= 0)
                {
                    _logger.LogWarning("无效的图片ID: {ImageId}", selection.ImageId);
                    return false;
                }

                // 验证SelectedOption值范围（优/良/差）
                var validOptions = new[] { "优", "良", "差" };
                if (!validOptions.Contains(selection.SelectedOption))
                {
                    _logger.LogWarning("无效的选择选项: {Option}，只允许：优/良/差", selection.SelectedOption);
                    return false;
                }

                // 调用仓储保存
                _repository.AddSelection(
                    selection.Username,
                    selection.ImageId,
                    selection.SelectedOption
                );

                _logger.LogInformation("用户 {Username} 的选择已保存: ImageId={ImageId}, Option={Option}",
                    selection.Username, selection.ImageId, selection.SelectedOption);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "保存选择时发生错误");
                return false;
            }
        }

        // 查询用户历史（包含关联的Image对象）
        public List<UserSelection> GetUserSelections(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                _logger.LogWarning("用户名为空，无法查询历史");
                return new List<UserSelection>();
            }

            return _repository.GetUserHistory(username);
        }
    }
}
