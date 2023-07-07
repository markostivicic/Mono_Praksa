using Mono_projekt.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mono_projekt.Models
{
    public class Employee : IEmployee
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Employee(Guid id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}