using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneylionHomeTest.Business.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoneylionHomeTest.Data.Configurations
{
    public class FeatureUsageConfiguration
    {
        public FeatureUsageConfiguration(EntityTypeBuilder<FeatureUsage> entity)
        {
            entity.HasKey(e => new { e.FeatureName, e.Email });
            entity.Property(e => e.FeatureName)
               .IsRequired()
               .HasMaxLength(160);
            entity.Property(e => e.Email)
              .IsRequired()
              .HasMaxLength(160);

            entity.Property(e => e.Enable)
             .IsRequired()
             .HasMaxLength(160);
        }
    }
}
