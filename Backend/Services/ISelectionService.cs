using Backend.Models;

namespace Backend.Services
{
    public interface ISelectionService
    {
    bool SaveSelection(UserSelection selection);
    List<UserSelection> GetUserSelections(string username);
    }
}
