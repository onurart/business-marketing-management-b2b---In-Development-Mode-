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
    public class BankBranchesRepository : RepositoryBase<BankBranches>, IBankBranchesRepository
    {
        public BankBranchesRepository(TradeDbContext context)
       : base(context)
        {
        }

        public void CreateBankBranches(BankBranches bankBranches)
        {
            CreateBankBranches(bankBranches);
        }
        public void DeleteBankBranches(BankBranches bankBranches)
        {
            DeleteBankBranches(bankBranches);
        }
        public void UpdateBankBranches(BankBranches bankBranches)
        {
            UpdateBankBranches(bankBranches);
        }


        public async Task<IEnumerable<BankBranches>> GetAllBankBranchesAsync()
        {

            return await FindAll()
               .OrderBy(ow => ow.Name)
               .ToListAsync();
        }
        public async Task<BankBranches> GetBankBranchesByIdAsync(int id)
        {
            return await FindByCondition(ac => ac.Id.Equals(id))
              .FirstOrDefaultAsync();
        }
        public async Task<BankBranches> GetBankBranchesWithDetailsAsync(int id)
        {
            return await FindByCondition(ac => ac.Id.Equals(id))
                            .Include(ac => ac.FnBankLines)
                  .FirstOrDefaultAsync();
        }

        public async Task Update(int id)
        {
            await context.SaveChangesAsync();
        }
    }
}

