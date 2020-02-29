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
    public class CarRepository : ICarDetailsRepository<Cars>
    {
        private readonly CarDetailsContext _ctx;

        public CarRepository()
        {
            _ctx = new CarDetailsContext();
        }


        public void Delete(int id)
        {
            var carDelete = GetId(id);
            _ctx.Carses.Remove(carDelete);
            _ctx.SaveChanges();
            //throw new NotImplementedException();
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
            return _ctx.Carses.AsNoTracking().ToList();
        }

            public Cars GetId(int id)
        {
            var cargetid = _ctx.Carses.Where(x => x.Id == id).FirstOrDefault();
            return cargetid;
            //throw new NotImplementedException();
        }

        public void Insert(Cars tmp)
        {
            _ctx.Carses.Add(tmp);
            _ctx.SaveChanges();

            //throw new NotImplementedException();
        }

        public void Update(Cars tmp)
        {
            var updatedCar = GetId(tmp.Id);
            updatedCar.Detailses = tmp.Detailses;

            _ctx.Entry(updatedCar);
            _ctx.SaveChanges();
            //throw new NotImplementedException();
        }
    }
}
