using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.EntityConfiguration.EntityTypeConfig
{
    public class UserConfigurationOption : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .Property(t => t.DateCreate)
                .HasColumnType("nvarchar(50)")
                .HasMaxLength(50);

            builder
                .Property(t => t.DateChanges)
                .HasColumnType("nvarchar(50)")
                .HasMaxLength(50);

            builder
                .HasOne(t => t.Country)
                .WithMany(t => t.Users)
                .HasForeignKey(t => t.CountryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .Property(t => t.ConsentProvisionPersonalData)
                .HasColumnType("bit")
                .HasMaxLength(1)
                .HasDefaultValue(0);

            builder
                .Property(t => t.DateLastEntry)
                .HasColumnType("nvarchar(50)")
                .HasMaxLength(50);

            builder
                .HasMany(t => t.Groups)
                .WithMany(t => t.Users)
                .UsingEntity<GroupsIntermediate>
                (
                    t => t
                    .HasOne(t => t.Groups)
                    .WithMany(t => t.GroupsIntermediates)
                    .HasForeignKey(t => t.GroupsId),

                    t => t
                    .HasOne(t => t.User)
                    .WithMany(t => t.GroupsIntermediates)
                    .HasForeignKey(t => t.UserId),

                    j =>
                    {
                        j.HasKey(t => new { t.GroupsId, t.UserId });
                        j.ToTable("GroupsIntermediate");
                    }

                );
        }
    }
}
