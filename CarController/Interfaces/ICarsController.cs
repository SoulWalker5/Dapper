using PresentationLayer.ViewModels;
using System.Collections.Generic;

namespace PresentationLayer.Interfaces
{
    public interface ICarsController
    {
        IEnumerable<CarViewModel> GetСars();
    }
}
