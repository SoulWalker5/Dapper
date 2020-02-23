using PresentationLayer;
using PresentationLayer.Controllers;
using PresentationLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4_4
{
     
    class Program
    {
        
        static void Main(string[] args)
        {
            ICarsController carsController = new CarsController();
            IDetailsController detailController = new DetailsController();

            var result = from resCar in carsController.GetСars()
                         join resDet in detailController.GetDetails()
                         on resCar.Id equals resDet.CarId
                         select new { CarName = resCar.Name, Car_Id = resCar.Id, DetailName = resDet.Name };
            foreach (var obj in result)
            {
                Console.WriteLine(obj);
            }
            Console.ReadKey();
        }
    }
}
