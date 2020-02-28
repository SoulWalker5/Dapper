using DataAccessLayer.Repository;
using PresentationLayer.Controllers;
using PresentationLayer.Interfaces;
using PresentationLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lesson4_4
{
     
    class Program
    {
        static void Main(string[] args)
        {
            var carsController = new CarsController();
            var detailController = new DetailsController();
            
            var vehicles = carsController.GetСars();

        }
    }
}
