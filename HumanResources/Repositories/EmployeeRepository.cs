using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HumanResources.Entities;
using HumanResources.Models;

namespace HumanResources.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly HumanResourceContext context;
        private readonly IMapper mapper;

        public EmployeeRepository(HumanResourceContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public long AddEmployee(AddEmployeeRequest employee)
        {
            var newEmployee = mapper.Map<Employees>(employee);
            newEmployee.DateHired = DateTime.Now;
            newEmployee.LastUpdate = DateTime.Now;

            context.Add(newEmployee);
            context.SaveChanges();
            return newEmployee.Id;
        }

        public GetEmployeeResponse GetEmployee(long id)
        {
            var employee = context.Employees.FirstOrDefault(x => x.Id == id);
            var getEmployee = mapper.Map<GetEmployeeResponse>(employee);
            return getEmployee;
        }

        public bool DeleteEmployee(long id)
        {
            var employeeId = context.Employees.FirstOrDefault(x => x.Id == id);
            if(employeeId == null)
            {
                return false;
            }
            context.Remove(employeeId);
            context.SaveChanges();
            return true;
        }

        public long UpdateEmployee(long id, UpdateEmployeeRequest updateEmployee)
        {
            var employee = context.Employees.FirstOrDefault(x => x.Id == id);
            if(employee == null)
            {
                return -1;
            }
            employee.Name = updateEmployee.Name;
            employee.LastUpdate = DateTime.Now;
            context.Update(employee);
            context.SaveChanges();
            return employee.Id;                
        }

        public IEnumerable<GetEmployeeResponse> GetAllEmoployees()
        {
            var employees = context.Employees.ToList();            
            var getEmployees = mapper.Map<IEnumerable<GetEmployeeResponse>>(employees);
            return getEmployees;
        }
    }
}
