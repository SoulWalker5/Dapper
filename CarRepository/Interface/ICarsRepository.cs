using DataAccessLayer.Models;
using System.Collections.Generic;

namespace DataAccessLayer.Interfaces
{
    public interface ICarsRepository
    {
        Car GetById(int id);
        IEnumerable<Car> GetCars();
        void Create(Car car);
        void Delete(Car car);
        void Update(Car car);
    }
}
