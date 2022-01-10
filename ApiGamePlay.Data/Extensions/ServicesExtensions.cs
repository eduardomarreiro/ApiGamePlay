using ApiGamePlay.Data.Context;
using ApiGamePlay.Data.Repositories;
using ApiGamePlay.Domain.Interfaces;
// using ApiGamePlay.Domain.Interfaces.IRepository;
using ApiGamePlay.Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ApiGamePlay.Data.Extensions
{
    public static class ServicesExtensions 
    {
        public static void AddData(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddTransient<IPlayerRepository, PlayerRepository>();
            services.AddTransient<IOgroRepository, OgroRepository>();
            services.AddTransient<IEquipamentoRepository, EquipamentoRepository>();
            services.AddTransient<IPlayerEquipamentoRepository, PlayerEquipamentoRepository>();
            services.AddDbContext<GamePlayContext>(x => x.UseSqlServer(Configuration.GetConnectionString("Default")));
            services.AddAutoMapper(Assembly.GetAssembly(typeof(GamePlayContext)));
        }
    }
}
