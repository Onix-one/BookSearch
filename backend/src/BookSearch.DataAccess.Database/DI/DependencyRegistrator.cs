using BookSearch.DataAccess.Database.Contexts;
using BookSearch.DataAccess.Database.Interfaces;
using BookSearch.DataAccess.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookSearch.DataAccess.Database.DI
{
	public static class DependencyRegistrator
    {
        public static IServiceCollection AddDataAccessDatabaseComponents(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IBookRepository, BookRepository>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(
                options =>
                    options.UseSqlServer(connectionString), ServiceLifetime.Transient);

            return services;
        }
    }
}
