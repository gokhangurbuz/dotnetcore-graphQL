using aspnetcoregraphql.Data;
using GraphQL.Types;

namespace aspnetcoregraphql.Models
{
    public class StoreQuery : ObjectGraphType
    {
        public StoreQuery(ICategoryRepository categoryRepository, INewsRepository newsRepository)
        {
            Field<CategoryType>(
                "category",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id", Description = "Category id" }
                ),
                resolve: context => categoryRepository.GetCategoryAsync(context.GetArgument<int>("id")).Result
            );

            Field<NewsType>(
                "news",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id", Description = "News id" }
                ),
                resolve: context => newsRepository.GetNewsAsync(context.GetArgument<int>("id")).Result
            );
        }
    }
}
