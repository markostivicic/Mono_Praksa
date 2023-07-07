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
    public class EmployeeService : IEmployeeService
    {
        private EmployeeRepository repository = new EmployeeRepository();

        public Employee Create(Employee employee)
        {
            return repository.Create(employee);
        }

        public Employee Update(Guid id, Employee employee)
        {
            return repository.Update(id, employee);
        }

        public bool Delete(Guid id)
        {
            return repository.Delete(id);
        }

        public Employee GetById(Guid id)
        {
            return repository.GetById(id);
        }

        public List<Employee> GetAll()
        {
            return repository.GetAll();
        }
    }
}
