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
    public class AccountRepository : RepositoryBase<Accounts>, IAccountRepository
    {
        public AccountRepository(TradeDbContext context)
       : base(context)
        {
        }

        public void CreateAccount(Accounts account)
        {
            Create(account);
        }

        public void DeleteAccount(Accounts account)
        {
            Delete(account);
        }

        public void UpdateAccount(Accounts accounts)
        {
            Update(accounts);
        }



        public async Task<IEnumerable<Accounts>> GetAllAccountsAsync()
        {
            return await FindAll()
               .OrderBy(ow => ow.Name)
               .ToListAsync();
        }
        public async Task<Accounts> GetAccountByIdAsync(int id)
        {
            return await FindByCondition(ac => ac.Id.Equals(id))
               .FirstOrDefaultAsync();
        }

        public async Task<Accounts> GetAccountWithDetailsAsync(int id)
        {
            return await FindByCondition(ac => ac.Id.Equals(id))
                .Include(ac => ac.CampaignLines)
                .Include(ac => ac.CampaignToAccounts)
                .Include(ac => ac.CashCards)
                .Include(ac => ac.FnBankLines)
                .Include(ac => ac.FnBarterLines)
                .Include(ac => ac.FnCashLines)
                .Include(ac => ac.FnCreditCardLines)
                .Include(ac => ac.FnCsLines)
                .Include(ac => ac.FnFicheLines)
                .Include(ac => ac.InventoryLines)
                .Include(ac => ac.InverseParentAccountNavigation)
                .Include(ac => ac.Orders)
                .Include(ac => ac.Users)
                .FirstOrDefaultAsync();
        }
        
        public async Task Update(int id)
        {
            await context.SaveChangesAsync();
        }
      
    }
}
