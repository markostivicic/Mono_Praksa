using Mono_projekt.Models;
using System;
using System.Collections.Generic;

namespace Mono_projekt.Repository.Common
{
    public interface IEmployeeRepository
    {
        Employee Create(Employee employee);
        bool Delete(Guid id);
        List<Employee> GetAll();
        Employee GetById(Guid Id);
        Employee Update(Guid id, Employee employee);
    }
}