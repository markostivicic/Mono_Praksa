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
        private IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<Employee> CreateAsync(Employee employee)
        {
            return await _repository.CreateAsync(employee);
        }

        public async Task<Employee> UpdateAsync(Guid id, Employee employee)
        {

            return await _repository.UpdateAsync(id, employee);

        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<Employee> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
    }
}
