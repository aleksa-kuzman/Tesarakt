using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Models.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Tesarakt.Common.Contracts;
using Tesarakt.Common.Models.Domain;
using Tesarakt.DAL.Common.Repository;
using Tesarakt.DAL.Common.UoW;

namespace TesaraktSajt
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.TryAddTransient(typeof(IRepository<,>), typeof(GenericEntityRepository<,>));
            services.TryAddScoped<IUowProvider, UowProvider>();
            services.AddDbContext<TesaraktContext>(options => options.UseMySql(@"server=localhost;Database=tesarakt;user=root;password='' "));
            services.AddScoped<DbContext, TesaraktContext>();
            services.AddTransient<IGrupaProizvodaService, GrupaProizvodaService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
          //  services.AddDbContext<DbContext, TesaraktContext>(options=>options.UseMySql(@"server=localhost;Database=tesarakt;user=root;password='' "));
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
