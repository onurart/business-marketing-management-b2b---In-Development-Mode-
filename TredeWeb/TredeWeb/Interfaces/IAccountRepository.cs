using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TredeWeb.DataLayer;

namespace TredeWeb.Interfaces
{
    public interface IAccountRepository : IRepositoryBase<Accounts>
    {
        Task<IEnumerable<Accounts>> GetAllAccountsAsync();
        Task<Accounts> GetAccountByIdAsync(int id);
        Task<Accounts> GetAccountWithDetailsAsync(int id);
        void CreateAccount(Accounts account);
        void UpdateAccount(Accounts account);
        void DeleteAccount(Accounts account);
        Task Update(int id);
    }
}
