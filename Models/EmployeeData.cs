using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SocialDistancingTracker.Models
{
    public class EmployeeData
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string EmployeeId { get; set; }

        public string EmployeeName { get; set; }

        public string EmployeeEmail { get; set; }

        public string EmployeePhone { get; set; }

        public string EmployeeImage { get; set; }

        public string LocationImage { get; set; }
    }
}
