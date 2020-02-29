using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinesLayer.Interfaces;
using BussinesLayer.Models;
using DAL.Interfaces;
using DAL.Models;
using DAL.Repositories;

namespace BussinesLayer.Services
{
    public class DetailsService : IDBService<DetailsModel>
    {
        private readonly IDBRepository<Details> _carDetailsRepository;
        private readonly IDBRepository<Cars> carDetailsRepository;
        public DetailsService()
        {
            _carDetailsRepository = new DetailRepository();
            carDetailsRepository = new CarRepository();
        }

        public void Delete(int id)
        {
            _carDetailsRepository.Delete(id);
        }

        public IEnumerable<DetailsModel> GetAll()
        {
            var details = from detail in _carDetailsRepository.GetAll()
                       select new DetailsModel()
                       {
                           Id = detail.Id,
                           NameDetail = detail.NameDetail,
                           Number = detail.Number,
                           CarsModel =  new CarsModel
                           {
                               Id = detail.Cars.Id,
                               Name = detail.Cars.Name
                           },
                               CarsId = detail.CarsId
                           
                       };
            return details.ToList();
        }

        public DetailsModel GetId(int id)
        {
            var detail = _carDetailsRepository.GetId(id);

            var details = new DetailsModel
            {
                Id = detail.Id,
                NameDetail = detail.NameDetail,
                Number = detail.Number,
                CarsModel = new CarsModel
                {
                    Id = detail.Cars.Id,
                    Name = detail.Cars.Name,
                }
            };
            return details;
        }

        public void Insert(DetailsModel detailsModel)
        {
            var car = carDetailsRepository.GetAll().Where(x => x.Id == detailsModel.CarsId).FirstOrDefault();
            var detail = new Details
            {
                NameDetail = detailsModel.NameDetail,
                Number = detailsModel.Number,
                CarsId = detailsModel.CarsId
            };

            _carDetailsRepository.Insert(detail);
        }

        public void Update(DetailsModel detailsModel)
        {
            var detail = new Details
            {
                Id = detailsModel.Id,
                NameDetail = detailsModel.NameDetail,
                Number = detailsModel.Number
            };
            _carDetailsRepository.Update(detail);
        }
    }
}
