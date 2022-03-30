using SunriseClothingStore.Models;
using SunriseClothingStore.Models.Repositories;
using SunriseClothingStore.Models.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace SunriseClothingStore;

public class Startup
{
    private readonly string _connectionString;
    public Startup(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Sunrise API", Version = "v1"
            });
        });

        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IWebServiceRepository, WebServiceRepository>();
        
        services.AddDbContext<StoreContext>(options => 
            options.UseNpgsql(_connectionString));
        
        services.AddSession(options =>
        {
            options.Cookie.Name = "SunriseClothingStore.session";
            options.IdleTimeout = TimeSpan.FromHours(24);
            options.Cookie.HttpOnly = false;
        });
    }
        
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseStatusCodePages();

        app.UseStaticFiles();
        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapSwagger();
        });
    }
}