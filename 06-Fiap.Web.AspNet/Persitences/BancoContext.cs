using _06_Fiap.Web.AspNet.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _06_Fiap.Web.AspNet.Persitences
{
    public class BancoContext : DbContext
    {
        public DbSet<Condominio> Condominios { get; set; }
        public DbSet<Construtora> Construtoras { get; set; }
        public DbSet<Sindico> Sindicos { get; set; }
        public DbSet<Imovel> Imoveis { get; set; }
        public object Imovel { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configurar as chaves primária da tabela
            modelBuilder.Entity<CondominioConstrutora>()
                .HasKey(c => new { c.ConstrutoraId, c.CondominioId });

            //Configurar o relacionamento com o Condominio
            modelBuilder.Entity<CondominioConstrutora>()
                .HasOne(c => c.Condominio)
                .WithMany(c => c.CondominioConstrutoras)
                .HasForeignKey(c => c.CondominioId);

            //Configurar o relacionamento com a Construtora
            modelBuilder.Entity<CondominioConstrutora>()
                .HasOne(c => c.Construtora)
                .WithMany(c => c.CondominioConstrutoras)
                .HasForeignKey(c => c.ConstrutoraId);

            base.OnModelCreating(modelBuilder);
        }

        public BancoContext(DbContextOptions o) : base(o)
        {

        }
    }
}
