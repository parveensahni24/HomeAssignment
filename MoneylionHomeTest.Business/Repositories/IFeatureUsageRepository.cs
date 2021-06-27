using MoneylionHomeTest.Business.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoneylionHomeTest.Business.Repositories
{
    public interface IFeatureUsageRepository:IDisposable
    {
        public void AddFeatureUsage(FeatureUsage featureUsage);
        public FeatureUsage GetByEmailAndFeature(string email, string featureName);
    }
}
