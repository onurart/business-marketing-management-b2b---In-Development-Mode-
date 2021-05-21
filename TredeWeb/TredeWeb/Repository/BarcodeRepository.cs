using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TredeWeb.DataLayer;
using TredeWeb.Interfaces;

namespace TredeWeb.Repository
{
    public class BarcodeRepository : RepositoryBase<Barcodes>, IBarcodeRepository
    {
        public BarcodeRepository(TradeDbContext context)
       : base(context)
        {
        }
        public void CreateBarcode(Barcodes barcode)
        {
            CreateBarcode(barcode);
        }
        public void DeleteBarcode(Barcodes barcode)
        {
            DeleteBarcode(barcode);
        }
        public async Task<IEnumerable<Barcodes>> GetAllBarcodeAsync()
        {
            return await FindAll()
                 .OrderBy(ow => ow.Id)
                 .ToListAsync();
        }

        public async Task<Barcodes> GetBarcodeByIdAsync(int id)
        {
            return await FindByCondition(ac => ac.Id.Equals(id))
                  .FirstOrDefaultAsync();
        }

        public async Task<Barcodes> GetBarcodeWithDetailsAsync(int id)
        {
            return await FindByCondition(ac => ac.Id.Equals(id))
                                 .FirstOrDefaultAsync();
        }

        public async Task Update(int id)
        {
            await context.SaveChangesAsync();
        }

        public void UpdateBarcode(Barcodes barcode)
        {
            UpdateBarcode(barcode);
        }
    }
}
