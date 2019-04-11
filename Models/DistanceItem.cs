using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GIS_API.Models
{
    public class DistanceItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long Name { get; set; }
        public decimal CLongitude {get; set;}
        public decimal CLatitude {get; set;}
        public decimal LLongitude {get; set;}
        public decimal LLatitude {get; set;}
        public decimal Distancebetween {get; set;}

    }
}