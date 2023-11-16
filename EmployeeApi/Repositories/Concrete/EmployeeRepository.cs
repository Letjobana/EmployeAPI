using EmployeeApi.DataAccess;
using EmployeeApi.Models;
using EmployeeApi.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApi.Repositories.Concrete
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext context;

        public EmployeeRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<Employee> AddEmployee(Employee employee)
        {
            var result= await context.Employees.AddAsync(employee);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        public async void DeleteEmployee(int employeeId)
        {
            var result = await context.Employees.FirstOrDefaultAsync(x => x.EmployeeId == employeeId);
            if(result != null)
            {
                context.Employees.Remove(result);
                await context.SaveChangesAsync();
            }
        }

        public async Task<Employee> GetEmployeeById(int employeeId)
        {
            return await context.Employees.FirstOrDefaultAsync(x=>x.EmployeeId == employeeId);
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await context.Employees.ToListAsync();
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var result = await context.Employees.FirstOrDefaultAsync(x => x.EmployeeId == employee.EmployeeId);
            if(result != null)
            {
                result.FirstName = employee.FirstName;
                result.LastName = employee.LastName;
                result.Email = employee.Email;
                result.DateOfBrith = employee.DateOfBrith;
                result.Gender = employee.Gender;
                result.Department   = employee.Department;
                result.PhotoPath = employee.PhotoPath;
                await context.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
