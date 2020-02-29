using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using DAL.Interfaces;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Data.Entity.SqlServer;

namespace DAL.Repositories
{
    public class DetailRepository : ICarDetailsRepository<Details>
    {
        private readonly CarDetailsContext _ctx;

        public DetailRepository()
        {
            _ctx = new CarDetailsContext();
        }


        public void Delete(int id)
        {
            var detail = GetId(id);
            _ctx.Detailses.Remove(detail);
            _ctx.SaveChanges();
            //throw new NotImplementedException();
        }

        public IEnumerable<Details> GetAll()
        {
            return _ctx.Detailses.AsNoTracking().ToList();
            //throw new NotImplementedException();
        }

        public Details GetId(int id)
        {
            var detail = _ctx.Detailses.FirstOrDefault(x => x.Id == id);
            return detail;
           // throw new NotImplementedException();
        }

        public void Insert(Details tmp)
        {
            _ctx.Detailses.Add(tmp);
            _ctx.SaveChanges();
            //throw new NotImplementedException();
        }

        public void Update(Details tmp)
        {
            var updateDetail = GetId(tmp.Id);
            updateDetail.NameDetail = tmp.NameDetail;
            updateDetail.Number = tmp.Number;

            _ctx.Entry(updateDetail);
            _ctx.SaveChanges();
            //throw new NotImplementedException();
        }
    }
}
