using System;
using System.Collections.Generic;

namespace web.Models
{
    public class Vinogradi

    {
        public int VinogradiId { get; set; }
        public int TrteId { get; set; }
        public int Povrsina { get; set; }
        public int StTrt { get; set; }
        public int letoMeritve { get; set; }

        public ICollection<Pridelek> Pridelek { get; set; }

        public Trte Trte { get; set; }
    }
}