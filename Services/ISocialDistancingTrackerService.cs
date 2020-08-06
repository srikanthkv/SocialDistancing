using SocialDistancingTracker.Models;
using System.Collections.Generic;

namespace SocialDistancingTracker.Services
{
    public interface ISocialDistancingTrackerService
    {
        EmployeeData Create(EmployeeData employeeData);
        List<EmployeeData> Get();
        EmployeeData Get(string id);
        void Remove(EmployeeData employeeData);
        void Remove(string id);
        void Update(string id, EmployeeData employeeData);
    }
}