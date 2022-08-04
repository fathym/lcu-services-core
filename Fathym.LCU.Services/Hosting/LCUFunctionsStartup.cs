using Fathym.LCU.Hosting.Options;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Fathym.LCU.Services.Hosting
{
    public class LCUFunctionsStartup : FunctionsStartup
    {
        #region Fields
        protected readonly IConfiguration config;
        #endregion

        #region Constructors
        public LCUFunctionsStartup(IConfiguration config)
        {
            this.config = config ?? throw new ArgumentNullException(nameof(config));
        }
        #endregion

        #region API Methods
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var startupOptions = builder.Services.AddOptions<LCUStartupOptions>(config, LCUStartupOptions.ConfigKey);

            //services.AddLCUGlobalPipeline(startupOptions?.Global, config);

            //services.AddLCUEnterpriseContext();

            //services.AddLCUEnterprisePipeline(startupOptions?.Enterprise, config);

            //var startupOptions = startupOptions.Value;

            //app.UseLCUGlobalPipeline(env, logger, startupOptions.Global);

            //app.UseLCUEnterpriseContext(logger);

            //app.UseLCUEnterprisePipeline(env, logger, startupOptions.Enterprise);

            //app.UseRouting();

            //app.UseStaticFiles();

            //app.UseLCUEnterpriseContext(logger);

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapLCUAPI(logger, startupOptions?.Enterprise.API);

            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });

            //    //endpoints.MapRazorPages();

            //    //endpoints.MapControllerRoute(
            //    //    name: "default",
            //    //    pattern: "{controller=Home}/{action=Index}/{id?}");
            //});

            ////app.UseHealthChecks();
        }
        #endregion

        #region Helpers
        #endregion
    }
}
