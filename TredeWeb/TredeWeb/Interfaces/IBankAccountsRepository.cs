using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TredeWeb.DataLayer;

namespace TredeWeb.Interfaces
{
    public interface IBankAccountsRepository : IRepositoryBase<BankAccounts>
    {
        Task<IEnumerable<BankAccounts>> GetAllBankAccountAsync();
        Task<BankAccounts> GetBankAccountByIdAsync(int id);
        Task<BankAccounts> GetBankAccountWithDetailsAsync(int id);
        void CreateBankAccount(BankAccounts bankAccount);
        void UpdateBankAccount(BankAccounts bankAccount);
        void DeleteBankAccount(BankAccounts bankAccount);
        Task Update(int id);
    }
}
