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
            newEmployee.LastUpdate = newEmployee.DateHired;
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
            var employee = context.Employees.FirstOrDefault(x => x.Id == id);
            if(employee == null)
            {
                throw new Exception("Failed to find the employee to delete");
            }
            context.Remove(employee);
            context.SaveChanges();
            return true;
        }

        public long UpdateEmployee(long id, UpdateEmployeeRequest updateEmployee)
        {
            var employee = context.Employees.FirstOrDefault(x => x.Id == id);
            
            employee.Name = updateEmployee.Name;
            employee.LastUpdate = DateTime.Now;
            context.Update(employee);
            context.SaveChanges();
            return employee.Id;                
        }
    }
}
