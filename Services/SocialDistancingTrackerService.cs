using MongoDB.Driver;
using SocialDistancingTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialDistancingTracker.Services
{
    public class SocialDistancingTrackerService
    {
        private readonly IMongoCollection<EmployeeData> EmployeeColliection;

        public SocialDistancingTrackerService(ISocialDistancingTrackerDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var dataBase = client.GetDatabase(settings.DatabaseName);

            EmployeeColliection = dataBase.GetCollection<EmployeeData>(settings.SocialDistancingTrackerCollectionName);
        }

        public List<EmployeeData> Get()
        {
            return EmployeeColliection.Find(Employee => true).ToList();
        }

        public EmployeeData Get(string id)
        {
            return EmployeeColliection.Find(Employee => Employee.EmployeeId == id).FirstOrDefault();
        }

        public EmployeeData Create (EmployeeData employeeData)
        {
            EmployeeColliection.InsertOne(employeeData);
            return employeeData;
        }

        public void Update(string id, EmployeeData employeeData)
        {
            EmployeeColliection.ReplaceOne(employee => employee.EmployeeId == id, employeeData);
        }

        public void Remove(EmployeeData employeeData) =>
            EmployeeColliection.DeleteOne(employee => employee.EmployeeId == employeeData.EmployeeId);

        public void Remove(string id) =>
            EmployeeColliection.DeleteOne(employee => employee.EmployeeId == id);
    }
}
