using System;
using System.Collections.Generic;

namespace web.Models
{
    public class Pridelek

    {
        public int PridelekId { get; set; }
        public int TrteId { get; set; }
        public int VinogradId { get; set; }
        public int Kolicina { get; set; }
        public decimal KolNaHa { get; set; }
        public decimal KgNaTrto { get; set; }
        public int letoMeritve { get; set; }

        public DateTime? DateCreated { get; set; }
        public DateTime? DateEdited { get; set; }
        public ApplicationUser? Owner { get; set; }
        public Trte Trte { get; set; }
        public Vinogradi Vinogradi { get; set; }
    }
}