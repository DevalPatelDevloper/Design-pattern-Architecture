using DAL.DataContext;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
   public class QueryRepo : IQueryRepo
    {
        private readonly AppDbContext context;

        public QueryRepo(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<List<Employee>> GetEmployee(int? id)
        {
            if (id == null)
            {
                var allemployee = await context.Employees.Include(x => x.Department).ToListAsync();
                await context.SaveChangesAsync();
                return allemployee;
            }
            return await context.Employees.Include(x => x.Department).Where(x => x.Id == id).ToListAsync();
        }
    }
}
