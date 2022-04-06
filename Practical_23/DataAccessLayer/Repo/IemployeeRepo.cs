using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practical_23.Repo
{
    public interface IemployeeRepo
    {
        Task<bool> Create(Employee emp);
        Task<List<Employee>> GetEmployee(int? id);
        Task Edit(Employee emp);
        Task<bool> Delete(int id);

    }
}
