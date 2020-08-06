using Microsoft.AspNetCore.Mvc;
using SocialDistancingTracker.Models;
using System.Collections.Generic;

namespace SocialDistancingTracker.Controllers
{
    public interface ISocialDistancingTrackerController
    {
        ActionResult<EmployeeData> Create(EmployeeData employeeData);
        IActionResult Delete(string id);
        ActionResult<List<EmployeeData>> Get();
        ActionResult<EmployeeData> Get(string id);
        IActionResult Update(string id, EmployeeData newEmployeeData);
    }
}