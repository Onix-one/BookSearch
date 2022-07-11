using BookSearch.Business.ExternalServices.DI;
using BookSearch.Business.Services.Interfaces;
using BookSearch.Business.Services.Mappings;
using BookSearch.Business.Services.Services;
using BookSearch.DataAccess.Database.DI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookSearch.Business.Services.DI
{
    public static class DependencyRegistrator
    {
        public static void AddRequestComponents(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddExternalServices(configuration);
            services.AddDataAccessDatabaseComponents(configuration);
            RegisterServices(services);
        }

        private static void RegisterServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfileFromServices));
            services.AddTransient<IBookService, BookService>();
        }
    }
}