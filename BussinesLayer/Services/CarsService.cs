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
    public class CarsService : IDBService<CarsModel>
    {
        private readonly IDBRepository<Cars> _carDetailsRepository;
        
        public CarsService() 
        {
            _carDetailsRepository = new CarRepository();
            
        }

        public void Delete(int id)
        {
            _carDetailsRepository.Delete(id);
        }

        public IEnumerable<CarsModel> GetAll()
        {
            var cars = from car in _carDetailsRepository.GetAll()
                            select new CarsModel()
                            {
                                Id = car.Id,
                                Name = car.Name,
                                DetailsModel = car.Details.Select(x => new DetailsModel
                                {
                                    Id = x.Id,
                                    NameDetail = x.NameDetail,
                                    Number = x.Number,
                                    CarsId = x.CarsId
                                })
                            };
            return cars;
        }

        public CarsModel GetId(int id)
        {
            var car = _carDetailsRepository.GetId(id);
            var cars = new CarsModel
            {
                Id = car.Id,
                Name = car.Name,
                DetailsModel = car.Details.Select(x => new DetailsModel
                {
                    NameDetail = x.NameDetail,
                    Number = x.Number,
                    Id = x.Id
                }).ToList()
            };
            return cars;
        }

        public void Insert(CarsModel carsModel)
        {
            var car = new Cars 
            {
                Name= carsModel.Name,
                Details= carsModel.DetailsModel.Select(x=>new Details 
                {
                    NameDetail = x.NameDetail,
                    Number=x.Number,
                    CarsId=x.CarsId
                }).ToList()
            };
            _carDetailsRepository.Insert(car);
        }

        public void Update(CarsModel carsModel)
        {
            var car = new Cars
            {
                Id = carsModel.Id,
                Name = carsModel.Name
            };
            car.Name = carsModel.Name;
            _carDetailsRepository.Update(car);
        }
    }
}
