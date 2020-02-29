using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.Repositories
{
    public class CarRepository : IDBRepository<Cars>
    {
        private readonly CarDetailsContext _ctx;

        public CarRepository()
        {
            _ctx = new CarDetailsContext();
        }


        public void Delete(int id)
        {
            var carDelete = GetId(id);
            _ctx.Cars.Remove(carDelete);
            _ctx.SaveChanges();
        }

        public IEnumerable<Cars> GetAll()
        {
            //var result = new List<Cars>();

            //using (_ctx)
            //{
            //    foreach (Cars d in _ctx.Carses.Include(d => d.Detailses))
            //    {
            //        foreach (Details dt in d.Detailses)
            //        {
            //            result.Add(new Cars
            //            {
            //                Id = d.Id,
            //                Name = d.Name,
            //                Detailses = new List<Details>()
            //            });

            //        }

            //    }

            //    //throw new NotImplementedException();
            //}
            //return result;
            return _ctx.Cars.AsNoTracking().ToList();
        }

            public Cars GetId(int id)
        {
            var carGetId = _ctx.Cars.FirstOrDefault(x => x.Id == id);
            return carGetId;
        }

        public void Insert(Cars cars)
        {
            _ctx.Cars.Add(cars);
            _ctx.SaveChanges();
        }

        public void Update(Cars cars)
        {
            var updatedCar = GetId(cars.Id);
            updatedCar.Details = cars.Details;

            _ctx.Entry(updatedCar);
            _ctx.SaveChanges();
        }
    }
}
