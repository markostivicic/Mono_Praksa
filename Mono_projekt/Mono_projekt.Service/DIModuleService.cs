using Autofac;
using Mono_projekt.Repository.Common;
using Mono_projekt.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mono_projekt.Service
{
    public class DIModuleService : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CustomerService>().As<ICustomerService>();
            builder.RegisterType<EmployeeService>().As<IEmployeeService>();
        }
    }
}
