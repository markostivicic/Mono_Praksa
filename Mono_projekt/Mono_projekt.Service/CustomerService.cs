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

        public Customer Create(Customer customer)
        {
            return repository.Create(customer);
        }

        public Customer Update(Guid id, Customer customer)
        {
            return repository.Update(id, customer);
        }

        public bool Delete(Guid id)
        {
            return repository.Delete(id);
        }

        public Customer GetById(Guid id)
        {
            return repository.GetById(id);
        }

        public List<Customer> GetAll()
        {
            return repository.GetAll();
        }
    }
}
