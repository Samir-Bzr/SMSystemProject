using System;
using System.Collections.Generic;

#nullable disable

namespace SMSystem.Core.Models
{
    public partial class Devi
    {
        public int IdDevis { get; set; }
        public int? NumDevis { get; set; }
        public int? IdClt { get; set; }
        public DateTime? DateDevis { get; set; }
        public string ObsvDevis { get; set; }
        public int? TothtDevis { get; set; }
        public int? TotvaDevis { get; set; }
        public int? TottcDevis { get; set; }
    }
}
