using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TredeWeb.Models
{
    public class Town
    {
        public Town()
        {
            Addresses = new HashSet<Address>();
        }

        [Key]
        public int Id { get; set; }
        public int? City { get; set; }
        [StringLength(100)]
        public string TownName { get; set; }
        public int? Owner { get; set; }
        public bool? IsActive { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [InverseProperty("TownRefNavigation")]
        public virtual ICollection<Address> Addresses { get; set; }

    }
}
