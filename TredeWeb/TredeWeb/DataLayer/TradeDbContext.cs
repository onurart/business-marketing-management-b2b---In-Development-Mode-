using Microsoft.EntityFrameworkCore;
using System;

namespace TredeWeb.DataLayer
{
    public partial class TradeDbContext : DbContext
    {
        public TradeDbContext()
        {
        }

        public TradeDbContext(DbContextOptions<TradeDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Accounts> Accounts { get; set; }
        public virtual DbSet<Addresses> Addresses { get; set; }
        public virtual DbSet<BankAccounts> BankAccounts { get; set; }
        public virtual DbSet<BankBranches> BankBranches { get; set; }
        public virtual DbSet<BankCards> BankCards { get; set; }
        public virtual DbSet<Barcodes> Barcodes { get; set; }
        public virtual DbSet<CampaignLines> CampaignLines { get; set; }
        public virtual DbSet<CampaignToAccounts> CampaignToAccounts { get; set; }
        public virtual DbSet<CampaignToItems> CampaignToItems { get; set; }
        public virtual DbSet<Campaigns> Campaigns { get; set; }
        public virtual DbSet<CashCards> CashCards { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Cities> Cities { get; set; }
        public virtual DbSet<Costs> Costs { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<CouponCodes> CouponCodes { get; set; }
        public virtual DbSet<Currencies> Currencies { get; set; }
        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<FnBankFiches> FnBankFiches { get; set; }
        public virtual DbSet<FnBankLines> FnBankLines { get; set; }
        public virtual DbSet<FnBarterFiches> FnBarterFiches { get; set; }
        public virtual DbSet<FnBarterLines> FnBarterLines { get; set; }
        public virtual DbSet<FnCashFiches> FnCashFiches { get; set; }
        public virtual DbSet<FnCashLines> FnCashLines { get; set; }
        public virtual DbSet<FnCreditCardFiches> FnCreditCardFiches { get; set; }
        public virtual DbSet<FnCreditCardLines> FnCreditCardLines { get; set; }
        public virtual DbSet<FnCsFiches> FnCsFiches { get; set; }
        public virtual DbSet<FnCsLines> FnCsLines { get; set; }
        public virtual DbSet<FnFicheLines> FnFicheLines { get; set; }
        public virtual DbSet<FnFiches> FnFiches { get; set; }
        public virtual DbSet<Inventories> Inventories { get; set; }
        public virtual DbSet<InventoryLines> InventoryLines { get; set; }
        public virtual DbSet<ItemToCategories> ItemToCategories { get; set; }
        public virtual DbSet<ItemToTags> ItemToTags { get; set; }
        public virtual DbSet<ItemToVariants> ItemToVariants { get; set; }
        public virtual DbSet<ItemToWareHouses> ItemToWareHouses { get; set; }
        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<Logs> Logs { get; set; }
        public virtual DbSet<Marks> Marks { get; set; }
        public virtual DbSet<OrderLines> OrderLines { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<PaymentTypes> PaymentTypes { get; set; }
        public virtual DbSet<Pictures> Pictures { get; set; }
        public virtual DbSet<Positions> Positions { get; set; }
        public virtual DbSet<PriceLists> PriceLists { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Sections> Sections { get; set; }
        public virtual DbSet<Tags> Tags { get; set; }
        public virtual DbSet<Towns> Towns { get; set; }
        public virtual DbSet<UnitLines> UnitLines { get; set; }
        public virtual DbSet<Units> Units { get; set; }
        public virtual DbSet<UserToRoles> UserToRoles { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Variants> Variants { get; set; }
        public virtual DbSet<WareHouses> WareHouses { get; set; }
        public virtual DbSet<WorkPlaces> WorkPlaces { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //            if (!optionsBuilder.IsConfigured)
            //            {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            //                optionsBuilder.UseSqlServer("Data Source=185.50.69.43;Initial Catalog=TradeDb;User Id=sa;Password=1qaz2wsx_?=;");
            //            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accounts>(entity =>
            {
                entity.HasOne(d => d.AddressRefNavigation)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.AddressRef)
                    .HasConstraintName("FK_Accounts_Addresses_Id");

                entity.HasOne(d => d.ParentAccountNavigation)
                    .WithMany(p => p.InverseParentAccountNavigation)
                    .HasForeignKey(d => d.ParentAccount)
                    .HasConstraintName("FK_Accounts_Accounts_Id");

                entity.HasOne(d => d.UserRefNavigation)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.UserRef)
                    .HasConstraintName("FK_Accounts_Users_Id");
            });

            modelBuilder.Entity<Addresses>(entity =>
            {
                entity.HasOne(d => d.CityRefNavigation)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.CityRef)
                    .HasConstraintName("FK_Addresses_Cities_Id");

                entity.HasOne(d => d.CountryRefNavigation)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.CountryRef)
                    .HasConstraintName("FK_Addresses_Countries_Id");

                entity.HasOne(d => d.OwnerRefNavigation)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.OwnerRef)
                    .HasConstraintName("FK_Addresses_Users_Id");

                entity.HasOne(d => d.TownRefNavigation)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.TownRef)
                    .HasConstraintName("FK_Addresses_Towns_Id");
            });

            modelBuilder.Entity<BankAccounts>(entity =>
            {
                entity.HasOne(d => d.BankBranchNavigation)
                    .WithMany(p => p.BankAccounts)
                    .HasForeignKey(d => d.BankBranch)
                    .HasConstraintName("FK_BankAccounts_BankBranches_Id");

                entity.HasOne(d => d.OwnerRefNavigation)
                    .WithMany(p => p.BankAccounts)
                    .HasForeignKey(d => d.OwnerRef)
                    .HasConstraintName("FK_BankAccounts_Users_Id");
            });

            modelBuilder.Entity<BankBranches>(entity =>
            {
                entity.HasOne(d => d.AddressRefNavigation)
                    .WithMany(p => p.BankBranches)
                    .HasForeignKey(d => d.AddressRef)
                    .HasConstraintName("FK_BankBranches_Addresses_Id");

                entity.HasOne(d => d.BankCardRefNavigation)
                    .WithMany(p => p.BankBranches)
                    .HasForeignKey(d => d.BankCardRef)
                    .HasConstraintName("FK_BankBranches_BankCards_Id");

                entity.HasOne(d => d.OwnerRefNavigation)
                    .WithMany(p => p.BankBranches)
                    .HasForeignKey(d => d.OwnerRef)
                    .HasConstraintName("FK_BankBranches_Users_Id");
            });

            modelBuilder.Entity<BankCards>(entity =>
            {
                entity.HasOne(d => d.OwnerRefNavigation)
                    .WithMany(p => p.BankCards)
                    .HasForeignKey(d => d.OwnerRef)
                    .HasConstraintName("FK_BankCards_Users_Id");
            });

            modelBuilder.Entity<Barcodes>(entity =>
            {
                entity.HasIndex(e => e.ItemRef)
                    .HasName("iItem_ET_001_Barcodes");

                entity.HasIndex(e => e.OwnerRef)
                    .HasName("iOwner_ET_001_Barcodes");

                entity.HasIndex(e => e.PictureRef)
                    .HasName("iBarcodeImage_ET_001_Barcodes");

                entity.HasOne(d => d.ItemRefNavigation)
                    .WithMany(p => p.Barcodes)
                    .HasForeignKey(d => d.ItemRef)
                    .HasConstraintName("FK_Barcodes_Items_Id");

                entity.HasOne(d => d.OwnerRefNavigation)
                    .WithMany(p => p.Barcodes)
                    .HasForeignKey(d => d.OwnerRef)
                    .HasConstraintName("FK_Barcodes_Users_Id");

                entity.HasOne(d => d.PictureRefNavigation)
                    .WithMany(p => p.Barcodes)
                    .HasForeignKey(d => d.PictureRef)
                    .HasConstraintName("FK_Barcodes_Pictures_Id");
            });

            modelBuilder.Entity<CampaignLines>(entity =>
            {
                entity.HasOne(d => d.AccountRefNavigation)
                    .WithMany(p => p.CampaignLines)
                    .HasForeignKey(d => d.AccountRef)
                    .HasConstraintName("FK_CampaignLines_Accounts_Id");

                entity.HasOne(d => d.CampaignRefNavigation)
                    .WithMany(p => p.CampaignLines)
                    .HasForeignKey(d => d.CampaignRef)
                    .HasConstraintName("FK_CampaignLines_Campaigns_Id");

                entity.HasOne(d => d.ItemRefNavigation)
                    .WithMany(p => p.CampaignLines)
                    .HasForeignKey(d => d.ItemRef)
                    .HasConstraintName("FK_CampaignLines_Items_Id");
            });

            modelBuilder.Entity<CampaignToAccounts>(entity =>
            {
                entity.HasKey(e => new { e.AccountId, e.CampaignId });

                entity.HasIndex(e => e.AccountId)
                    .HasName("iAccounts_ET_001_CampaignsCampaigns_ET_001_AccountsAccounts");

                entity.HasIndex(e => e.CampaignId)
                    .HasName("iCampaigns_ET_001_CampaignsCampaigns_ET_001_AccountsAccounts");

                entity.HasIndex(e => new { e.AccountId, e.CampaignId })
                    .HasName("iAccountsCampaigns_ET_001_CampaignsCampaigns_ET_001_AccountsAccounts")
                    .IsUnique();

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.CampaignToAccounts)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CampaignToAccounts_Accounts_Id");

                entity.HasOne(d => d.Campaign)
                    .WithMany(p => p.CampaignToAccounts)
                    .HasForeignKey(d => d.CampaignId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CampaignToAccounts_Campaigns_Id");
            });

            modelBuilder.Entity<CampaignToItems>(entity =>
            {
                entity.HasKey(e => new { e.CampaignId, e.ItemId });

                entity.HasOne(d => d.Campaign)
                    .WithMany(p => p.CampaignToItems)
                    .HasForeignKey(d => d.CampaignId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CampaignToItems_Campaigns_Id");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.CampaignToItems)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CampaignToItems");
            });

            modelBuilder.Entity<Campaigns>(entity =>
            {
                entity.HasOne(d => d.OwnerRefNavigation)
                    .WithMany(p => p.Campaigns)
                    .HasForeignKey(d => d.OwnerRef)
                    .HasConstraintName("FK_Campaigns_Users_Id");

                entity.HasOne(d => d.PictureRefNavigation)
                    .WithMany(p => p.Campaigns)
                    .HasForeignKey(d => d.PictureRef)
                    .HasConstraintName("FK_Campaigns_Pictures_Id");
            });

            modelBuilder.Entity<CashCards>(entity =>
            {
                entity.HasIndex(e => e.AccountRef)
                    .HasName("iAccountRef_ET_001_CashCards");

                entity.HasIndex(e => e.OwnerRef)
                    .HasName("iOwner_ET_001_CashCards");

                entity.HasIndex(e => e.ParentCard)
                    .HasName("iParentCard_ET_001_CashCards");

                entity.HasOne(d => d.AccountRefNavigation)
                    .WithMany(p => p.CashCards)
                    .HasForeignKey(d => d.AccountRef)
                    .HasConstraintName("FK_CashCards_Accounts_Id");

                entity.HasOne(d => d.OwnerRefNavigation)
                    .WithMany(p => p.CashCards)
                    .HasForeignKey(d => d.OwnerRef)
                    .HasConstraintName("FK_CashCards_Users_Id");

                entity.HasOne(d => d.ParentCardNavigation)
                    .WithMany(p => p.InverseParentCardNavigation)
                    .HasForeignKey(d => d.ParentCard)
                    .HasConstraintName("FK_CashCards_CashCards_Id");
            });

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasIndex(e => e.OwnerRef)
                    .HasName("iOwner_ET_001_Categories");

                entity.HasIndex(e => e.ParentCategory)
                    .HasName("iParentCategory_ET_001_Categories");

                entity.HasOne(d => d.OwnerRefNavigation)
                    .WithMany(p => p.Categories)
                    .HasForeignKey(d => d.OwnerRef)
                    .HasConstraintName("FK_Categories_Users_Id");

                entity.HasOne(d => d.ParentCategoryNavigation)
                    .WithMany(p => p.InverseParentCategoryNavigation)
                    .HasForeignKey(d => d.ParentCategory)
                    .HasConstraintName("FK_Categories_Categories_Id");
            });

            modelBuilder.Entity<Cities>(entity =>
            {
                entity.HasIndex(e => e.Country)
                    .HasName("iCountry_ET_001_Cities");
            });

            modelBuilder.Entity<Costs>(entity =>
            {
                entity.HasIndex(e => e.AccountRef)
                    .HasName("iAccountRef_ET_001_Costs");

                entity.HasIndex(e => e.BankRef)
                    .HasName("iBankRef_ET_001_Costs");

                entity.HasIndex(e => e.CashRef)
                    .HasName("iCashRef_ET_001_Costs");

                entity.HasIndex(e => e.CsRef)
                    .HasName("iCsRef_ET_001_Costs");

                entity.HasIndex(e => e.OwnerRef)
                    .HasName("iOwner_ET_001_Costs");

                entity.HasOne(d => d.AccountRefNavigation)
                    .WithMany(p => p.Costs)
                    .HasForeignKey(d => d.AccountRef)
                    .HasConstraintName("FK_Costs_Accounts_Id");

                entity.HasOne(d => d.BankRefNavigation)
                    .WithMany(p => p.Costs)
                    .HasForeignKey(d => d.BankRef)
                    .HasConstraintName("FK_Costs_FnBankLines_Id");

                entity.HasOne(d => d.CreditCardRefNavigation)
                    .WithMany(p => p.Costs)
                    .HasForeignKey(d => d.CreditCardRef)
                    .HasConstraintName("FK_Costs_FnCreditCardLines_Id");

                entity.HasOne(d => d.CsRefNavigation)
                    .WithMany(p => p.Costs)
                    .HasForeignKey(d => d.CsRef)
                    .HasConstraintName("FK_Costs_FnCsLines_Id");

                entity.HasOne(d => d.OwnerRefNavigation)
                    .WithMany(p => p.Costs)
                    .HasForeignKey(d => d.OwnerRef)
                    .HasConstraintName("FK_Costs_Users_Id");
            });

            modelBuilder.Entity<CouponCodes>(entity =>
            {
                entity.HasIndex(e => e.OwnerRef)
                    .HasName("iOwner_ET_001_CouponCodes");

                entity.HasOne(d => d.OwnerRefNavigation)
                    .WithMany(p => p.CouponCodes)
                    .HasForeignKey(d => d.OwnerRef)
                    .HasConstraintName("FK_CouponCodes_Users_Id");
            });

            modelBuilder.Entity<Currencies>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Departments>(entity =>
            {
                entity.HasIndex(e => e.OwnerRef)
                    .HasName("iOwner_ET_001_Departments");

                entity.HasIndex(e => e.ParentDepartment)
                    .HasName("iParentDepartment_ET_001_Departments");

                entity.HasOne(d => d.ParentDepartmentNavigation)
                    .WithMany(p => p.InverseParentDepartmentNavigation)
                    .HasForeignKey(d => d.ParentDepartment)
                    .HasConstraintName("FK_Departments_Departments_Id");
            });

            modelBuilder.Entity<FnBankFiches>(entity =>
            {
                entity.HasIndex(e => e.FinanceRef)
                    .HasName("iFinanceRef_ET_001_FnBankFiches");

                entity.HasIndex(e => e.Owner)
                    .HasName("iOwner_ET_001_FnBankFiches");

                entity.HasOne(d => d.FinanceRefNavigation)
                    .WithMany(p => p.FnBankFiches)
                    .HasForeignKey(d => d.FinanceRef)
                    .HasConstraintName("FK_FnBankFiches_FnFiches_Id");

                entity.HasOne(d => d.OwnerNavigation)
                    .WithMany(p => p.FnBankFiches)
                    .HasForeignKey(d => d.Owner)
                    .HasConstraintName("FK_FnBankFiches_Users_Id");
            });

            modelBuilder.Entity<FnBankLines>(entity =>
            {
                entity.HasIndex(e => e.AccountRef)
                    .HasName("iAccountRef_ET_001_FnBankLines");

                entity.HasIndex(e => e.BankAccountRef)
                    .HasName("iBankAccountRef_ET_001_FnBankLines");

                entity.HasIndex(e => e.BankCardRef)
                    .HasName("iCardRef_ET_001_FnBankLines");

                entity.HasIndex(e => e.BranchRef)
                    .HasName("iBranchRef_ET_001_FnBankLines");

                entity.HasIndex(e => e.CostRef)
                    .HasName("iCostRef_ET_001_FnBankLines");

                entity.HasIndex(e => e.FicheRef)
                    .HasName("iFicheRef_ET_001_FnBankLines");

                entity.HasIndex(e => e.FinanceLineRef)
                    .HasName("iFinanceLineRef_ET_001_FnBankLines");

                entity.HasOne(d => d.AccountRefNavigation)
                    .WithMany(p => p.FnBankLines)
                    .HasForeignKey(d => d.AccountRef)
                    .HasConstraintName("FK_FnBankLines_Accounts_Id");

                entity.HasOne(d => d.BankAccountRefNavigation)
                    .WithMany(p => p.FnBankLines)
                    .HasForeignKey(d => d.BankAccountRef)
                    .HasConstraintName("FK_FnBankLines_BankAccounts_Id");

                entity.HasOne(d => d.BankCardRefNavigation)
                    .WithMany(p => p.FnBankLines)
                    .HasForeignKey(d => d.BankCardRef)
                    .HasConstraintName("FK_FnBankLines_BankCards_Id");

                entity.HasOne(d => d.BranchRefNavigation)
                    .WithMany(p => p.FnBankLines)
                    .HasForeignKey(d => d.BranchRef)
                    .HasConstraintName("FK_FnBankLines_BankBranches_Id");

                entity.HasOne(d => d.CostRefNavigation)
                    .WithMany(p => p.FnBankLines)
                    .HasForeignKey(d => d.CostRef)
                    .HasConstraintName("FK_FnBankLines_Costs_Id");

                entity.HasOne(d => d.CurrencyNavigation)
                    .WithMany(p => p.FnBankLines)
                    .HasForeignKey(d => d.Currency)
                    .HasConstraintName("FK_FnBankLines_Currencies_Id");

                entity.HasOne(d => d.FicheRefNavigation)
                    .WithMany(p => p.FnBankLines)
                    .HasForeignKey(d => d.FicheRef)
                    .HasConstraintName("FK_FnBankLines_FnBankFiches_Id");

                entity.HasOne(d => d.FinanceLineRefNavigation)
                    .WithMany(p => p.FnBankLines)
                    .HasForeignKey(d => d.FinanceLineRef)
                    .HasConstraintName("FK_FnBankLines_FnFicheLines_Id");
            });

            modelBuilder.Entity<FnBarterFiches>(entity =>
            {
                entity.HasIndex(e => e.FinanceRef)
                    .HasName("iFinanceRef_ET_001_FnBarterFiches");

                entity.HasIndex(e => e.Owner)
                    .HasName("iOwner_ET_001_FnBarterFiches");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.FnBarterFiches)
                    .HasForeignKey<FnBarterFiches>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.OwnerNavigation)
                    .WithMany(p => p.FnBarterFiches)
                    .HasForeignKey(d => d.Owner)
                    .HasConstraintName("FK_FnBarterFiches_Users_Id");
            });

            modelBuilder.Entity<FnBarterLines>(entity =>
            {
                entity.HasIndex(e => e.AccountRef)
                    .HasName("iAccountRef_ET_001_FnBarterLines");

                entity.HasIndex(e => e.FicheRef)
                    .HasName("iFicheRef_ET_001_FnBarterLines");

                entity.HasIndex(e => e.FinanceLineRef)
                    .HasName("iFinanceLineRef_ET_001_FnBarterLines");

                entity.HasOne(d => d.AccountRefNavigation)
                    .WithMany(p => p.FnBarterLines)
                    .HasForeignKey(d => d.AccountRef)
                    .HasConstraintName("FK_FnBarterLines_Accounts_Id");

                entity.HasOne(d => d.CurrencyNavigation)
                    .WithMany(p => p.FnBarterLines)
                    .HasForeignKey(d => d.Currency)
                    .HasConstraintName("FK_FnBarterLines_Currencies_Id");

                entity.HasOne(d => d.FicheRefNavigation)
                    .WithMany(p => p.FnBarterLines)
                    .HasForeignKey(d => d.FicheRef)
                    .HasConstraintName("FK_FnBarterLines_FnBarterFiches_Id");

                entity.HasOne(d => d.FinanceLineRefNavigation)
                    .WithMany(p => p.FnBarterLines)
                    .HasForeignKey(d => d.FinanceLineRef)
                    .HasConstraintName("FK_FnBarterLines_FnFicheLines_Id");
            });

            modelBuilder.Entity<FnCashFiches>(entity =>
            {
                entity.HasIndex(e => e.CardRef)
                    .HasName("iCardRef_ET_001_FnCashFiches");

                entity.HasIndex(e => e.FinanceRef)
                    .HasName("iFinanceRef_ET_001_FnCashFiches");

                entity.HasIndex(e => e.Owner)
                    .HasName("iOwner_ET_001_FnCashFiches");

                entity.HasOne(d => d.CardRefNavigation)
                    .WithMany(p => p.FnCashFiches)
                    .HasForeignKey(d => d.CardRef)
                    .HasConstraintName("FK_FnCashFiches_CashCards_Id");

                entity.HasOne(d => d.FinanceRefNavigation)
                    .WithMany(p => p.FnCashFiches)
                    .HasForeignKey(d => d.FinanceRef)
                    .HasConstraintName("FK_FnCashFiches_FnFiches_Id");

                entity.HasOne(d => d.OwnerNavigation)
                    .WithMany(p => p.FnCashFiches)
                    .HasForeignKey(d => d.Owner)
                    .HasConstraintName("FK_FnCashFiches_Users_Id");
            });

            modelBuilder.Entity<FnCashLines>(entity =>
            {
                entity.HasIndex(e => e.CostRef)
                    .HasName("iCostRef_ET_001_FnCashLines");

                entity.HasIndex(e => e.FicheRef)
                    .HasName("iFicheRef_ET_001_FnCashLines");

                entity.HasIndex(e => e.FinanceLineRef)
                    .HasName("iFinanceLineRef_ET_001_FnCashLines");

                entity.HasOne(d => d.AccountRefNavigation)
                    .WithMany(p => p.FnCashLines)
                    .HasForeignKey(d => d.AccountRef)
                    .HasConstraintName("FK_FnCashLines_Accounts_Id");

                entity.HasOne(d => d.CostRefNavigation)
                    .WithMany(p => p.FnCashLines)
                    .HasForeignKey(d => d.CostRef)
                    .HasConstraintName("FK_FnCashLines_Costs_Id");

                entity.HasOne(d => d.CurrencyNavigation)
                    .WithMany(p => p.FnCashLines)
                    .HasForeignKey(d => d.Currency)
                    .HasConstraintName("FK_FnCashLines_Currencies_Id");

                entity.HasOne(d => d.FicheRefNavigation)
                    .WithMany(p => p.FnCashLines)
                    .HasForeignKey(d => d.FicheRef)
                    .HasConstraintName("FK_FnCashLines_FnCashFiches_Id");

                entity.HasOne(d => d.FinanceLineRefNavigation)
                    .WithMany(p => p.FnCashLines)
                    .HasForeignKey(d => d.FinanceLineRef)
                    .HasConstraintName("FK_FnCashLines_FnFicheLines_Id");
            });

            modelBuilder.Entity<FnCreditCardFiches>(entity =>
            {
                entity.HasOne(d => d.FinanceRefNavigation)
                    .WithMany(p => p.FnCreditCardFiches)
                    .HasForeignKey(d => d.FinanceRef)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FnCreditCardFiches_FnFiches_Id");

                entity.HasOne(d => d.OwnerNavigation)
                    .WithMany(p => p.FnCreditCardFiches)
                    .HasForeignKey(d => d.Owner)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FnCreditCardFiches_Users_Id");
            });

            modelBuilder.Entity<FnCreditCardLines>(entity =>
            {
                entity.HasIndex(e => e.AccountRef)
                    .HasName("iAccountRef_ET_001_FnCreditCardLines");

                entity.HasIndex(e => e.FicheRef)
                    .HasName("iFicheRef_ET_001_FnCreditCardLines");

                entity.HasIndex(e => e.FinanceLineRef)
                    .HasName("iFinanceLineRef_ET_001_FnCreditCardLines");

                entity.HasOne(d => d.AccountRefNavigation)
                    .WithMany(p => p.FnCreditCardLines)
                    .HasForeignKey(d => d.AccountRef)
                    .HasConstraintName("FK_FnCreditCardLines_Accounts_Id");

                entity.HasOne(d => d.CostRefNavigation)
                    .WithMany(p => p.FnCreditCardLines)
                    .HasForeignKey(d => d.CostRef)
                    .HasConstraintName("FK_FnCreditCardLines_Costs_Id");

                entity.HasOne(d => d.CurrencyNavigation)
                    .WithMany(p => p.FnCreditCardLines)
                    .HasForeignKey(d => d.Currency)
                    .HasConstraintName("FK_FnCreditCardLines_Currencies_Id");

                entity.HasOne(d => d.FicheRefNavigation)
                    .WithMany(p => p.FnCreditCardLines)
                    .HasForeignKey(d => d.FicheRef)
                    .HasConstraintName("FK_FnCreditCardLines_FnCreditCardFiches_Id");

                entity.HasOne(d => d.FinanceLineRefNavigation)
                    .WithMany(p => p.FnCreditCardLines)
                    .HasForeignKey(d => d.FinanceLineRef)
                    .HasConstraintName("FK_FnCreditCardLines_FnFicheLines_Id");
            });

            modelBuilder.Entity<FnCsFiches>(entity =>
            {
                entity.HasIndex(e => e.FinanceRef)
                    .HasName("iFinanceRef_ET_001_FnCsFiches");

                entity.HasIndex(e => e.Owner)
                    .HasName("iOwner_ET_001_FnCsFiches");

                entity.HasOne(d => d.FinanceRefNavigation)
                    .WithMany(p => p.FnCsFiches)
                    .HasForeignKey(d => d.FinanceRef)
                    .HasConstraintName("FK_FnCsFiches_FnFiches_Id");

                entity.HasOne(d => d.OwnerNavigation)
                    .WithMany(p => p.FnCsFiches)
                    .HasForeignKey(d => d.Owner)
                    .HasConstraintName("FK_FnCsFiches_Users_Id");
            });

            modelBuilder.Entity<FnCsLines>(entity =>
            {
                entity.HasIndex(e => e.AccountRef)
                    .HasName("iAccountRef_ET_001_FnCsLines");

                entity.HasIndex(e => e.CostRef)
                    .HasName("iCostRef_ET_001_FnCsLines");

                entity.HasIndex(e => e.FicheRef)
                    .HasName("iFicheRef_ET_001_FnCsLines");

                entity.HasIndex(e => e.FinanceLineRef)
                    .HasName("iFinanceLineRef_ET_001_FnCsLines");

                entity.HasOne(d => d.AccountRefNavigation)
                    .WithMany(p => p.FnCsLines)
                    .HasForeignKey(d => d.AccountRef)
                    .HasConstraintName("FK_FnCsLines_Accounts_Id");

                entity.HasOne(d => d.CostRefNavigation)
                    .WithMany(p => p.FnCsLines)
                    .HasForeignKey(d => d.CostRef)
                    .HasConstraintName("FK_FnCsLines_Costs_Id");

                entity.HasOne(d => d.CurrencyNavigation)
                    .WithMany(p => p.FnCsLines)
                    .HasForeignKey(d => d.Currency)
                    .HasConstraintName("FK_FnCsLines_Currencies_Id");

                entity.HasOne(d => d.FicheRefNavigation)
                    .WithMany(p => p.FnCsLines)
                    .HasForeignKey(d => d.FicheRef)
                    .HasConstraintName("FK_FnCsLines_FnCsFiches_Id");

                entity.HasOne(d => d.FinanceLineRefNavigation)
                    .WithMany(p => p.FnCsLines)
                    .HasForeignKey(d => d.FinanceLineRef)
                    .HasConstraintName("FK_FnCsLines_FnFicheLines_Id");
            });

            modelBuilder.Entity<FnFicheLines>(entity =>
            {
                entity.HasIndex(e => e.AccountRef)
                    .HasName("iAccountRef_ET_001_FnFicheLines");

                entity.HasIndex(e => e.BankRef)
                    .HasName("iBankRef_ET_001_FnFicheLines");

                entity.HasIndex(e => e.BarterRef)
                    .HasName("iBarterRef_ET_001_FnFicheLines");

                entity.HasIndex(e => e.CardRef)
                    .HasName("iCardRef_ET_001_FnFicheLines");

                entity.HasIndex(e => e.CashRef)
                    .HasName("iCashRef_ET_001_FnFicheLines");

                entity.HasIndex(e => e.Collect)
                    .HasName("iCollect_ET_001_FnFicheLines");

                entity.HasIndex(e => e.CreditCardRef)
                    .HasName("iCreditCardRef_ET_001_FnFicheLines");

                entity.HasIndex(e => e.CsRef)
                    .HasName("iCsRef_ET_001_FnFicheLines");

                entity.HasIndex(e => e.FinanceRef)
                    .HasName("iFinanceRef_ET_001_FnFicheLines");

                entity.HasIndex(e => e.ModifiedUser)
                    .HasName("iModifiedUser_ET_001_FnFicheLines");

                entity.HasOne(d => d.AccountRefNavigation)
                    .WithMany(p => p.FnFicheLines)
                    .HasForeignKey(d => d.AccountRef)
                    .HasConstraintName("FK_FnFicheLines_Accounts_Id");

                entity.HasOne(d => d.BankRefNavigation)
                    .WithMany(p => p.FnFicheLines)
                    .HasForeignKey(d => d.BankRef)
                    .HasConstraintName("FK_FnFicheLines_FnBankLines_Id");

                entity.HasOne(d => d.BarterRefNavigation)
                    .WithMany(p => p.FnFicheLines)
                    .HasForeignKey(d => d.BarterRef)
                    .HasConstraintName("FK_FnFicheLines_FnBarterLines_Id");

                entity.HasOne(d => d.CardRefNavigation)
                    .WithMany(p => p.FnFicheLines)
                    .HasForeignKey(d => d.CardRef)
                    .HasConstraintName("FK_FnFicheLines_CashCards_Id");

                entity.HasOne(d => d.CashRefNavigation)
                    .WithMany(p => p.FnFicheLines)
                    .HasForeignKey(d => d.CashRef)
                    .HasConstraintName("FK_FnFicheLines_FnCashLines_Id");

                entity.HasOne(d => d.CostRefNavigation)
                    .WithMany(p => p.FnFicheLines)
                    .HasForeignKey(d => d.CostRef)
                    .HasConstraintName("FK_FnFicheLines_Costs_Id");

                entity.HasOne(d => d.CurrencyNavigation)
                    .WithMany(p => p.FnFicheLines)
                    .HasForeignKey(d => d.Currency)
                    .HasConstraintName("FK_FnFicheLines_Currencies_Id");

                entity.HasOne(d => d.FinanceRefNavigation)
                    .WithMany(p => p.FnFicheLines)
                    .HasForeignKey(d => d.FinanceRef)
                    .HasConstraintName("FK_FnFicheLines_FnFiches_Id");

                entity.HasOne(d => d.OrderRefNavigation)
                    .WithMany(p => p.FnFicheLines)
                    .HasForeignKey(d => d.OrderRef)
                    .HasConstraintName("FK_FnFicheLines_OrderLines_Id");
            });

            modelBuilder.Entity<FnFiches>(entity =>
            {
                entity.HasIndex(e => e.BankFicheRef)
                    .HasName("iBankFicheRef_ET_001_FnFiches");

                entity.HasIndex(e => e.BarterFicheRef)
                    .HasName("iBarterFicheRef_ET_001_FnFiches");

                entity.HasIndex(e => e.BillFicheRef)
                    .HasName("iBillFicheRef_ET_001_FnFiches");

                entity.HasIndex(e => e.CashFicheRef)
                    .HasName("iCashFicheRef_ET_001_FnFiches");

                entity.HasIndex(e => e.CheckFicheRef)
                    .HasName("iCheckFicheRef_ET_001_FnFiches");

                entity.HasIndex(e => e.CreditCardFicheRef)
                    .HasName("iCreditCardFicheRef_ET_001_FnFiches");

                entity.HasIndex(e => e.ModifiedUser)
                    .HasName("iModifiedUser_ET_001_FnFiches");

                entity.HasIndex(e => e.Owner)
                    .HasName("iOwner_ET_001_FnFiches");

                entity.HasOne(d => d.BankFicheRefNavigation)
                    .WithMany(p => p.FnFiches)
                    .HasForeignKey(d => d.BankFicheRef)
                    .HasConstraintName("FK_FnFiches_FnBankFiches_Id");

                entity.HasOne(d => d.BarterFicheRefNavigation)
                    .WithMany(p => p.FnFiches)
                    .HasForeignKey(d => d.BarterFicheRef)
                    .HasConstraintName("FK_FnFiches_FnBarterFiches_Id");

                entity.HasOne(d => d.CashFicheRefNavigation)
                    .WithMany(p => p.FnFiches)
                    .HasForeignKey(d => d.CashFicheRef)
                    .HasConstraintName("FK_FnFiches_FnCashFiches_Id");

                entity.HasOne(d => d.CreditCardFicheRefNavigation)
                    .WithMany(p => p.FnFiches)
                    .HasForeignKey(d => d.CreditCardFicheRef)
                    .HasConstraintName("FK_FnFiches_FnCreditCardFiches_Id");

                entity.HasOne(d => d.OrderRefNavigation)
                    .WithMany(p => p.FnFiches)
                    .HasForeignKey(d => d.OrderRef)
                    .HasConstraintName("FK_FnFiches_Orders_Id");

                entity.HasOne(d => d.OwnerNavigation)
                    .WithMany(p => p.FnFiches)
                    .HasForeignKey(d => d.Owner)
                    .HasConstraintName("FK_FnFiches_Users_Id");
            });

            modelBuilder.Entity<Inventories>(entity =>
            {
                entity.HasIndex(e => e.OwnerRef)
                    .HasName("iOwner_ET_001_Inventories");

                entity.HasIndex(e => e.Section)
                    .HasName("iSection_ET_001_Inventories");

                entity.HasIndex(e => e.WareHouse)
                    .HasName("iWareHouse_ET_001_Inventories");

                entity.HasIndex(e => e.WorkPlace)
                    .HasName("iWorkPlace_ET_001_Inventories");

                entity.HasOne(d => d.OwnerRefNavigation)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.OwnerRef)
                    .HasConstraintName("FK_Inventories_Users_Id");

                entity.HasOne(d => d.SectionNavigation)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.Section)
                    .HasConstraintName("FK_Inventories_Sections_Id");

                entity.HasOne(d => d.WareHouseNavigation)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.WareHouse)
                    .HasConstraintName("FK_Inventories_WareHouses_Id");

                entity.HasOne(d => d.WorkPlaceNavigation)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.WorkPlace)
                    .HasConstraintName("FK_Inventories_WorkPlaces_Id");
            });

            modelBuilder.Entity<InventoryLines>(entity =>
            {
                entity.HasOne(d => d.AccountRefNavigation)
                    .WithMany(p => p.InventoryLines)
                    .HasForeignKey(d => d.AccountRef)
                    .HasConstraintName("FK_InventoryLines_Accounts_Id");

                entity.HasOne(d => d.CurrencyRefNavigation)
                    .WithMany(p => p.InventoryLines)
                    .HasForeignKey(d => d.CurrencyRef)
                    .HasConstraintName("FK_InventoryLines_Currencies_Id");

                entity.HasOne(d => d.ItemRefNavigation)
                    .WithMany(p => p.InventoryLines)
                    .HasForeignKey(d => d.ItemRef)
                    .HasConstraintName("FK_InventoryLines_Items_Id");

                entity.HasOne(d => d.OwnerRefNavigation)
                    .WithMany(p => p.InventoryLines)
                    .HasForeignKey(d => d.OwnerRef)
                    .HasConstraintName("FK_InventoryLines_Users_Id");

                entity.HasOne(d => d.StockFicheRefNavigation)
                    .WithMany(p => p.InventoryLines)
                    .HasForeignKey(d => d.StockFicheRef)
                    .HasConstraintName("FK_InventoryLines_Inventories_Id");

                entity.HasOne(d => d.UnitLineRefNavigation)
                    .WithMany(p => p.InventoryLines)
                    .HasForeignKey(d => d.UnitLineRef)
                    .HasConstraintName("FK_InventoryLines_UnitLines_Id");

                entity.HasOne(d => d.UnitRefNavigation)
                    .WithMany(p => p.InventoryLines)
                    .HasForeignKey(d => d.UnitRef)
                    .HasConstraintName("FK_InventoryLines_Units_Id");
            });

            modelBuilder.Entity<ItemToCategories>(entity =>
            {
                entity.HasKey(e => new { e.CategoryId, e.ItemId });

                entity.HasIndex(e => e.CategoryId)
                    .HasName("iCategories_ET_001_ItemsItems_ET_001_CategoriesCategories");

                entity.HasIndex(e => e.ItemId)
                    .HasName("iItems_ET_001_ItemsItems_ET_001_CategoriesCategories");

                entity.HasIndex(e => new { e.CategoryId, e.ItemId })
                    .HasName("iCategoriesItems_ET_001_ItemsItems_ET_001_CategoriesCategories")
                    .IsUnique();

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.ItemToCategories)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemToCategories_Categories_Id");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.ItemToCategories)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemToCategories_Items_Id");
            });

            modelBuilder.Entity<ItemToTags>(entity =>
            {
                entity.HasKey(e => new { e.ItemId, e.TagId });

                entity.HasIndex(e => e.ItemId)
                    .HasName("iItems_ET_001_TagsTags_ET_001_ItemsItems");

                entity.HasIndex(e => e.TagId)
                    .HasName("iTags_ET_001_TagsTags_ET_001_ItemsItems");

                entity.HasIndex(e => new { e.ItemId, e.TagId })
                    .HasName("iItemsTags_ET_001_TagsTags_ET_001_ItemsItems")
                    .IsUnique();

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.ItemToTags)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemToTags_Items_Id");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.ItemToTags)
                    .HasForeignKey(d => d.TagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemToTags_Tags_Id");
            });

            modelBuilder.Entity<ItemToVariants>(entity =>
            {
                entity.HasKey(e => new { e.ItemId, e.VariantId });

                entity.HasIndex(e => e.ItemId)
                    .HasName("iItems_ET_001_ItemVariantsVariants_ET_001_ItemsItems");

                entity.HasIndex(e => e.VariantId)
                    .HasName("iVariants_ET_001_ItemVariantsVariants_ET_001_ItemsItems");

                entity.HasIndex(e => new { e.ItemId, e.VariantId })
                    .HasName("iItemsVariants_ET_001_ItemVariantsVariants_ET_001_ItemsItems")
                    .IsUnique();

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.ItemToVariants)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemToVariants_Items_Id");

                entity.HasOne(d => d.Variant)
                    .WithMany(p => p.ItemToVariants)
                    .HasForeignKey(d => d.VariantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemToVariants_Variants_Id");
            });

            modelBuilder.Entity<ItemToWareHouses>(entity =>
            {
                entity.HasKey(e => new { e.ItemId, e.WarehouseId });

                entity.HasIndex(e => e.ItemId)
                    .HasName("iItems_ET_001_WareHousesWareHouses_ET_001_ItemsItems");

                entity.HasIndex(e => e.WarehouseId)
                    .HasName("iWareHouses_ET_001_WareHousesWareHouses_ET_001_ItemsItems");

                entity.HasIndex(e => new { e.ItemId, e.WarehouseId })
                    .HasName("iItemsWareHouses_ET_001_WareHousesWareHouses_ET_001_ItemsItems")
                    .IsUnique();

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.ItemToWareHouses)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemToWareHouses_Items_Id");

                entity.HasOne(d => d.Warehouse)
                    .WithMany(p => p.ItemToWareHouses)
                    .HasForeignKey(d => d.WarehouseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemToWareHouses_WareHouses_Id");
            });

            modelBuilder.Entity<Items>(entity =>
            {
                entity.HasOne(d => d.MarkNavigation)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.Mark)
                    .HasConstraintName("FK_Items_Marks_Id");
            });

            modelBuilder.Entity<Marks>(entity =>
            {
                entity.HasIndex(e => e.Owner)
                    .HasName("iOwner_ET_001_Marks");

                entity.HasOne(d => d.OwnerNavigation)
                    .WithMany(p => p.Marks)
                    .HasForeignKey(d => d.Owner)
                    .HasConstraintName("FK_Marks_Users_Id");
            });

            modelBuilder.Entity<OrderLines>(entity =>
            {
                entity.HasOne(d => d.CurrencyRefNavigation)
                    .WithMany(p => p.OrderLines)
                    .HasForeignKey(d => d.CurrencyRef)
                    .HasConstraintName("FK_OrderLines_Currencies_Id");

                entity.HasOne(d => d.FinanceLineRefNavigation)
                    .WithMany(p => p.OrderLines)
                    .HasForeignKey(d => d.FinanceLineRef)
                    .HasConstraintName("FK_OrderLines_FnFicheLines_Id");

                entity.HasOne(d => d.ItemRefNavigation)
                    .WithMany(p => p.OrderLines)
                    .HasForeignKey(d => d.ItemRef)
                    .HasConstraintName("FK_OrderLines_Items_Id");

                entity.HasOne(d => d.OrderRefNavigation)
                    .WithMany(p => p.OrderLines)
                    .HasForeignKey(d => d.OrderRef)
                    .HasConstraintName("FK_OrderLines_Orders_Id");

                entity.HasOne(d => d.UnitLineRefNavigation)
                    .WithMany(p => p.OrderLines)
                    .HasForeignKey(d => d.UnitLineRef)
                    .HasConstraintName("FK_OrderLines_UnitLines_Id");

                entity.HasOne(d => d.UnitRefNavigation)
                    .WithMany(p => p.OrderLines)
                    .HasForeignKey(d => d.UnitRef)
                    .HasConstraintName("FK_OrderLines_Units_Id");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasOne(d => d.AccountRefNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.AccountRef)
                    .HasConstraintName("FK_Orders_Accounts_Id");

                entity.HasOne(d => d.CouponNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Coupon)
                    .HasConstraintName("FK_Orders_CouponCodes_Id");

                entity.HasOne(d => d.FinanceRefNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.FinanceRef)
                    .HasConstraintName("FK_Orders_FnFiches_Id");

                entity.HasOne(d => d.OwnerRefNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OwnerRef)
                    .HasConstraintName("FK_Orders_Users_Id");

                entity.HasOne(d => d.PaymentTypeNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.PaymentType)
                    .HasConstraintName("FK_Orders_PaymentTypes_Id");
            });

            modelBuilder.Entity<Pictures>(entity =>
            {
                entity.HasOne(d => d.CategoryRefNavigation)
                    .WithMany(p => p.Pictures)
                    .HasForeignKey(d => d.CategoryRef)
                    .HasConstraintName("FK_Pictures_Categories_Id");

                entity.HasOne(d => d.ItemRefNavigation)
                    .WithMany(p => p.Pictures)
                    .HasForeignKey(d => d.ItemRef)
                    .HasConstraintName("FK_Pictures_Items_Id");

                entity.HasOne(d => d.MarkRefNavigation)
                    .WithMany(p => p.Pictures)
                    .HasForeignKey(d => d.MarkRef)
                    .HasConstraintName("FK_Pictures_Marks_Id");
            });

            modelBuilder.Entity<Positions>(entity =>
            {
                entity.HasIndex(e => e.Department)
                    .HasName("iDepartment_ET_001_Positions");

                entity.HasOne(d => d.DepartmentNavigation)
                    .WithMany(p => p.Positions)
                    .HasForeignKey(d => d.Department)
                    .HasConstraintName("FK_Positions_Departments_Id");
            });

            modelBuilder.Entity<PriceLists>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.CurrencyRefNavigation)
                    .WithMany(p => p.PriceLists)
                    .HasForeignKey(d => d.CurrencyRef)
                    .HasConstraintName("FK_PriceLists_Currencies_Id");

                entity.HasOne(d => d.ItemRefNavigation)
                    .WithMany(p => p.PriceLists)
                    .HasForeignKey(d => d.ItemRef)
                    .HasConstraintName("FK_PriceLists_Items_Id");

                entity.HasOne(d => d.OwnerRefNavigation)
                    .WithMany(p => p.PriceLists)
                    .HasForeignKey(d => d.OwnerRef)
                    .HasConstraintName("FK_PriceLists_Users_Id");
            });

            modelBuilder.Entity<Sections>(entity =>
            {
                entity.HasIndex(e => e.ParentSection)
                    .HasName("iParentSection_ET_001_Sections");

                entity.HasIndex(e => e.WorkPlace)
                    .HasName("iWorkPlace_ET_001_Sections");

                entity.HasOne(d => d.ParentSectionNavigation)
                    .WithMany(p => p.InverseParentSectionNavigation)
                    .HasForeignKey(d => d.ParentSection)
                    .HasConstraintName("FK_Sections_Sections_Id");

                entity.HasOne(d => d.WorkPlaceNavigation)
                    .WithMany(p => p.Sections)
                    .HasForeignKey(d => d.WorkPlace)
                    .HasConstraintName("FK_Sections_WorkPlaces_Id");
            });

            modelBuilder.Entity<Towns>(entity =>
            {
                entity.HasIndex(e => e.City)
                    .HasName("iCity_ET_001_Towns");

                entity.HasIndex(e => e.Owner)
                    .HasName("iOwner_ET_001_Towns");
            });

            modelBuilder.Entity<UnitLines>(entity =>
            {
                entity.HasIndex(e => e.UnitRef)
                    .HasName("iUnitSet_ET_001_UnitLines");

                entity.HasOne(d => d.UnitRefNavigation)
                    .WithMany(p => p.UnitLines)
                    .HasForeignKey(d => d.UnitRef)
                    .HasConstraintName("FK_UnitLines_Units_Id");
            });

            modelBuilder.Entity<Units>(entity =>
            {
                entity.HasIndex(e => e.ParentUnitSet)
                    .HasName("iParentUnitSet_ET_001_Units");

                entity.HasIndex(e => e.Specode)
                    .HasName("iSpecode_ET_001_Units");

                entity.HasOne(d => d.ParentUnitSetNavigation)
                    .WithMany(p => p.InverseParentUnitSetNavigation)
                    .HasForeignKey(d => d.ParentUnitSet)
                    .HasConstraintName("FK_Units_Units_Id");
            });

            modelBuilder.Entity<UserToRoles>(entity =>
            {
                entity.HasKey(e => new { e.RoleId, e.UserId });

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserToRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserToRoles_Roles_Id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserToRoles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserToRoles_Users_Id");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasOne(d => d.AccountRefNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.AccountRef)
                    .HasConstraintName("FK_Users_Accounts_Id");

                entity.HasOne(d => d.AddressRefNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.AddressRef)
                    .HasConstraintName("FK_Users_Addresses_Id");

                entity.HasOne(d => d.DepartmentNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Department)
                    .HasConstraintName("FK_Users_Departments_Id");

                entity.HasOne(d => d.OwnerRefNavigation)
                    .WithMany(p => p.InverseOwnerRefNavigation)
                    .HasForeignKey(d => d.OwnerRef)
                    .HasConstraintName("FK_Users_Users_Id");

                entity.HasOne(d => d.PositionNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Position)
                    .HasConstraintName("FK_Users_Positions_Id");

                entity.HasOne(d => d.UserCurrencyTypeNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserCurrencyType)
                    .HasConstraintName("FK_Users_Currencies_Id");
            });

            modelBuilder.Entity<Variants>(entity =>
            {
                entity.HasIndex(e => e.ParentVariant)
                    .HasName("iParentVariant_ET_001_ItemVariants");

                entity.HasIndex(e => e.VariantPrice)
                    .HasName("iVariantPrice_ET_001_ItemVariants");
            });

            modelBuilder.Entity<WareHouses>(entity =>
            {
                entity.HasIndex(e => e.ParentWareHouse)
                    .HasName("iParentWareHouse_ET_001_WareHouses");

                entity.HasIndex(e => e.Section)
                    .HasName("iSection_ET_001_WareHouses");

                entity.HasOne(d => d.ParentWareHouseNavigation)
                    .WithMany(p => p.InverseParentWareHouseNavigation)
                    .HasForeignKey(d => d.ParentWareHouse)
                    .HasConstraintName("FK_WareHouses_WareHouses_Id");

                entity.HasOne(d => d.SectionNavigation)
                    .WithMany(p => p.WareHouses)
                    .HasForeignKey(d => d.Section)
                    .HasConstraintName("FK_WareHouses_Sections_Id");
            });

            modelBuilder.Entity<WorkPlaces>(entity =>
            {
                entity.HasIndex(e => e.ParentWorkPlace)
                    .HasName("iParentWorkPlace_ET_001_WorkPlaces");

                entity.HasOne(d => d.ParentWorkPlaceNavigation)
                    .WithMany(p => p.InverseParentWorkPlaceNavigation)
                    .HasForeignKey(d => d.ParentWorkPlace)
                    .HasConstraintName("FK_WorkPlaces_WorkPlaces_Id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
