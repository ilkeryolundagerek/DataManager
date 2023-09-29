using BusinessLogic.Services;
using BusinessLogic.Toolkit;
using Core.Abstracts.IServices;
using Core.Abstracts.IUnitOfWorks;
using Core.Concretes.Settings;
using Data.Contexts;
using Data.UnitOfWorks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace BusinessLogic
{
    public static class IOC
    {
        public static void AddBaseServices(this IServiceCollection services, IEnumerable<IConfigurationSection?> connection_strings)
        {
            services.AddDbContext<AW22Context>(options => options.UseSqlServer(connection_strings.FirstOrDefault(x => x.Key == "default").Value));
            services.AddDbContext<DataContext>(options => options.UseSqlServer(connection_strings.FirstOrDefault(x => x.Key == "identity").Value));
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<DataContext>().AddDefaultTokenProviders();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductionService, ProductionService>();
        }
    }
}
