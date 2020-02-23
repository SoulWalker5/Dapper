using BusinessLogicLayer.Interfaces;
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

        public IEnumerable<DetailViewModel> GetDetails()
        {

            var detailViewModel = service.GetDetails().Select(x => new DetailViewModel { Id = x.Id, CarId = x.CarId, Name = x.Name});

            return detailViewModel;
        }
    }
}
