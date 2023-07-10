using Mono_projekt.Model.Common;
using Mono_projekt.Models;
using Mono_projekt.Repository;
using Mono_projekt.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mono_projekt.Service
{
    public class EmployeeService : IEmployeeService
    {
        private EmployeeRepository repository = new EmployeeRepository();

        public async Task<Employee> CreateAsync(Employee employee)
        {
            return await repository.CreateAsync(employee);
        }

        public async Task<Employee> UpdateAsync(Guid id, Employee employee)
        {
            if (id != null && employee != null)
            {
                return await repository.UpdateAsync(id, employee);
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await repository.DeleteAsync(id);
        }

        public async Task<Employee> GetByIdAsync(Guid id)
        {
            return await repository.GetByIdAsync(id);
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }
    }
}
