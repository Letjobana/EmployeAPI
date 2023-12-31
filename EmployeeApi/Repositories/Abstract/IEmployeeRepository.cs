﻿using EmployeeApi.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeApi.Repositories.Abstract
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>>GetEmployees();
        Task<Employee> GetEmployeeById(int employeeId);
        Task<Employee> AddEmployee(Employee employee);
        Task<Employee>UpdateEmployee(Employee employee);
        Task<IEnumerable<Employee>> Search(string name, Gender? gender);
        void DeleteEmployee(int employeeId);
    }
}
