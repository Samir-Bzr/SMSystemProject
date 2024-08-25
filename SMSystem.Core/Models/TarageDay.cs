using System;
using System.Collections.Generic;

#nullable disable

namespace SMSystem.Core.Models
{
    public partial class TarageDay
    {
        public int IdDay { get; set; }
        public DateTime? DateGross { get; set; }
        public bool Valider { get; set; }
        public string ValiderPar { get; set; }
        public bool Cloturer { get; set; }
        public DateTime? DateCreation { get; set; }
    }
}
