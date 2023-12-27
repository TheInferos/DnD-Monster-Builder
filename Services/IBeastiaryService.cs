using Monster_Builder_Web_API.Models;

namespace Monster_Builder_Web_API.Services
{
    public interface IBeastiaryService
    {
        void AddMonster(Monster monster);
        Monster GetMonsterByID(string id);
    }
}