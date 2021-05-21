using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TredeWeb.DataLayer;
using TredeWeb.Models;

namespace TredeWeb.Interfaces
{
    public interface IBarcodeRepository : IRepositoryBase<Barcodes>
    {
        Task<IEnumerable<Barcodes>> GetAllBarcodeAsync();
        Task<Barcodes> GetBarcodeByIdAsync(int id);
        Task<Barcodes> GetBarcodeWithDetailsAsync(int id);
        void CreateBarcode(Barcodes barcode);
        void UpdateBarcode(Barcodes barcode);
        void DeleteBarcode(Barcodes barcode);
        Task Update(int id);
    }
}
