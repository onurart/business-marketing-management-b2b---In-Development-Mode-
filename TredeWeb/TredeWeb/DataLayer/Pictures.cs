using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TredeWeb.DataLayer
{
    public partial class Pictures
    {
        public Pictures()
        {
            Barcodes = new HashSet<Barcodes>();
            Campaigns = new HashSet<Campaigns>();
        }

        [Key]
        public int Id { get; set; }
        public string DirectoryPath { get; set; }
        [StringLength(50)]
        public string FileName { get; set; }
        public int? ItemRef { get; set; }
        public int? MarkRef { get; set; }
        public int? CategoryRef { get; set; }
        public bool? IsActive { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [ForeignKey(nameof(CategoryRef))]
        [InverseProperty(nameof(Categories.Pictures))]
        public virtual Categories CategoryRefNavigation { get; set; }
        [ForeignKey(nameof(ItemRef))]
        [InverseProperty(nameof(Items.Pictures))]
        public virtual Items ItemRefNavigation { get; set; }
        [ForeignKey(nameof(MarkRef))]
        [InverseProperty(nameof(Marks.Pictures))]
        public virtual Marks MarkRefNavigation { get; set; }
        [InverseProperty("PictureRefNavigation")]
        public virtual ICollection<Barcodes> Barcodes { get; set; }
        [InverseProperty("PictureRefNavigation")]
        public virtual ICollection<Campaigns> Campaigns { get; set; }
    }
}
