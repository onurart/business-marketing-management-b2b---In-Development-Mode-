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
    public class BankCardsRepository : RepositoryBase<BankCards>, IBankCardsRepository
    {
        public BankCardsRepository(TradeDbContext context)
        : base(context)
        {
        }
        public void CreateBankCards(BankCards bankCard)
        {
            CreateBankCards(bankCard);
        }
        public void DeleteBankCard(BankCards bankCard)
        {
            DeleteBankCard(bankCard);
        }
        public void UpdateBankCard(BankCards bankCard)
        {
            UpdateBankCard(bankCard);
        }



        public async Task<IEnumerable<BankCards>> GetAllBankCardAsync()
        {
            return await FindAll()
             .OrderBy(ow => ow.Id)
             .ToListAsync();
        }
        public async Task<BankCards> GetBankCardByIdAsync(int id)
        {
            return await FindByCondition(ac => ac.Id.Equals(id))
               .FirstOrDefaultAsync();
        }
        public async Task<BankCards> GetBankCardWithDetailsAsync(int id)
        {
            return await FindByCondition(ac => ac.Id.Equals(id))
                                  .Include(ac => ac.BankBranches)
                                                               .FirstOrDefaultAsync();
        }
        public async Task Update(int id)
        {
            await context.SaveChangesAsync();
        }

    }
}
