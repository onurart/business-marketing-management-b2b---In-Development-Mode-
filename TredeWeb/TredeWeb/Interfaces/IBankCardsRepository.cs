using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TredeWeb.DataLayer;

namespace TredeWeb.Interfaces
{
    public interface IBankCardsRepository : IRepositoryBase<BankCards>
    {
        Task<IEnumerable<BankCards>> GetAllBankCardAsync();
        Task<BankCards> GetBankCardByIdAsync(int id);
        Task<BankCards> GetBankCardWithDetailsAsync(int id);
        void CreateBankCards(BankCards bankCard);
        void UpdateBankCard(BankCards bankCard);
        void DeleteBankCard(BankCards bankCard);
        Task Update(int id);
    }
}
