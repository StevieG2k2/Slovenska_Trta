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

        public DateTime? DateCreated { get; set; }
        public DateTime? DateEdited { get; set; }
        public ApplicationUser? Owner { get; set; }
    }
}