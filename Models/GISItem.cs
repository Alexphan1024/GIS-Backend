using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GIS_API.Models
{
    public class GISItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }        
        public string Name { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Timestamp {get; set;}
        public decimal Longitude {get; set;}
        public decimal Latitude {get; set;}

    }
}