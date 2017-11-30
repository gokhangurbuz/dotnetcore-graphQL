using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnetcoregraphql.Models;

namespace aspnetcoregraphql.Data
{
    public class NewsRepository:INewsRepository
    {
        private List<News> _news;

        public NewsRepository()
        {
            _news = new List<News>()
            {
                new News()
                {
                    Id = 1,
                    CategoryId = 1,
                    Name = "News1",
                    Description = "Desc1"
                },
                new News()
                {
                    Id = 2,
                    CategoryId = 1,
                    Name = "News2",
                    Description = "Desc2"
                },
                new News()
                {
                    Id = 3,
                    CategoryId = 2,
                    Name = "News3",
                    Description = "Desc3"
                },
                new News()
                {
                    Id = 4,
                    CategoryId = 3,
                    Name = "News4",
                    Description = "Desc4"
                }
            };
        }

        public Task GetNewsListAsync()
        {
            return Task.FromResult(_news);
        }

        public Task<List<News>> GetNewsWithByCategoryIdAsync(int categoryId)
        {
            return Task.FromResult(_news.Where(x => x.CategoryId == categoryId).ToList());
        }

        public Task<News> GetNewsAsync(int id)
        {
            return Task.FromResult(_news.FirstOrDefault(x => x.Id == id));
        }
    }
}
