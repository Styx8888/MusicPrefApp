using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Caching.Memory;
using MudBlazor.Services;
using MusicPrefApp.Application;
using MusicPrefApp.Application.Interfaces;
using MusicPrefApp.Services.SpotifyApi.Extensions;
using MusicPrefApp.UI.Models;
using MusicPrefApp.UI.State;

namespace MusicPrefApp.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddMudServices();
            
            var cache = new MemoryCache(new MemoryCacheOptions());

            services.AddSpotifyApiService(Configuration, cache);
            services.AddSingleton<IRecommendationEngine, SpotifyRecommendationEngine>();
            services.AddSingleton(typeof(AppState));
            services.AddScoped<IValidator<AnswersModel>, AnswersModelValidator>();
            ValidatorOptions.Global.LanguageManager.Enabled = false;
            services.AddSingleton<IRecommendationResult<string>, SpotifyCsvRecommendationResult>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action}");

                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
