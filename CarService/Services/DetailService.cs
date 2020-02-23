using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repository;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogicLayer.Services
{
    public class DetailService : IDetailsService
    {
        IDetailsRepository repository = new DetailsRepository();
        public IEnumerable<DetailModel> GetDetails()
        {
            var detailsModels = from detail in repository.GetDetails()
                                select new DetailModel() { Id = detail.Id, CarId = detail.CarId, Name = detail.Name };
            return detailsModels;
        }
    }
}
