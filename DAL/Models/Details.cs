﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Details
    {
        public int Id { get; set; }
        public string NameDetail { get; set; }
        public int Number { get; set; }
        public int CarId { get; set; }
        public Cars Cars { get; set; }
    }
}
