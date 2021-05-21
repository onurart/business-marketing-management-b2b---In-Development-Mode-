using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TredeWeb.DataLayer;

namespace TredeWeb.Interfaces
{
    public interface ICashCardsRepository : IRepositoryBase<CashCards>
    {
        Task<IEnumerable<CashCards>> GetAllCashCardAsync();
        Task<CashCards> GetCashCardByIdAsync(int id);
        Task<CashCards> GetCashCardWithDetailsAsync(int id);
        void CreateCashCard(CashCards cashCards);
        void UpdateCashCard(CashCards cashCards);
        void DeleteCashCard(CashCards cashCards);
        Task Update(int id);
    }
}
