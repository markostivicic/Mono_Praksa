using Mono_projekt.Models;
using Mono_projekt.Repository.Common;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Mono_projekt.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private string connectionString;

        public CustomerRepository()
        {
            connectionString = "Server=localhost;Port=5432;Database=HairSalon;User Id=postgres;Password=postgres;";
        }

        public async Task<Customer> CreateAsync(Customer customer)
        {
            var connection = new NpgsqlConnection(connectionString);
            var command = new NpgsqlCommand("INSERT INTO Customer (Id, FirstName, LastName) VALUES (@id, @firstName, @lastName)", connection);
            using (connection)
            {
                connection.Open();

                command.Parameters.AddWithValue("@id", customer.Id);
                command.Parameters.AddWithValue("@firstName", customer.FirstName);
                command.Parameters.AddWithValue("@lastName", customer.LastName);
                int affectedRows = await command.ExecuteNonQueryAsync();
                if (affectedRows > 0)
                {
                    return customer;
                }
                return null;
            }
        }

        public async Task<Customer> UpdateAsync(Guid id, Customer customer)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string checkSql = "SELECT COUNT(*) FROM Customer WHERE Id = @id";
                using (NpgsqlCommand checkCommand = new NpgsqlCommand(checkSql, connection))
                {
                    checkCommand.Parameters.AddWithValue("id", id);
                    int customerCount = Convert.ToInt32(checkCommand.ExecuteScalar());
                    if (customerCount == 0)
                    {
                        return null;
                    }
                }

                string updateSql = "UPDATE Customer SET FirstName = @firstName, LastName = @lastName WHERE Id = @id";
                using (NpgsqlCommand updateCommand = new NpgsqlCommand(updateSql, connection))
                {
                    updateCommand.Parameters.AddWithValue("id", id);
                    updateCommand.Parameters.AddWithValue("firstName", customer.FirstName);
                    updateCommand.Parameters.AddWithValue("lastName", customer.LastName);
                    int rowsAffected = await updateCommand.ExecuteNonQueryAsync();

                    if (rowsAffected > 0)
                    {
                        return customer;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string checkSql = "SELECT COUNT(*) FROM Customer WHERE Id = @id";
                using (NpgsqlCommand checkCommand = new NpgsqlCommand(checkSql, connection))
                {
                    checkCommand.Parameters.AddWithValue("id", id);
                    int customerCount = Convert.ToInt32(checkCommand.ExecuteScalar());
                    if (customerCount == 0)
                    {
                        return false;
                    }
                }
                string deleteSql = "DELETE FROM Customer WHERE Id = @id";
                using (NpgsqlCommand deleteCommand = new NpgsqlCommand(deleteSql, connection))
                {
                    deleteCommand.Parameters.AddWithValue("id", id);
                    deleteCommand.Connection = connection;
                    int rowsAffected = await deleteCommand.ExecuteNonQueryAsync();
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

        public async Task<Customer> GetByIdAsync(Guid Id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string selectSql = "SELECT Id, FirstName, LastName FROM Customer WHERE Id = @id";
                using (NpgsqlCommand command = new NpgsqlCommand(selectSql, connection))
                {
                    command.Parameters.AddWithValue("id", Id);

                    using (NpgsqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (reader.Read())
                        {
                            Guid id = reader.GetGuid(0);
                            string firstName = reader.GetString(1);
                            string lastName = reader.GetString(2);

                            Customer customer = new Customer(id, firstName, lastName);

                            return customer;
                        }
                    }
                }
                return null;
            }
        }
        public async Task<List<Customer>> GetAllAsync()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string selectSql = "SELECT Id, FirstName, LastName FROM Customer";
                using (NpgsqlCommand command = new NpgsqlCommand(selectSql, connection))
                {
                    List<Customer> customers = new List<Customer>();
                    using (NpgsqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            Guid id = reader.GetGuid(0);
                            string firstName = reader.GetString(1);
                            string lastName = reader.GetString(2);
                            Customer customer = new Customer(id, firstName, lastName);
                            customers.Add(customer);
                        }
                    }
                    return customers;
                }
            }
        }
    }
}
