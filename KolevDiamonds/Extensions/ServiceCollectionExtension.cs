using KolevDiamonds.Core.Contracts.InvestmentCoin;
using KolevDiamonds.Core.Contracts.InvestmentDiamond;
using KolevDiamonds.Core.Contracts.MetalBar;
using KolevDiamonds.Core.Contracts.Necklace;
using KolevDiamonds.Core.Contracts.Ring;
using KolevDiamonds.Core.Services.InvestmentCoin;
using KolevDiamonds.Core.Services.InvestmentDiamond;
using KolevDiamonds.Core.Services.MetalBar;
using KolevDiamonds.Core.Services.Necklace;
using KolevDiamonds.Core.Services.Ring;
using KolevDiamonds.Data;
using KolevDiamonds.Infrastructure.Data.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRingService, RingService>();
            services.AddScoped<INecklaceService, NecklaceService>();
            services.AddScoped<IMetalBarService, MetalBarService>();
            services.AddScoped<IInvestmentDiamondService, InvestmentDiamondService>();
            services.AddScoped<IInvestmentCoinService, InvestmentCoinService>();

            return services;
        }

        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IRepository, Repository>();

            services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }

        public static IServiceCollection AddApplicationIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            return services;
        }

        public static IServiceCollection AddApplicationSession(this IServiceCollection services) 
        {
            services.AddSession(options =>
            {
                options.Cookie.Name = ".YourApp.Session";
                options.IdleTimeout = TimeSpan.FromSeconds(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true; // Make the session cookie essential
            });

            return services;
        }
    }
}
