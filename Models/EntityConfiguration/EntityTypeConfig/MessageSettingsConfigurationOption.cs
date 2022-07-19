using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.EntityConfiguration.EntityTypeConfig
{
    public class MessageSettingsConfigurationOption : IEntityTypeConfiguration<MessageSettings>
    {
        public void Configure(EntityTypeBuilder<MessageSettings> builder)
        {
            builder
                .HasKey(t => t.id);
        }
    }
}
