using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HumanResources.Models;
using HumanResources.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HumanResources.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        [HttpPost]
        public IActionResult AddEmployee([FromBody] AddEmployeeRequest addEmployee)
        {
            var employee = employeeRepository.AddEmployee(addEmployee);
            return Ok(employee);
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployeeById([FromRoute] long id)
        {
            var employee = employeeRepository.GetEmployee(id);
            return Ok(employee);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee([FromRoute] long id, [FromBody] UpdateEmployeeRequest updateEmployee)
        {
            var employee = employeeRepository.UpdateEmployee(id, updateEmployee);
            return Ok(employee);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee([FromRoute] long id)
        {
            var employee = employeeRepository.DeleteEmployee(id);
            return Ok(employee);
        }
    }
}