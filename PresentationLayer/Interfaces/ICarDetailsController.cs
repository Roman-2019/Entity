using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Interfaces
{
    public interface ICarDetailsController<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetId(int id);
        void Insert(T tmp);
        void Delete(int id);
        void Update(T tmp);
    }
}
