using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.EntityConfiguration.EntityTypeConfig
{
    public class MessageConfigurationOption : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder
                .HasKey(t => t.id);

            builder
                .Property(t => t.MessageText)
                .HasColumnType("nvarchar(2000)")
                .HasMaxLength(2000);
            builder
                .Property(t => t.DateCreate)
                .HasColumnType("nvarchar(2000)")
                .HasMaxLength(2000);

            builder
                .Property(t => t.IsRead)
                .HasColumnType("bit")
                .HasMaxLength(1);

            builder
                .Property(t => t.IsHidden)
                .HasColumnType("bit")
                .HasMaxLength(1);

            builder
                .HasOne(t => t.Theme)
                .WithOne(t => t.Message)
                .HasForeignKey<Message>(t => t.ThemeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(t => t.MessageSettings)
                .WithOne(t => t.Message)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
