using MoneylionHomeTest.Business.Entities;
using MoneylionHomeTest.Business.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoneylionHomeTest.Data.Repositories
{
    public class FeatureUsageRepository : IFeatureUsageRepository
    {
        private readonly PostgreSqlContext _context;
        public FeatureUsageRepository(PostgreSqlContext context)
        {
            _context = context;
        }

        void IFeatureUsageRepository.AddFeatureUsage(FeatureUsage featureUsage)
        {
            _context.featureUsages.Add(featureUsage);
            _context.SaveChanges();
        }

        FeatureUsage IFeatureUsageRepository.GetByEmailAndFeature(string email, string featureName)
        {
            return _context.featureUsages.Where(feature => (feature.Email == email && feature.FeatureName == featureName)).FirstOrDefault();
        }

        void IDisposable.Dispose()
        {
            _context.Dispose();
        }
    }
}
