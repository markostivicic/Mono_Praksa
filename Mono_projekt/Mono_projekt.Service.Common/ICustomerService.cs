using Mono_projekt.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mono_projekt.Service
{
    public interface ICustomerService
    {
        Task<Customer> CreateAsync(Customer customer);
        Task<bool> DeleteAsync(Guid id);
        Task<List<Customer>> GetAllAsync();
        Task<Customer> GetByIdAsync(Guid id);
        Task<Customer> UpdateAsync(Guid id, Customer customer);
    }
}