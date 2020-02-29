using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Models
{
    public class CarsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<DetailsModel> DetailsModel { get; set; }
    }
}
