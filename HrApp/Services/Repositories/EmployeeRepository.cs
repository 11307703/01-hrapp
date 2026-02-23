using HrApp.Data;
using HrApp.Models;
using HrApp.Services.Interfaces;
using HrApp.Services.Results;
using Microsoft.EntityFrameworkCore;

namespace HrApp.Services.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        AppDbContext _context;
        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }
        public  Task Add(Employee employee)
        {
            if (employee != null)
            {
                 _context.Employees.Add(employee);
                 _context.SaveChanges();
            }
            return Task.CompletedTask;
        }

        public Task Delete(Employee employee)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            var employees = await _context.Employees.ToListAsync();
            return employees;
        }

        public Task<Employee?> GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
