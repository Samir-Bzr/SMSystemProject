using System;
using System.Collections.Generic;

#nullable disable

namespace SMSystem.Core.Models
{
    public partial class Tarage
    {
        public int GrossId { get; set; }
        public string MachineId { get; set; }
        public DateTime? DateGross { get; set; }
        public string ObsvPesage { get; set; }
        public bool Valider { get; set; }
        public string SaisiePar { get; set; }
        public string ValiderPar { get; set; }
        public bool Cloturer { get; set; }
        public DateTime? DateCreation { get; set; }
    }
}
