using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.ViewModels
{
    public class DetailsViewModel
    {
        public int Id { get; set; }
        public string NameDetail { get; set; }
        public int Number { get; set; }
        public int CarsId { get; set; }
        public CarsViewModel CarsViewModel { get; set; }
    }
}
