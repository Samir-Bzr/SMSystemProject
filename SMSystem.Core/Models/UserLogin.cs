using System;
using System.Collections.Generic;

#nullable disable

namespace SMSystem.Core.Models
{
    public partial class UserLogin
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string PassWord { get; set; }
        public string Droit { get; set; }
        public DateTime? Date { get; set; }
    }
}
