using System.Collections.Generic;

namespace PresentationLayer.ViewModels
{
    public class CarViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<DetailViewModel> Parts { get; set; }
    }
}
