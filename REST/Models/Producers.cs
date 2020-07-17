using System;
using System.Collections.Generic;

namespace PrjWebApi01.Models
{
    public partial class Producers
    {
        public Producers()
        {
            Films = new HashSet<Films>();
        }

        public decimal IdProducer { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Films> Films { get; set; }
    }
}
