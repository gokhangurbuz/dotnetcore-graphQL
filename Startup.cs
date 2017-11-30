using aspnetcoregraphql.Data;
using aspnetcoregraphql.Models;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace aspnetcoregraphql
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddScoped<StoreQuery>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<INewsRepository, NewsRepository>();
            services.AddScoped<IDocumentExecuter, DocumentExecuter>();
            services.AddTransient<CategoryType>();
            services.AddTransient<NewsType>();
            var sp = services.BuildServiceProvider();
            services.AddScoped<ISchema>(_ => new StoreSchema(type => (GraphType)sp.GetService(type)) { Query = sp.GetService<StoreQuery>() });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
