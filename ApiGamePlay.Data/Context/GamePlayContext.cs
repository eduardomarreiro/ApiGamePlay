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
        public DbSet<Equipamento> Equipamentos { get; set; }
        public DbSet<PlayerEquipamento> PlayersEquipamentos { get; set;}
        public DbSet<User> Users { get; set; }


        public GamePlayContext(DbContextOptions<GamePlayContext> ops): base(ops)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PlayerEquipamento>()
                .HasKey(pe => pe.Id);
            
            builder.Entity<PlayerEquipamento>()
                .HasOne(pe => pe.Equipamento)
                .WithMany(equipamento => equipamento.PlayerEquipamento)
                .HasForeignKey(pe => pe.EquipamentoId);

            builder.Entity<PlayerEquipamento>()
                .HasOne(pe => pe.Player)
                .WithMany(player => player.PlayerEquipamento)
                .HasForeignKey(pe => pe.PlayerId);
        }
    }
}
