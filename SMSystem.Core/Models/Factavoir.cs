using System;
using System.Collections.Generic;

#nullable disable

namespace SMSystem.Core.Models
{
    public partial class Factavoir
    {
        public int IdFactavoir { get; set; }
        public int IdFact { get; set; }
        public int? NumFat { get; set; }
        public int? IdClt { get; set; }
        public int? NumFactavr { get; set; }
        public DateTime? DateFactavr { get; set; }
        public string NatFactavr { get; set; }
        public string ObsvFactavr { get; set; }
        public int? TothtFactavr { get; set; }
        public int? TotvaFactavr { get; set; }
        public int? TottcFactavr { get; set; }
    }
}
