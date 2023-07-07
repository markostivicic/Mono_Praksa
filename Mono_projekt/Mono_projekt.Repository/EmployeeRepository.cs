using Mono_projekt.Models;
using Mono_projekt.Models.Common;
using Mono_projekt.Repository.Common;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mono_projekt.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private string connectionString;

        public EmployeeRepository()
        {
            connectionString = "Server=localhost;Port=5432;Database=HairSalon;User Id=postgres;Password=postgres;";
        }

        public Employee Create(Employee employee)
        {
            var connection = new NpgsqlConnection(connectionString);
            var command = new NpgsqlCommand("INSERT INTO Employee (Id, FirstName, LastName) VALUES (@id, @firstName, @lastName)", connection);
            using (connection)
            {
                connection.Open();

                command.Parameters.AddWithValue("@id", employee.Id);
                command.Parameters.AddWithValue("@firstName", employee.FirstName);
                command.Parameters.AddWithValue("@lastName", employee.LastName);
                int affectedRows = command.ExecuteNonQuery();
                if (affectedRows > 0)
                {
                    return employee;
                }
                return null;
            }
        }

        public Employee Update(Guid id, Employee employee)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string checkSql = "SELECT COUNT(*) FROM Employee WHERE Id = @id";
                using (NpgsqlCommand checkCommand = new NpgsqlCommand(checkSql, connection))
                {
                    checkCommand.Parameters.AddWithValue("id", id);
                    int employeeCount = Convert.ToInt32(checkCommand.ExecuteScalar());
                    if (employeeCount == 0)
                    {
                        return null;
                    }
                }

                string updateSql = "UPDATE Employee SET FirstName = @firstName, LastName = @lastName WHERE Id = @id";
                using (NpgsqlCommand updateCommand = new NpgsqlCommand(updateSql, connection))
                {
                    updateCommand.Parameters.AddWithValue("id", id);
                    updateCommand.Parameters.AddWithValue("firstName", employee.FirstName);
                    updateCommand.Parameters.AddWithValue("lastName", employee.LastName);
                    int rowsAffected = updateCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return employee;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public bool Delete(Guid id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string checkSql = "SELECT COUNT(*) FROM Employee WHERE Id = @id";
                using (NpgsqlCommand checkCommand = new NpgsqlCommand(checkSql, connection))
                {
                    checkCommand.Parameters.AddWithValue("id", id);
                    int employeeCount = Convert.ToInt32(checkCommand.ExecuteScalar());
                    if (employeeCount == 0)
                    {
                        return false;
                    }
                }
                string deleteSql = "DELETE FROM Employee WHERE Id = @id";
                using (NpgsqlCommand deleteCommand = new NpgsqlCommand(deleteSql, connection))
                {
                    deleteCommand.Parameters.AddWithValue("id", id);
                    deleteCommand.Connection = connection;
                    int rowsAffected = deleteCommand.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public Employee GetById(Guid Id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string selectSql = "SELECT Id, FirstName, LastName FROM Employee WHERE Id = @id";
                using (NpgsqlCommand command = new NpgsqlCommand(selectSql, connection))
                {
                    command.Parameters.AddWithValue("id", Id);

                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Guid id = reader.GetGuid(0);
                            string firstName = reader.GetString(1);
                            string lastName = reader.GetString(2);

                            Employee employee = new Employee(id, firstName, lastName);

                            return employee;
                        }
                    }
                }
                return null;
            }
        }
        public List<Employee> GetAll()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string selectSql = "SELECT Id, FirstName, LastName FROM Employee";
                using (NpgsqlCommand command = new NpgsqlCommand(selectSql, connection))
                {
                    List<Employee> employees = new List<Employee>();
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Guid id = reader.GetGuid(0);
                            string firstName = reader.GetString(1);
                            string lastName = reader.GetString(2);
                            Employee employee = new Employee(id, firstName, lastName);
                            employees.Add(employee);
                        }
                    }
                    return employees;
                }
            }
        }

    }
}
