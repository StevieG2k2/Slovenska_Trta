using System;
using System.Collections.Generic;

namespace web.Models
{
    public class Odkup

    {
        public int OdkupId { get; set; }
        public int PridelekId { get; set; }
        public int Kolicina { get; set; }
        public decimal CenaNaKg { get; set; }
        public int letoMeritve { get; set; }
    }
}