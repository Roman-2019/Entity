using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PresentationLayer.Interfaces;
using PresentationLayer.ViewModels;
using BussinesLayer.Interfaces;
using BussinesLayer.Models;
using BussinesLayer.Services;

namespace PresentationLayer.Controllers
{
    public class CarsController : IDBController<CarsViewModel>
    {
        private readonly IDBService<CarsModel> _cardetailscontroller;
        public CarsController() 
        {
            _cardetailscontroller = new CarsService();
        }
        public void Delete(int id)
        {
            _cardetailscontroller.Delete(id);
        }

        public IEnumerable<CarsViewModel> GetAll()
        {
            var resultCarView = from car in _cardetailscontroller.GetAll()
                                select new CarsViewModel()
                                {
                                    Id = car.Id,
                                    Name = car.Name,
                                    DetailsViewModel = car.DetailsModel.Select(x => new DetailsViewModel
                                    {
                                        Id = x.Id,
                                        NameDetail = x.NameDetail,
                                        Number = x.Number,
                                        CarsId = x.CarsId
                                    })
                                };
            return resultCarView;
        }

        public CarsViewModel GetId(int id)
        {
            var car = _cardetailscontroller.GetId(id);
            var cars = new CarsViewModel
            {
                Id = car.Id,
                Name = car.Name,
                DetailsViewModel = car.DetailsModel.Select(x => new DetailsViewModel
                {
                    NameDetail = x.NameDetail,
                    Number = x.Number
                })
            };
            return cars;
        }

        public void Insert(CarsViewModel carsViewModel)
        {
            var addcar = new CarsModel
            {
                Name = "NewCar",
                DetailsModel = new List<DetailsModel>
                {
                    new DetailsModel
                    {
                        NameDetail = "Glass",
                        Number = 1234,
                        
                    }
                }
            };
            _cardetailscontroller.Insert(addcar);
        }

        public void Update(CarsViewModel carsViewModel)
        {
            var updatecar = new CarsModel
            {
                Id = 1,
                Name = "BestCar"
            };

            _cardetailscontroller.Update(updatecar);
        }
    }
}
