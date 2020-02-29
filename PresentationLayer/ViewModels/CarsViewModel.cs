using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PresentationLayer.ViewModels
{
    public class CarsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<DetailsViewModel> DetailsViewModel { get; set; }
    }
}
