using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TredeWeb.DataLayer
{
    public partial class Barcodes
    {
        [Key]
        public int Id { get; set; }
        public int? PictureRef { get; set; }
        public int? ItemRef { get; set; }
        public int? OwnerRef { get; set; }
        public bool? IsActive { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        public int? LotId { get; set; }

        [ForeignKey(nameof(ItemRef))]
        [InverseProperty(nameof(Items.Barcodes))]
        public virtual Items ItemRefNavigation { get; set; }
        [ForeignKey(nameof(OwnerRef))]
        [InverseProperty(nameof(Users.Barcodes))]
        public virtual Users OwnerRefNavigation { get; set; }
        [ForeignKey(nameof(PictureRef))]
        [InverseProperty(nameof(Pictures.Barcodes))]
        public virtual Pictures PictureRefNavigation { get; set; }
    }
}
