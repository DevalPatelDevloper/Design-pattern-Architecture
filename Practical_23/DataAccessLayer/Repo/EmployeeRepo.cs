using Data_Access_layar.Models;
using Microsoft.EntityFrameworkCore;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practical_23.Repo
{
    public class EmployeeRepo : IemployeeRepo
    {
        private readonly AppDbContext context;

        public EmployeeRepo(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<bool> Create(Employee emp)
        {
            if (emp.Id == 0)
            {
                await context.Employees.AddAsync(emp);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<List<Employee>> GetEmployee(int? id)
        {
            if (id == null)
            {
                var allemployee = await context.Employees.Include(x => x.Dept).ToListAsync();
                await context.SaveChangesAsync();
                return allemployee;
            }
            return await context.Employees.Include(x => x.Dept).Where(x => x.Id == id).ToListAsync();
        }
        public async Task Edit(Employee emp)
        {
            context.Employees.Update(emp);
            await context.SaveChangesAsync();
        }
        public async Task<bool> Delete(int id)
        {
            var employee = await context.Employees.FindAsync(id);
            if (employee != null)
            {
                employee.Status = true;
                context.Employees.Update(employee);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}

