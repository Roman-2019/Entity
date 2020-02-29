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
    public class CarsController : ICarDetailsController<CarsViewModel>
    {
        private readonly ICarDetailsService<CarsModel> _cardetailscontroller;
        public CarsController() 
        {
            _cardetailscontroller = new CarsService();
        }
        public void Delete(int id)
        {
            _cardetailscontroller.Delete(id);
            //throw new NotImplementedException();
        }

        public IEnumerable<CarsViewModel> GetAll()
        {
            var resultCarView = from car in _cardetailscontroller.GetAll()
                                select new CarsViewModel()
                                {
                                    Id = car.Id,
                                    Name = car.Name,
                                    Detailses = car.Detailses.Select(x => new DetailsViewModel
                                    {
                                        Id = x.Id,
                                        NameDetail = x.NameDetail,
                                        Number = x.Number,
                                        CarId = x.CarId
                                    })
                                };
            return resultCarView;
            //throw new NotImplementedException();
        }

        public CarsViewModel GetId(int id)
        {
            var car = _cardetailscontroller.GetId(id);
            var cars = new CarsViewModel
            {
                Id = car.Id,
                Name = car.Name,
                Detailses = car.Detailses.Select(x => new DetailsViewModel
                {
                    NameDetail = x.NameDetail,
                    Number = x.Number
                })
            };
            return cars;
           // throw new NotImplementedException();
        }

        public void Insert(CarsViewModel tmp)
        {
            var addcar = new CarsModel
            {
                Name = "NewCar",
                Detailses = new List<DetailsModel>
                {
                    new DetailsModel
                    {
                        NameDetail = "Mirror",
                        Number = 1234,
                    }
                }
            };
            _cardetailscontroller.Insert(addcar);
            //throw new NotImplementedException();
        }

        public void Update(CarsViewModel tmp)
        {
            var updatecar = new CarsModel
            {
                Id = 1,
                Name = "BestCar"
            };

            _cardetailscontroller.Update(updatecar);
            //throw new NotImplementedException();
        }
    }
}
