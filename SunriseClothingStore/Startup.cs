﻿namespace SunriseClothingStore;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();
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