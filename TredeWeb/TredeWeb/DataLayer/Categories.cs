using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TredeWeb.DataLayer
{
    public partial class Categories
    {
        public Categories()
        {
            InverseParentCategoryNavigation = new HashSet<Categories>();
            ItemToCategories = new HashSet<ItemToCategories>();
            Pictures = new HashSet<Pictures>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(100)]
        public string Code { get; set; }
        public string Description { get; set; }
        public int? OwnerRef { get; set; }
        public int? ParentCategory { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        public bool? IsActive { get; set; }

        [ForeignKey(nameof(OwnerRef))]
        [InverseProperty(nameof(Users.Categories))]
        public virtual Users OwnerRefNavigation { get; set; }
        [ForeignKey(nameof(ParentCategory))]
        [InverseProperty(nameof(Categories.InverseParentCategoryNavigation))]
        public virtual Categories ParentCategoryNavigation { get; set; }
        [InverseProperty(nameof(Categories.ParentCategoryNavigation))]
        public virtual ICollection<Categories> InverseParentCategoryNavigation { get; set; }
        [InverseProperty("Category")]
        public virtual ICollection<ItemToCategories> ItemToCategories { get; set; }
        [InverseProperty("CategoryRefNavigation")]
        public virtual ICollection<Pictures> Pictures { get; set; }
    }
}
