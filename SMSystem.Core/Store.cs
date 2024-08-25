using System;
using System.Collections.Generic;

#nullable disable

namespace SMSystem.Core
{
    public partial class Store
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<Materails> Materails { get; set; }
    }
}
