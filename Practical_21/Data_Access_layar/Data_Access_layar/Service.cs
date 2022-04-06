using Data_Access_layar.Models;
using Microsoft.EntityFrameworkCore;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_layar
{
    public class Service
    {
        private readonly AppDbContext context;

        public Service(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> AddEmp(Employee employee)
        {
            if(employee==null)
            {
                return false;
            }
            await context.Employees.AddAsync(employee);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Employee>> GetAllEmp()
        {
            var emp = await context.Employees.Include(x => x.Dept).Where(x=>x.Status==false).ToListAsync();
            return emp;
        }

        public async Task<Employee> GetEmployee(int? id)
        {
            if (id == null)
            {
                return null;
            }
            return await context.Employees.FindAsync(id);
        }
        public async Task DeleteEmployee(int id)
        {
            var emp = await GetEmployee(id);
            emp.Status = true;
            context.Update(emp);
            await context.SaveChangesAsync(); 

        }
        public async Task Updateemp(Employee employee)
        {
            context.Update(employee);
            await context.SaveChangesAsync();
        }

        public async Task<bool> IsEmployeeExist(int id)
        {
            var en = await GetEmployee(id);
            return en!=null;
        }
    }
}
