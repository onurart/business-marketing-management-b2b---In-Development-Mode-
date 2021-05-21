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
    public class CashCardsRepository : RepositoryBase<CashCards>, ICashCardsRepository
    {
        public CashCardsRepository(TradeDbContext context)
       : base(context)
        {
        }

        public void CreateCashCard(CashCards cashCards)
        {
            CreateCashCard(cashCards);
        }
        public void DeleteCashCard(CashCards cashCards)
        {
            DeleteCashCard(cashCards);
        }
        public void UpdateCashCard(CashCards cashCards)
        {
            UpdateCashCard(cashCards);
        }



        public async Task<IEnumerable<CashCards>> GetAllCashCardAsync()
        {

            return await FindAll()
                .OrderBy(ow => ow.Id)
                .ToListAsync();
        }
        public async Task<CashCards> GetCashCardByIdAsync(int id)
        {
            return await FindByCondition(ac => ac.Id.Equals(id))
         .FirstOrDefaultAsync();
        }
        public async Task<CashCards> GetCashCardWithDetailsAsync(int id)
        {
            return await FindByCondition(ac => ac.Id.Equals(id))
                  .Include(ac => ac.InverseParentCardNavigation)
                                 .FirstOrDefaultAsync();
        }
        public async Task Update(int id)
        {
            await context.SaveChangesAsync();
        }

    }
}
