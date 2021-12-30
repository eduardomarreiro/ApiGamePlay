using ApiGamePlay.Application.Services;
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
            services.AddTransient<PlayerService>();
            services.AddTransient<EquipamentoService>();
            services.AddTransient<OgroService>();
            services.AddTransient<PlayerEquipamentoService>();
            
        }
    }
}
