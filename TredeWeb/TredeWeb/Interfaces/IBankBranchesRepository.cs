using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TredeWeb.DataLayer;

namespace TredeWeb.Interfaces
{
    public interface IBankBranchesRepository : IRepositoryBase<BankBranches>
    {
        Task<IEnumerable<BankBranches>> GetAllBankBranchesAsync();
        Task<BankBranches> GetBankBranchesByIdAsync(int id);
        Task<BankBranches> GetBankBranchesWithDetailsAsync(int id);
        void CreateBankBranches(BankBranches bankBranches);
        void UpdateBankBranches(BankBranches bankBranches);
        void DeleteBankBranches(BankBranches bankBranches);
        Task Update(int id);
    }
}
