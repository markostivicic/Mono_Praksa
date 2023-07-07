using Mono_projekt.Models;
using System;
using System.Collections.Generic;

namespace Mono_projekt.Service
{
    public interface ICustomerService
    {
        Customer Create(Customer customer);
        bool Delete(Guid id);
        List<Customer> GetAll();
        Customer GetById(Guid id);
        Customer Update(Guid id, Customer customer);
    }
}