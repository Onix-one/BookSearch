using BookSearch.Business.ExternalServices.Interfaces;
using BookSearch.Business.ExternalServices.Mappings;
using BookSearch.Business.ExternalServices.Services;
using BookSearch.DataAccess.ExternalDatabase.DI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookSearch.Business.ExternalServices.DI
{
    public static class DependencyRegistrator
    {
        public static void AddExternalServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(ExternalMappingProfile));
            services.AddTransient<IBookExternalService, BookExternalService>();
            services.AddDataAccessExternalDbComponents(configuration);
        }
    }
}