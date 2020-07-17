using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrjWebApi01.Models
{
    public partial class Films
    {
        public decimal IdFilm { get; set; }
        public decimal? IdProducer { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Section { get; set; }
        public string Genre { get; set; }
        public int? Year { get; set; }
        public string Publisher { get; set; }

        public virtual Producers IdProducerNavigation { get; set; }
    }
}
