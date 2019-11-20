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
            var newEmployee = new Employees();
            newEmployee.Name = employee.Name;
            newEmployee.DateHired = employee.DateHired;
            newEmployee.LastUpdate = employee.DateHired;
            newEmployee.IsDeleted = false;

            //var newEmployee = mapper.Map<Employees>(employee);
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

        public bool SoftDelete(long id)
        {
            var employee = context.Employees.FirstOrDefault(x => x.Id == id);
            context.Remove(employee);
            context.SaveChanges();
            return true;
        }

        public long UpdateEmployee(UpdateEmployeeRequest updateEmployee, long id)
        {
            var employee = context.Employees.FirstOrDefault(x => x.Id == id);
            employee.LastUpdate = updateEmployee.LastUpdate;
            employee.Name = updateEmployee.Name;
            context.Update(employee);
            context.SaveChanges();
            return employee.Id;                
        }
    }
}
