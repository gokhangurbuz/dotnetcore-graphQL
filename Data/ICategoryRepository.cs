using System.Threading.Tasks;
using aspnetcoregraphql.Models;

namespace aspnetcoregraphql.Data
{
    public interface ICategoryRepository
    {
        Task CategoriesAsync();
        Task<Category> GetCategoryAsync(int id);
    }
}
