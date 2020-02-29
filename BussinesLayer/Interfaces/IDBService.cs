using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Interfaces
{
    public interface IDBService<T> where T:class
    {
        IEnumerable<T> GetAll();
        T GetId(int id);
        void Insert(T model);
        void Delete(int id);
        void Update(T model);
    }
}
