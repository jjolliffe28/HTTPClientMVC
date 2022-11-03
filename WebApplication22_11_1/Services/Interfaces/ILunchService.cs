using WebApplication22_11_1.Models;

namespace WebApplication22_11_1.Services.Interfaces
{
    public interface ILunchService
    {
        Task<IEnumerable<Lunch>> FindAll();

        Task<Lunch> FindOne(int id);
    }
}
