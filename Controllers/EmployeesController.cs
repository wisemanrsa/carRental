using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using carRental.DTO;
using carRental.Interfaces;
using carRental.Services;

namespace carRental.Controllers
{
    [Route("api/employees")]
    public class EmployeesController : Controller
    {
        private readonly IEmployeesServices empService;
        public EmployeesController(IEmployeesServices empService)
        {
            this.empService = empService;
        }

        [HttpPost]
        public ActionResult Add([FromBody] EmployeeDTO employee)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var emp = empService.AddEmployee(employee);
            if (string.IsNullOrEmpty(emp.Result.StaffNumber) && !string.IsNullOrEmpty(emp.Result.ErrorMessage)) return BadRequest(emp.Result.ErrorMessage);
            return Ok(emp);
        }

        [HttpGet("{staffNumber}")]
        public ActionResult Search(string staffNumber)
        {
            var emp = empService.SearchEmployee(staffNumber);
            if (emp == null) return BadRequest($"No Employee with {staffNumber} as staff number");
            return Ok(emp);
        }
    }
}