using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialDistancingTracker.Models
{
    public class SocialDistancingTrackerDatabaseSettings : ISocialDistancingTrackerDatabaseSettings
    {
        public string SocialDistancingTrackerCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface ISocialDistancingTrackerDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string SocialDistancingTrackerCollectionName { get; set; }
    }


}
