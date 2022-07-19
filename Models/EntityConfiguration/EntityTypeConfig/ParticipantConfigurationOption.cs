using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.EntityConfiguration.EntityTypeConfig
{
    public class ParticipantConfigurationOption : IEntityTypeConfiguration<Participant>
    {
        public void Configure(EntityTypeBuilder<Participant> builder)
        {
            builder
                .HasKey(t => t.id);

            builder
                .Property(t => t.Name)
                .HasColumnType("nvarchar(20)")
                .HasMaxLength(20);


            builder
                .HasOne(t => t.Pol)
                .WithMany(t => t.Profile)
                .HasForeignKey(t => t.PolId);

            builder
                .HasOne(t => t.User)
                .WithOne(t => t.Profile)
                .HasForeignKey<Participant>(t => t.UserId);

        }
    }
}
