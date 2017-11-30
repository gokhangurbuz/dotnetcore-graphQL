using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnetcoregraphql.Models;

namespace aspnetcoregraphql.Data
{
    public class CategoryRepository:ICategoryRepository
    {
        private List<Category> _categories;
        public CategoryRepository()
        {
            _categories = new List<Category>()
            {
                new Category()
                {
                    Id = 1,
                    Name = "Headline"
                },
                new Category()
                {
                    Id = 2,
                    Name = "Politics"
                },
                new Category()
                {
                    Id = 3,
                    Name = "Sports"
                }
            };
        }

        public Task CategoriesAsync()
        {
            return Task.FromResult(_categories);
        }

        public Task<Category> GetCategoryAsync(int id)
        {
            return Task.FromResult(_categories.FirstOrDefault(x => x.Id == id));
        }
    }
}
