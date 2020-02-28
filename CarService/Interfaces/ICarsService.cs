using BusinessLogicLayer.Models;
using System.Collections.Generic;

namespace BusinessLogicLayer.Interfaces
{
    public interface ICarsService
    {
        IEnumerable<CarModel> GetCars();
        CarModel GetById(int id);
        void Create(CarModel car);
        void Update(CarModel car);
        void Delete(int id);
    }
}
