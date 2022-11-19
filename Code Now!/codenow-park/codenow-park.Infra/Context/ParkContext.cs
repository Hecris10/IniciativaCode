using codenow_park.Dominio.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codenow_park.Infra.Context
{
    public class ParkContext : DbContext
    {
        public ParkContext() : base()
        {

        }

        public ParkContext(DbContextOptions<ParkContext> options) : base(options)
        {

        }

        public DbSet<Estacionamento> Estacionamentos { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Vaga> Vagas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("ConexaoPadrao");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
