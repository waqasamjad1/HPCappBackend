using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HPCapp.Models
{
    public class ShipDetail
    {
        [Key]
        [Column(TypeName = "UNIQUEIDENTIFIER")]
        public Guid id { get; set; }

        [Column(TypeName="nvarchar(100)")]
        public string name { get; set; }

        [Column(TypeName = "decimal(7, 4)")]
        public decimal length { get; set; }

        [Column(TypeName = "decimal(7, 4)")]
        public decimal width { get; set; }

        [Column(TypeName = "nvarchar(15)")]
        public string code { get; set; }
    }
}
