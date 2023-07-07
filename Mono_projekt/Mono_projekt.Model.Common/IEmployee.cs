using System;

namespace Mono_projekt.Models.Common
{
    public interface IEmployee
    {
        string FirstName { get; set; }
        Guid Id { get; set; }
        string LastName { get; set; }
    }
}