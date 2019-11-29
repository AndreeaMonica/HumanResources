using HumanResources.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResources.Repositories
{
    public interface IEmployeeRepository
    {
        long AddEmployee(AddEmployeeRequest employee);
        GetEmployeeResponse GetEmployee(long id);
        IEnumerable<GetEmployeeResponse> GetAllEmoployees();
        bool DeleteEmployee(long id);
        long UpdateEmployee(long id, UpdateEmployeeRequest updateEmployee);
    }
}
