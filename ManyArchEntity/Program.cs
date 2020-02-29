using PresentationLayer.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManyArchEntity
{
    class Program
    {
        static void Main(string[] args)
        {
            var carController = new CarsController();
            var detailController = new DetailsController();

            //var allCars = carController.GetAll();
            //var carById = carController.GetId(1);
            //var allDetails = detailController.GetAll();
            var detailById = detailController.GetId(1);
            //detailController.Insert(null);
            //detailController.Update(null);
            //detailController.Delete(9);

            
            //carController.Insert(null);
            //carController.Update(null);
            //carController.Delete(6);

            Console.ReadKey();
        }
    }
}
