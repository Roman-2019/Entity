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
    public class CarsService : ICarDetailsService<CarsModel>
    {
        private readonly ICarDetailsRepository<Cars> _carDetailsRepository;
        
        public CarsService() 
        {
            _carDetailsRepository = new CarRepository();
            
        }

        public void Delete(int id)
        {
            _carDetailsRepository.Delete(id);
            //throw new NotImplementedException();
        }

        public IEnumerable<CarsModel> GetAll()
        {
            var cars = from car in _carDetailsRepository.GetAll()
                            select new CarsModel()
                            {
                                Id = car.Id,
                                Name = car.Name,
                                Detailses = car.Detailses.Select(x => new DetailsModel
                                {
                                    Id = x.Id,
                                    NameDetail = x.NameDetail,
                                    Number = x.Number,
                                    CarId = x.CarId
                                })
                            };
            return cars;
            //throw new NotImplementedException();
        }

        public CarsModel GetId(int id)
        {
            var car = _carDetailsRepository.GetId(id);
            var cars = new CarsModel
            {
                Id = car.Id,
                Name = car.Name,
                Detailses = car.Detailses.Select(x => new DetailsModel
                {
                    NameDetail = x.NameDetail,
                    Number = x.Number,
                    Id = x.Id
                }).ToList()
            };
            return cars;
            //throw new NotImplementedException();
        }

        public void Insert(CarsModel tmp)
        {
            var car = new Cars 
            {
                Name=tmp.Name,
                Detailses=tmp.Detailses.Select(x=>new Details 
                {
                    NameDetail = x.NameDetail,
                    Number=x.Number,
                    CarId=x.CarId
                }).ToList()
            };
            _carDetailsRepository.Insert(car);
            //throw new NotImplementedException();
        }

        public void Update(CarsModel tmp)
        {
            var car = new Cars
            {
                Id = tmp.Id,
                Name = tmp.Name
            };
            car.Name = tmp.Name;
            _carDetailsRepository.Update(car);
            //throw new NotImplementedException();
        }
    }
}
