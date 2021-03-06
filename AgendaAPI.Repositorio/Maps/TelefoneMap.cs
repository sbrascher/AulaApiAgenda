﻿using AgendaAPI.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaAPI.Repositorio.Maps
{
    public class TelefoneMap : IEntityTypeConfiguration<Telefone>
    {
        public void Configure(EntityTypeBuilder<Telefone> builder)
        {
            builder.ToTable("Telefone");

            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Numero).HasColumnName("Numero");
            builder.Property(x => x.ContatoId).HasColumnName("ContatoId");

            builder
                .HasOne(x => x.Contato)
                .WithMany(x => x.Telefones)
                .HasForeignKey(x => x.ContatoId);
        }
    }
}
