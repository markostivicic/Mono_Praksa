using Mono_projekt.Models;
using System;
using System.Collections.Generic;

namespace Mono_projekt.Repository.Common
{
    public interface ICustomerRepository
    {
        Customer Create(Customer customer);
        bool Delete(Guid id);
        List<Customer> GetAll();
        Customer GetById(Guid Id);
        Customer Update(Guid id, Customer customer);
    }
}