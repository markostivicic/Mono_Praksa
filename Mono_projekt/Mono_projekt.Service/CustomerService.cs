using Mono_projekt.Models;
using Mono_projekt.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mono_projekt.Service
{
    public class CustomerService : ICustomerService
    {
        private CustomerRepository repository = new CustomerRepository();

        public async Task<Customer> CreateAsync(Customer customer)
        {
            return await repository.CreateAsync(customer);
        }

        public async Task<Customer> UpdateAsync(Guid id, Customer customer)
        {
            if (id != null && customer != null)
            {
                return await repository.UpdateAsync(id, customer);
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

        public async Task<Customer> GetByIdAsync(Guid id)
        {
            return await repository.GetByIdAsync(id);
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }
    }
}
