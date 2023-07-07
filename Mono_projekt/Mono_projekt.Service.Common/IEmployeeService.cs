using Mono_projekt.Models;
using System;
using System.Collections.Generic;

namespace Mono_projekt.Service
{
    public interface IEmployeeService
    {
        Employee Create(Employee employee);
        bool Delete(Guid id);
        List<Employee> GetAll();
        Employee GetById(Guid id);
        Employee Update(Guid id, Employee employee);
    }
}