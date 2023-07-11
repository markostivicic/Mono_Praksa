﻿using Mono_projekt.Common.Filters;
using Mono_projekt.Common.Pagination;
using Mono_projekt.Common.Sort;
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
        Task<(List<Customer>, int)> GetAllAsync(ISort sort = null, IPagination pagination = null, ICustomerFilter filter = null);
        Task<Customer> GetByIdAsync(Guid id);
        Task<Customer> UpdateAsync(Guid id, Customer customer);
    }
}