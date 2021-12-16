using ApiGamePlay.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGamePlay.Data.Context
{
    public class GamePlayContext : DbContext 
    {
        public DbSet<Ogro> Ogros { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Equipamento> Equipamento { get; set; }
        public GamePlayContext(DbContextOptions<GamePlayContext> ops): base(ops)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity
        }
        // criar relação de player p equipamento 
        // fazer migration
        // 
    }
}
