using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using TredeWeb.DataLayer;

namespace TredeWeb.Models
{
    public class Picture
    {
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

        //[ForeignKey(nameof(CategoryRef))]
        //[InverseProperty(nameof(Category.Pictures))]
        //public virtual Category CategoryRefNavigation { get; set; }
        [ForeignKey(nameof(ItemRef))]
        [InverseProperty(nameof(Items.Pictures))]
        public virtual Items ItemRefNavigation { get; set; }
        [ForeignKey(nameof(MarkRef))]
        [InverseProperty(nameof(Marks.Pictures))]
        public virtual Marks MarkRefNavigation { get; set; }

    }
}
