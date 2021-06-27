using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MoneylionHomeTest.Business.Entities
{
    [Table("feature_usage")]
    public class FeatureUsage
    {
        
        [Column("feature_name")]
        [Required(ErrorMessage ="feature name is required")]
        public string FeatureName { get; set; }

        [Column("email")]
        [Required(ErrorMessage ="email is required")]
        public string Email { get; set; }

        [Column("enable")]
        [Required(ErrorMessage = "enable flag is required")]
        public bool Enable { get; set; } = false;
    }
}
