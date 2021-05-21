using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using TredeWeb.DataLayer;

namespace TredeWeb.Models
{
    public class Citie
    {
        public Citie()
        {
            Addresses = new HashSet<Addresses>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public int? PhoneCode { get; set; }
        public byte? Plate { get; set; }
        public int? Country { get; set; }
        public bool? IsActive { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [InverseProperty("CityRefNavigation")]
        public virtual ICollection<Addresses> Addresses { get; set; }

    }
}
