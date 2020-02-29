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
    public class DetailsController : IDBController<DetailsViewModel>
    {
        private readonly IDBService<DetailsModel> _cardetailscontroller;
        public DetailsController()
        {
            _cardetailscontroller = new DetailsService();
        }

        public void Delete(int id)
        {
            _cardetailscontroller.Delete(id);
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
                                    CarsId = detail.CarsId
                                };
            return resultDetailView;
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
        }

        public void Insert(DetailsViewModel detailsViewModel)
        {
            var adddetail = new DetailsModel
            {
                NameDetail = "NewDetail",
                Number=789,
                CarsId=1
            };
            _cardetailscontroller.Insert(adddetail);
        }

        public void Update(DetailsViewModel detailsViewModel)
        {
            var updatedetail = new DetailsModel
            {
                Id = 1,
                NameDetail = "BestDetail",
                Number = 8888
            };

            _cardetailscontroller.Update(updatedetail);
        }
    }
}
