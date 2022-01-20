using ApiGamePlay.Application.Services;
using ApiGamePlay.Data.Context;
using ApiGamePlay.Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGamePlay.Application.Extensions
{
    public static class ServicesExtentions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IPlayerService, PlayerService>();
            services.AddTransient<IEquipamentoService, EquipamentoService>();
            services.AddTransient<IOgroService, OgroService>();
            services.AddTransient<PlayerEquipamentoService>();
            services.AddTransient<UserService>();
        }
    }
}
