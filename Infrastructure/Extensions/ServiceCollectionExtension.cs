using Domain.Interfaces.Services;
using Domain.POCO;
using Domain.SeedWork;
using Domain.Services;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MyDBContext>(option => option.UseSqlServer(configuration.GetConnectionString("DBContext")));
            return services;
        }

        public static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MyOption>(options => configuration.GetSection("MyDefaultSettings").Bind(options));
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            //services.AddTransient<IEntityService, EntityService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddTransient<IDepartmentService, DepartmentService>();
            services.AddScoped<IProductService, ProductService>();

            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }

        //public static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
        //{
        //    return services;
        //}
    }
}