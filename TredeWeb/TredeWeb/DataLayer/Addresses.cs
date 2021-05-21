using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TredeWeb.DataLayer
{
    public partial class Addresses
    {
        public Addresses()
        {
            Accounts = new HashSet<Accounts>();
            BankBranches = new HashSet<BankBranches>();
            Users = new HashSet<Users>();
        }

        [Key]
        public int Id { get; set; }
        public int? CityRef { get; set; }
        public int? CountryRef { get; set; }
        public int? TownRef { get; set; }
        public int? AddressType { get; set; }
        [StringLength(50)]
        public string DistrictName { get; set; }
        public bool? IsDefault { get; set; }
        [StringLength(24)]
        public string Number { get; set; }
        public int? OwnerRef { get; set; }
        [StringLength(50)]
        public string MainStreet { get; set; }
        [StringLength(200)]
        public string Street { get; set; }
        [StringLength(8)]
        public string PostCode { get; set; }
        public bool? IsCustomerAddress { get; set; }
        public bool? IsActive { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedUser { get; set; }
        public int? Location { get; set; }

        [ForeignKey(nameof(CityRef))]
        [InverseProperty(nameof(Cities.Addresses))]
        public virtual Cities CityRefNavigation { get; set; }
        [ForeignKey(nameof(CountryRef))]
        [InverseProperty(nameof(Countries.Addresses))]
        public virtual Countries CountryRefNavigation { get; set; }
        [ForeignKey(nameof(OwnerRef))]
        [InverseProperty("Addresses")]
        public virtual Users OwnerRefNavigation { get; set; }
        [ForeignKey(nameof(TownRef))]
        [InverseProperty(nameof(Towns.Addresses))]
        public virtual Towns TownRefNavigation { get; set; }
        [InverseProperty("AddressRefNavigation")]
        public virtual ICollection<Accounts> Accounts { get; set; }
        [InverseProperty("AddressRefNavigation")]
        public virtual ICollection<BankBranches> BankBranches { get; set; }
        [InverseProperty("AddressRefNavigation")]
        public virtual ICollection<Users> Users { get; set; }
    }
}
