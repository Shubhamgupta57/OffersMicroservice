using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OffersMicroservice.Models
{
    public class Like
    {
        [Required]
        public int OfferId { get; set; }
        [Required]
        public int EmpId { get; set; }
        [Required]
        public DateTime TimeStamp { get; set; }


    }
}

