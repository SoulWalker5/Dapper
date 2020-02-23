using BusinessLogicLayer.Models;
using System.Collections.Generic;

namespace BusinessLogicLayer.Interfaces
{
    public interface ICarsService
    {
        IEnumerable<CarModel> GetCars();
        void AddNewCar(CarModel car);
        CarModel GetDetails(int id);
        void UpdateCar(CarModel car);
        void DeleteCar(CarModel car);
    }
}
