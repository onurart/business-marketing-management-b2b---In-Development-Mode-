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
    public class BankAccountsRepository : RepositoryBase<BankAccounts>, IBankAccountsRepository
    {
        public BankAccountsRepository(TradeDbContext context)
        : base(context)
        {
        }
        public void CreateBankAccount(BankAccounts bankAccount)
        {
            CreateBankAccount(bankAccount);
        }
        public void DeleteBankAccount(BankAccounts bankAccount)
        {
            DeleteBankAccount(bankAccount);
        }
        public void UpdateBankAccount(BankAccounts bankAccount)
        {
            UpdateBankAccount(bankAccount);
        }



        public async Task<IEnumerable<BankAccounts>> GetAllBankAccountAsync()
        {
            return await FindAll()
                 .OrderBy(ow => ow.Id)
                 .ToListAsync();
        }

        public async Task<BankAccounts> GetBankAccountByIdAsync(int id)
        {
            return await FindByCondition(ac => ac.Id.Equals(id))
                 .FirstOrDefaultAsync();
        }

        public async Task<BankAccounts> GetBankAccountWithDetailsAsync(int id)
        {
            return await FindByCondition(st => st.Id.Equals(id))
              .FirstOrDefaultAsync();
        }
        public async Task Update(int id)
        {
            await context.SaveChangesAsync();
        }

       
    }
}
