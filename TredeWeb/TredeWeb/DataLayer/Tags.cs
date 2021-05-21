using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TredeWeb.DataLayer
{
    public partial class Tags
    {
        public Tags()
        {
            ItemToTags = new HashSet<ItemToTags>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(24)]
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [InverseProperty("Tag")]
        public virtual ICollection<ItemToTags> ItemToTags { get; set; }
    }
}
