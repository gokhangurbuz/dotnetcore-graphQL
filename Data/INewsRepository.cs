
using System.Collections.Generic;
using System.Threading.Tasks;
using aspnetcoregraphql.Models;

namespace aspnetcoregraphql.Data
{
    public interface INewsRepository
    {
        Task GetNewsListAsync();
        Task<News> GetNewsAsync(int id);
        Task<List<News>> GetNewsWithByCategoryIdAsync(int categoryId);
    }
}
