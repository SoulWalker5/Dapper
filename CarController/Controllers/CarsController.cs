using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using BusinessLogicLayer.Services;
using PresentationLayer.Interfaces;
using PresentationLayer.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace PresentationLayer.Controllers
{
    public class CarsController : ICarsController
    {
        ICarsService service = new CarsService();

        public void Create(CarViewModel carViewModel)
        {
            CarModel carModel = new CarModel
            {
                Id = carViewModel.Id,
                Name = carViewModel.Name

            };
            service.Create(carModel);
        }

        public void Delete(int id)
        {
            service.Delete(id);
        }

        public CarViewModel GetById(int id)
        {
            CarModel carModel = service.GetById(id);

            var carViewModel = new CarViewModel()
            {
                Id = carModel.Id,
                Name = carModel.Name
            };
            return carViewModel;
        }

        public IEnumerable<CarViewModel> GetСars()
        {
            var carsViewModel = service.GetCars().Select(x => new CarViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Parts = x.Parts.Select(u => new DetailViewModel
                {
                    Id = u.Id,
                    CarId = u.CarId,
                    Name = u.Name,
                    Price = u.Price
                }).ToList()
                });
            return carsViewModel;
        }

        public void Update(CarViewModel carViewModel)
        {
            CarModel carModel = new CarModel
            {
                Id = carViewModel.Id,
                Name = carViewModel.Name

            };
            service.Update(carModel);
        }
    }
}
