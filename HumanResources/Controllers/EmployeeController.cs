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
            updateEmployeeValidator.ValidateAndThrow(updateEmployee);
            var employee = employeeRepository.UpdateEmployee(id, updateEmployee);
            return Ok(employee);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee([FromRoute] long id)
        {
            var employee = employeeRepository.DeleteEmployee(id);
            return Ok(employee);
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var employee = employeeRepository.GetAllEmoployees();
            return Ok(employee);
        }
    }
}