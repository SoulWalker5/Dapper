using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;

namespace DataAccessLayer.Repository
{
    public class DetailsRepository : IDetailsRepository
    {
        private static readonly string connectionString = @"Initial Catalog=AutoDB;Integrated Security=True";

        public void Delete(Detail detail)
        {
            var sql = $"DELETE FROM Details WHERE Id = {detail.Id}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var result = connection.Execute(sql);
                connection.Close();
            };
        }

        public Detail GetCar(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Detail> GetDetails()
        {
            var query = "SELECT * FROM Details";
            var result = new List<Detail>();
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
                        result.Add(new Detail
                        {
                            Id = (int)reader["Id"],
                            CarId = (int)reader["CarId"],
                            Name = (string)reader["Name"]
                        });
                    }
                }
                connection.Close();

                return result;
            }
        }

        public void Create(Detail detail)
        {
            var sql = $"INSERT INTO Details (CarId, Name, Price) VALUES ({detail.CarId}, '{detail.Name}',{detail.Price})";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var insertId = (int)connection.ExecuteScalar(sql);
                connection.Close();

                detail.Id = insertId;
            };
        }

        public void Update(Detail detail)
        {
            var sql = $"UPDATE Details SET Name = '{detail.Name}', Cost = {detail.Price} WHERE ID = {detail.Id}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var result = connection.Execute(sql);
                connection.Close();
            };
        }
    }
}
