using SunriseClothingStore.Models;
using SunriseClothingStore.Models.Repositories;
using SunriseClothingStore.Models.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

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
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        
        services.AddDbContext<StoreContext>(options => 
            options.UseNpgsql(_connectionString));
        
    }
        
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        app.UseStatusCodePages();

        app.UseStaticFiles();
        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}