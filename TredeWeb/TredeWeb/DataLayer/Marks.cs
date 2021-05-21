using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TredeWeb.DataLayer
{
    public partial class Marks
    {
        public Marks()
        {
            Items = new HashSet<Items>();
            Pictures = new HashSet<Pictures>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(24)]
        public string Code { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(400)]
        public string Description { get; set; }
        public byte[] Picture { get; set; }
        public int? Owner { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        public bool? IsActive { get; set; }

        [ForeignKey(nameof(Owner))]
        [InverseProperty(nameof(Users.Marks))]
        public virtual Users OwnerNavigation { get; set; }
        [InverseProperty("MarkNavigation")]
        public virtual ICollection<Items> Items { get; set; }
        [InverseProperty("MarkRefNavigation")]
        public virtual ICollection<Pictures> Pictures { get; set; }
    }
}
