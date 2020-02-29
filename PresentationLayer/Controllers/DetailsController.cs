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
    public class DetailsController : ICarDetailsController<DetailsViewModel>
    {
        private readonly ICarDetailsService<DetailsModel> _cardetailscontroller;
        public DetailsController()
        {
            _cardetailscontroller = new DetailsService();
        }

        public void Delete(int id)
        {
            _cardetailscontroller.Delete(id);
            //throw new NotImplementedException();
        }

        public IEnumerable<DetailsViewModel> GetAll()
        {
            var resultDetailView = from detail in _cardetailscontroller.GetAll()
                                select new DetailsViewModel()
                                {
                                    //Id = car.Id,
                                    NameDetail = detail.NameDetail,
                                    Number = detail.Number,
                                    CarsViewModel = new CarsViewModel
                                    {
                                        Id = detail.CarsModel.Id,
                                        Name = detail.CarsModel.Name,
                                    },
                                    CarId = detail.CarId
                                };
            return resultDetailView;
            //throw new NotImplementedException();
        }

        public DetailsViewModel GetId(int id)
        {
            var detail = _cardetailscontroller.GetId(id);

            var details = new DetailsViewModel
            {
                Id = detail.Id,
                NameDetail = detail.NameDetail,
                Number = detail.Number,
                CarsViewModel = new CarsViewModel
                {
                    Id = detail.CarsModel.Id,
                    Name = detail.CarsModel.Name,
                }
            };
            return details;
            //throw new NotImplementedException();
        }

        public void Insert(DetailsViewModel tmp)
        {
            var adddetail = new DetailsModel
            {
                NameDetail = "NewDetail",
                Number=789,
                CarId=4
            };
            _cardetailscontroller.Insert(adddetail);
            //throw new NotImplementedException();
        }

        public void Update(DetailsViewModel tmp)
        {
            var updatedetail = new DetailsModel
            {
                Id = 1,
                NameDetail = "BestDetail",
                Number = 8888
            };

            _cardetailscontroller.Update(updatedetail);
            //throw new NotImplementedException();
        }
    }
}
