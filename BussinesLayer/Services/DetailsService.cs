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
    public class DetailsService : ICarDetailsService<DetailsModel>
    {
        private readonly ICarDetailsRepository<Details> _carDetailsRepository;
        private readonly ICarDetailsRepository<Cars> carDetailsRepository;
        public DetailsService()
        {
            _carDetailsRepository = new DetailRepository();
            carDetailsRepository = new CarRepository();
        }

        public void Delete(int id)
        {
            _carDetailsRepository.Delete(id);
            //throw new NotImplementedException();
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
                               CarId = detail.CarId
                           
                       };
            return details.ToList();
            //throw new NotImplementedException();
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
            //throw new NotImplementedException();
        }

        public void Insert(DetailsModel tmp)
        {
            var car = carDetailsRepository.GetAll().Where(x => x.Id == tmp.CarId).FirstOrDefault();
            var detail = new Details
            {
                NameDetail = tmp.NameDetail,
                Number = tmp.Number,
                CarId = tmp.CarId
            };

            _carDetailsRepository.Insert(detail);
            //throw new NotImplementedException();
        }

        public void Update(DetailsModel tmp)
        {
            var detail = new Details
            {
                Id = tmp.Id,
                NameDetail = tmp.NameDetail,
                Number = tmp.Number
            };
            _carDetailsRepository.Update(detail);
            //throw new NotImplementedException();
        }
    }
}
