using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using BusinessLogicLayer.Services;
using PresentationLayer.Interfaces;
using PresentationLayer.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace PresentationLayer.Controllers
{
    public class DetailsController : IDetailsController
    {
        IDetailsService service = new DetailService();

        public void Create(DetailViewModel detailViewModel)
        {
            DetailModel detailModel = new DetailModel
            {
                Id = detailViewModel.Id,
                CarId = detailViewModel.CarId,
                Name = detailViewModel.Name,
                Price = detailViewModel.Price

            };
            service.Create(detailModel);
        }

        public void Delete(DetailViewModel detailViewModel)
        {
            DetailModel detailModel = new DetailModel
            {
                Id = detailViewModel.Id,
                CarId = detailViewModel.CarId,
                Name = detailViewModel.Name,
                Price = detailViewModel.Price

            };
            service.Delete(detailModel);
        }

        public IEnumerable<DetailViewModel> GetDetails()
        {

            var detailViewModel = service.GetDetails().Select(x => new DetailViewModel { Id = x.Id, CarId = x.CarId, Name = x.Name});

            return detailViewModel;
        }

        public DetailViewModel GetById(int id)
        {
            DetailModel detailModel = service.GetById(id);

            var detailViewModel = new DetailViewModel()
            {
                Id = detailModel.Id,
                CarId = detailModel.CarId,
                Name = detailModel.Name,
                Price = detailModel.Price
            };
            return detailViewModel;
        }

        public void Update(DetailViewModel detailViewModel)
        {
            DetailModel detailModel = new DetailModel
            {
                Id = detailViewModel.Id,
                CarId = detailViewModel.CarId,
                Name = detailViewModel.Name,
                Price = detailViewModel.Price

            };
            service.Update(detailModel);
        }
    }
}
