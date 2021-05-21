using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TredeWeb.DataLayer
{
    public partial class Countries
    {
        public Countries()
        {
            Addresses = new HashSet<Addresses>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(2)]
        public string BinaryCode { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(6)]
        public string PhoneCode { get; set; }
        [StringLength(3)]
        public string TripleCode { get; set; }
        public bool? IsActive { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [InverseProperty("CountryRefNavigation")]
        public virtual ICollection<Addresses> Addresses { get; set; }
    }
}
