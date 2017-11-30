using aspnetcoregraphql.Data;
using GraphQL.Types;

namespace aspnetcoregraphql.Models
{
    public class NewsType : ObjectGraphType<News>
    {
        public NewsType(ICategoryRepository categoryRepository)
        {
            Field(x => x.Id).Description("News id.");
            Field(x => x.CategoryId).Description("News category id.");
            Field(x => x.Name).Description("News name.");
            Field(x => x.Description, nullable: true).Description("News description.");

            Field<CategoryType>(
                "category",
                resolve: context => categoryRepository.GetCategoryAsync(context.Source.CategoryId).Result
            );
        }
    }
}