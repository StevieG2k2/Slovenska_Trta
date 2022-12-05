using System;
using System.Collections.Generic;

namespace web.Models
{

    public class Trte

    {
        public int TrteId { get; set; }
        public string Sorta { get; set; }

        public ICollection<Vinogradi> Vinogradi { get; set; }
        public ICollection<Pridelek> Pridelek { get; set; }
    }
}