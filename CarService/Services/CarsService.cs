using System.Collections.Generic;
using System.Linq;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using DataAccessLayer;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repository;

namespace BusinessLogicLayer.Services
{
    public class CarsService : ICarsService
    {
        ICarsRepository repository = new CarsRepository();

        public void AddNewCar(CarModel car)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCar(CarModel car)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<CarModel> GetCars()
        {
            var carsModels = from car in repository.GetCars()
                             select new CarModel() { Id = car.Id, Name = car.Name };
            return carsModels;
        }

        public CarModel GetDetails(int id)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCar(CarModel car)
        {
            throw new System.NotImplementedException();
        }
    }
}
