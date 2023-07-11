using Mono_projekt.Common.Filters;
using Mono_projekt.Common.Pagination;
using Mono_projekt.Common.Sort;
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
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<Customer> CreateAsync(Customer customer)
        {
            return await _repository.CreateAsync(customer);
        }

        public async Task<Customer> UpdateAsync(Guid id, Customer customer)
        {

            return await _repository.UpdateAsync(id, customer);

        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<Customer> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<(List<Customer>, int)> GetAllAsync(ISort sort = null, IPagination pagination = null, ICustomerFilter filter = null)
        {
            return await _repository.GetAllAsync(sort, pagination, filter);
        }
    }
}
