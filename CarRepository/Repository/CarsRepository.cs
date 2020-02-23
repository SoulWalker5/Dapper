using Dapper;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DataAccessLayer.Repository
{
    public class CarsRepository : ICarsRepository
    {
        private static readonly string connectionString = @"Initial Catalog=AutoDB;Integrated Security=True";

        public void Delete(Car car)
        {
            var sql = $"DELETE FROM Cars WHERE Id = {car.Id}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var result = connection.Execute(sql);
                connection.Close();
            };
        }

        public IEnumerable<Car> GetCars()
        {
            var query = "SELECT * FROM Cars";
            var result = new List<Car>();
            SqlConnection connection = new SqlConnection(connectionString);

            using (connection)
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        result.Add(new Car
                        {
                            Id = (int)reader["Id"],
                            Name = (string)reader["Name"]
                        });
                    }
                }
                connection.Close();

                return result;
            }
        }

        public Car GetDetails(int id)
        {
            var sql = $"SELECT * FROM Cars Car INNER JOIN Details Detail on Car.Id = Detail.CarId WHERE Car.Id = {id}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var result = connection.Query<Car, Detail, Car>(sql, (car, detail) =>
                {
                    car.Detail = detail;

                    return car;
                }).ToList();

                connection.Close();

                return result.FirstOrDefault();
            }
        }

        public void Create(Car car)
        {
            var sql = $"INSERT INTO Cars (Name) VALUES ('{car.Name}')";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var insertId = (int)connection.ExecuteScalar(sql);
                connection.Close();

                car.Id = insertId;
            };
        }

        public void Update(Car car)
        {
            var sql = $"UPDATE Cars SET Name = '{car.Name}' WHERE ID = {car.Id}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var result = connection.Execute(sql);
                connection.Close();
            };
        }

        public Car GetById(int id)
        {
            var sql = $"SELECT * FROM Cars c INNER JOIN Details в on в.Id = c.CarId WHERE h.Id = {id};";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var result = connection.Query<Car, Detail, Car>(sql, (car, detail) =>
                {
                    car.Detail = detail;

                    return car;
                });
                connection.Close();

                return result.FirstOrDefault();
            };
        }
    }
}
