using System;
using System.Collections.Generic;
using SMSystem.Core.Models;

#nullable disable

namespace SMSystem.Core
{
    public partial class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public virtual List<ConscienceCard> conscienceCards { get; set; }
    }
}
