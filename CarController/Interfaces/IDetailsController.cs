using PresentationLayer.ViewModels;
using System.Collections.Generic;

namespace PresentationLayer.Interfaces
{
    public interface IDetailsController
    {
        IEnumerable<DetailViewModel> GetDetails();
        void Create(DetailViewModel detailViewModel);
        void Delete(int id);
        void Update(DetailViewModel detailViewModel);
        DetailViewModel GetById(int id);
    }
}
