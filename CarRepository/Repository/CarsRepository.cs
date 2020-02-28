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

        public void Delete(int id)
        {
            var sql = $"DELETE FROM Cars WHERE Id = {id}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var result = connection.Execute(sql);
                connection.Close();
            };
        }

        public IEnumerable<Car> GetCars()
        {
            var sqlQuery = $"SELECT* FROM Cars c LEFT JOIN Details d on c.Id = d.CarId WHERE c.Id = d.CarId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var result = new List<Car>();
                var queryResult = connection.Query<Car, Detail, Car>(sqlQuery, (car, detail) =>
                {
                    var existingCar = result.FirstOrDefault(x => x.Id == car.Id);
                    if (existingCar == null)
                    {
                        result.Add(car);
                        existingCar = car;
                    }

                    existingCar.Parts.Add(detail);
                    return car;

                });

                connection.Close();
                return result;
            };
        }
    

        public void Create(Car car)
        {
            var sql = $"INSERT INTO Cars (Name) OUTPUT INSERTED.Id VALUES ('{car.Name}')";

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
            var sql = $"SELECT * FROM Cars car INNER JOIN Details detail on car.Id = detail.CarId WHERE car.Id = {id}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var result = connection.Query<Car, Detail, Car>(sql, (car, detail) =>
                {
                    car.Parts.Add(detail);

                    return car;
                }).ToList();

                var resultEntity = result.FirstOrDefault();
                resultEntity.Parts = result.SelectMany(x => x.Parts).ToList();

                connection.Close();

                return result.FirstOrDefault();
            };
        }
    }
}
