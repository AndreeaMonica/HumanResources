using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
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
        private readonly IValidator<AddEmployeeRequest> addEmployeeValidator;
        private readonly IValidator<UpdateEmployeeRequest> updateEmployeeValidator;

        public EmployeeController(IEmployeeRepository employeeRepository,
                                  IValidator<AddEmployeeRequest> addEmployeeValidator,
                                  IValidator<UpdateEmployeeRequest> updateEmployeeValidator)
        {
            this.employeeRepository = employeeRepository;
            this.addEmployeeValidator = addEmployeeValidator;
            this.updateEmployeeValidator = updateEmployeeValidator;
        }

        [HttpPost]
        public IActionResult AddEmployee([FromBody] AddEmployeeRequest addEmployee)
        {
            addEmployeeValidator.ValidateAndThrow(addEmployee);
            var employeeId = employeeRepository.AddEmployee(addEmployee);
            return Ok(employeeId);
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployeeById([FromRoute] long id)
        {
            var getEmployee = employeeRepository.GetEmployee(id);
            if(getEmployee == null)
            {
                return NoContent();
            }
            return Ok(getEmployee);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee([FromRoute] long id, [FromBody] UpdateEmployeeRequest updateEmployee)
        {
            updateEmployeeValidator.ValidateAndThrow(updateEmployee);
            var employeeId = employeeRepository.UpdateEmployee(id, updateEmployee);
            if(employeeId == -1)
            {
                return BadRequest("Employee Not Found. No Employee was updated");
            }
            return Ok(employeeId);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee([FromRoute] long id)
        {
            var isDeleted = employeeRepository.DeleteEmployee(id);
            if(isDeleted == false)
            {
                return BadRequest("Employee Not Found. No Employee was deleted");
            }
            return Ok(isDeleted);
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var getAllEmployee = employeeRepository.GetAllEmoployees();
            if(getAllEmployee == null)
            {
                return NoContent();
            }
            return Ok(getAllEmployee);
        }
    }
}