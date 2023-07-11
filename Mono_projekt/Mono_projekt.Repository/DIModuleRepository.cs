using Autofac;
using Mono_projekt.Repository.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Mono_projekt.Repository
{
    public class DIModuleRepository : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>();
            builder.RegisterType<EmployeeRepository>().As<IEmployeeRepository>();
            builder.Register(c => new NpgsqlConnection("Server=localhost;Port=5432;Database=HairSalon;User Id=postgres;Password=postgres;")).As<NpgsqlConnection>();
        }
    }
}
