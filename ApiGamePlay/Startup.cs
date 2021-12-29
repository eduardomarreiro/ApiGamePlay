using ApiGamePlay.Application.Services;
using ApiGamePlay.Data.Context;
using ApiGamePlay.Data.Repositories;
using ApiGamePlay.Domain.Interfaces;
using ApiGamePlay.Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace ApiGamePlay
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
            services.AddDbContext<GamePlayContext>(x => x.UseSqlServer(Configuration.GetConnectionString("Default")));
            services.AddTransient<IPlayerRepository,PlayerRepository>();
            services.AddTransient<IOgroRepository, OgroRepository>();
            services.AddTransient<IEquipamentoRepository, EquipamentoRepository>();
            services.AddTransient<IPlayerEquipamentoRepository,PlayerEquipamentoRepository>();
            services.AddTransient<PlayerService>();
            services.AddTransient<EquipamentoService>();
            services.AddTransient<OgroService>();
            services.AddTransient<PlayerEquipamentoService>();
            services.AddAutoMapper(Assembly.GetAssembly(typeof(GamePlayContext)));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApiGamePlay", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, GamePlayContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiGamePlay v1"));
            }
            context.Database.Migrate();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
