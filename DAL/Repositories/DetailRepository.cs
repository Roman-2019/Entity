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
    public class DetailRepository : IDBRepository<Details>
    {
        private readonly CarDetailsContext _ctx;

        public DetailRepository()
        {
            _ctx = new CarDetailsContext();
        }


        public void Delete(int id)
        {
            var detail = GetId(id);
            _ctx.Details.Remove(detail);
            _ctx.SaveChanges();
        }

        public IEnumerable<Details> GetAll()
        {
            return _ctx.Details.AsNoTracking().ToList();
        }

        public Details GetId(int id)
        {
            var detail = _ctx.Details.FirstOrDefault(x => x.Id == id);
            return detail;
        }

        public void Insert(Details details)
        {
            _ctx.Details.Add(details);
            _ctx.SaveChanges();
        }

        public void Update(Details details)
        {
            var updateDetail = GetId(details.Id);
            updateDetail.NameDetail = details.NameDetail;
            updateDetail.Number = details.Number;

            _ctx.Entry(updateDetail);
            _ctx.SaveChanges();
        }
    }
}
