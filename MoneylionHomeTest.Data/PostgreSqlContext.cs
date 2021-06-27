using Microsoft.EntityFrameworkCore;
using MoneylionHomeTest.Business.Entities;
using MoneylionHomeTest.Data.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoneylionHomeTest.Data
{
    public class PostgreSqlContext : DbContext
    {
        public DbSet<FeatureUsage> featureUsages { get; set; }

        public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            new FeatureUsageConfiguration(builder.Entity<FeatureUsage>());
        }


    }
}
