using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SocialDistancingTracker.Models;
using SocialDistancingTracker.Services;

namespace SocialDistancingTracker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SocialDistancingTrackerController : ControllerBase, ISocialDistancingTrackerController
    {
        private readonly SocialDistancingTrackerService _socialDistancingTrackerService;

        public SocialDistancingTrackerController(SocialDistancingTrackerService socialDistancingTrackerService)
        {
            _socialDistancingTrackerService = socialDistancingTrackerService;
        }

        [HttpGet]
        public ActionResult<List<EmployeeData>> Get()
        {
            return _socialDistancingTrackerService.Get();
        }

        [HttpGet("{id:length(24)}", Name = "GetEmployeeData")]
        public ActionResult<EmployeeData> Get(string id)
        {
            var employeeData = _socialDistancingTrackerService.Get(id);

            if (employeeData == null)
            {
                return NotFound();
            }

            return employeeData;
        }

        [HttpPost]
        public ActionResult<EmployeeData> Create(EmployeeData employeeData)
        {
            var employee = _socialDistancingTrackerService.Create(employeeData);
            return employee;
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, EmployeeData newEmployeeData)
        {
            var existingEmployeeData = _socialDistancingTrackerService.Get(id);

            if (existingEmployeeData == null)
            {
                return NotFound();
            }

            _socialDistancingTrackerService.Update(id, newEmployeeData);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var employeeData = _socialDistancingTrackerService.Get(id);

            if (employeeData == null)
            {
                return NotFound();
            }

            _socialDistancingTrackerService.Remove(employeeData.EmployeeId);

            return NoContent();
        }
    }
}
