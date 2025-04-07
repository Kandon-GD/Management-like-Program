using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using MyApp.View;
using System.Security.RightsManagement;
using System.Security.Cryptography;

namespace MyApp.Utilities
{
    class DatabaseHelper
    {
        private static string connectionString = "Server=localhost;Database=Azienda_db;User ID=root;Password=root;";
        public static async Task<int> GetEmployeeCount()
        {
            int count = 0;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "select COUNT(*) from dipendenti";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    count = Convert.ToInt32(await cmd.ExecuteScalarAsync());
                }
            }

            return count;
        }

        public static async Task<List<Employee>> GetEmployeesAsync(string query)
        {
            List<Employee> employees = new List<Employee>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                await conn.OpenAsync();

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = (MySqlDataReader)await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            employees.Add(new Employee
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Last = reader.GetString(2),
                                Role = reader.GetString(3),
                                Department = reader.GetString(4),
                                HireDate = reader.GetDateTime(5).ToShortDateString(),
                                BirthDate = reader.GetDateTime(6).ToShortDateString(),
                                Salary = reader.GetDecimal(7)


                            });
                        }
                    }
                }
            }
            return employees;
        }

        

    }
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Last { get; set; }
        public string Role {  get; set; }
        public string Department {  get; set; }
        public string HireDate { get; set; }
        public string BirthDate {  get; set; }
        public decimal Salary {  get; set; }
    }
}
