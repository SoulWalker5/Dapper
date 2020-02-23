using PresentationLayer.ViewModels;
using System.Collections.Generic;

namespace PresentationLayer.Interfaces
{
    public interface IDetailsController
    {
        IEnumerable<DetailViewModel> GetDetails();
    }
}
