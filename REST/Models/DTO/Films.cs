using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrjWebApi01.Models.DTO
{
    public class FilmsDTO
    {
        public decimal IdFilm { get; set; }
        public decimal? IdProducer { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Section { get; set; }
        public string Genre { get; set; }
        public int? Year { get; set; }
        public string Publisher { get; set; }

        public virtual ProducersDTO Producer { get; set; }
    }
}
