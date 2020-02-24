using System.Collections.Generic;
using System.Linq;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Repository;

namespace BusinessLogicLayer.Services
{
    public class CarsService : ICarsService
    {
        ICarsRepository repository = new CarsRepository();

        public void Create(CarModel carmodel)
        {
            var car = new Car
            {
                Id = carmodel.Id,
                Name = carmodel.Name
            };
            repository.Create(car);
        }

        public void Delete(CarModel carmodel)
        {
            var car = new Car
            {
                Id = carmodel.Id,
                Name = carmodel.Name
            };
            repository.Delete(car);
        }

        public IEnumerable<CarModel> GetCars()
        {
            var carsModels = repository.GetCars().Select(x => new CarModel
            {
                Id = x.Id,
                Name = x.Name,
                Parts = x.Parts.Select(u => new DetailModel
                {
                    Id = u.Id,
                    CarId = u.CarId,
                    Name = u.Name,
                    Price = u.Price
                }).ToList()
            });

            return carsModels;
        }

        public CarModel GetById(int id)
        {
            Car car = repository.GetById(id);

            var carsModel = new CarModel()
            {
                Id = car.Id,
                Name = car.Name
            };
            return carsModel;
        }

        public void Update(CarModel carmodel)
        {
            var car = new Car
            {
                Id = carmodel.Id,
                Name = carmodel.Name
            };
            repository.Update(car);
        }

        //public IEnumerable<DetailModel> Details()
        //{
        //    var detailsModel = repository.Details().Select(x => new DetailModel { Id = x.Id, CarId = x.CarId, Name = x.Name, Price = x.Price });
        //    return detailsModel;
        //}
    }
}
