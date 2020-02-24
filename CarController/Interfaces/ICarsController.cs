using PresentationLayer.ViewModels;
using System.Collections.Generic;

namespace PresentationLayer.Interfaces
{
    public interface ICarsController
    {
        IEnumerable<CarViewModel> GetСars();
        void Create(CarViewModel carViewModel);
        void Delete(CarViewModel carViewModel);
        void Update(CarViewModel carViewModel);
        CarViewModel GetById(int id);
        //IEnumerable<DetailViewModel> Details();

    }
}
