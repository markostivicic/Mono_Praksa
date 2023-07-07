using Mono_projekt.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mono_projekt.Repository.Common
{
    public interface IEmployeeRepository
    {
        Task<Employee> CreateAsync(Employee employee);
        Task<bool> DeleteAsync(Guid id);
        Task<List<Employee>> GetAllAsync();
        Task<Employee> GetByIdAsync(Guid Id);
        Task<Employee> UpdateAsync(Guid id, Employee employee);
    }
}