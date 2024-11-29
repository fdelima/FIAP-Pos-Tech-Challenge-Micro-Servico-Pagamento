﻿using FIAP.Pos.Tech.Challenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.EntityFrameworkCore.Extensions;

namespace FIAP.Pos.Tech.Challenge.Infra.Mappings;

internal class NotificacaoMap : IEntityTypeConfiguration<Notificacao>
{
    public void Configure(EntityTypeBuilder<Notificacao> builder)
    {
        builder.ToCollection("notificacao");

        builder.HasKey(e => e.IdNotificacao);

        builder.Property(e => e.IdNotificacao)
            .ValueGeneratedNever()
            .HasElementName("_id");
        builder.Property(e => e.Data)
            .HasElementName("data");
        builder.Property(e => e.IdDispositivo).HasElementName("id_dispositivo");
        builder.Property(e => e.Mensagem)
            .HasMaxLength(50)
            .HasElementName("mensagem");
    }
}
