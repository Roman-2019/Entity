using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Models
{
    public class DetailsModel
    {
        public int Id { get; set; }
        public string NameDetail { get; set; }
        public int Number { get; set; }
        public int CarsId { get; set; }
        public CarsModel CarsModel { get; set; }
    }
}
