using System;
using System.Collections.Generic;

namespace PrjWebApi01.Models.DTO
{
    public class ProducersDTO
    {
        public decimal IdProducer { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public virtual ICollection<FilmsDTO> Films { get; set; }
    }
}
