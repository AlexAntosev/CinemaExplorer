using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaExplorer.Models
{
    public class PriceModel
    {
        public Guid FilmId { get; set; } 

        public float Price { get; set; }
    }
}
