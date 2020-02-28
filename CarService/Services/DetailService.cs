using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Repository;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogicLayer.Services
{
    public class DetailService : IDetailsService
    {
        IDetailsRepository repository = new DetailsRepository();

        public void Create(DetailModel detailModel)
        {
            Detail detail = new Detail
            {
                Id = detailModel.Id,
                CarId = detailModel.CarId,
                Name = detailModel.Name,
                Price = detailModel.Price

            };
            repository.Create(detail);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public IEnumerable<DetailModel> GetDetails()
        {

            var detailsModels = repository.GetDetails().Select(x => new DetailModel { Id = x.Id, CarId = x.CarId, Name = x.Name });
            return detailsModels;
        }

        public DetailModel GetById(int id)
        {
            Detail detail = repository.GetById(id);

            var detailModel = new DetailModel()
            {
                Id = detail.Id,
                CarId = detail.CarId,
                Name = detail.Name,
                Price = detail.Price
            };
            return detailModel;
        }

        public void Update(DetailModel detailModel)
        {
            Detail detail = new Detail
            {
                Id = detailModel.Id,
                CarId = detailModel.CarId,
                Name = detailModel.Name,
                Price = detailModel.Price

            };
            repository.Update(detail);
        }
    }
}
