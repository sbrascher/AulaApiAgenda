using AgendaAPI.Dominio.Entidades;
using AgendaAPI.Repositorio.Maps;
using Microsoft.EntityFrameworkCore;
using System;

namespace AgendaAPI.Repositorio
{
    public class AgendaContext : DbContext
    {
        public AgendaContext(DbContextOptions<AgendaContext> options) : base(options)
        {

        }

        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Telefone> Telefones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContatoMap());
            modelBuilder.ApplyConfiguration(new TelefoneMap());
        }
    }
}
