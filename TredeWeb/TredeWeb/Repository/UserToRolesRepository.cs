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
    public class UserToRolesRepository : RepositoryBase<UserToRoles>, IUserToRolesRepository
    {
        public UserToRolesRepository(TradeDbContext context)
        : base(context)
        {
        }
        public void CreateUserToRoles(UserToRoles UserToRoles)
        {
            Create(UserToRoles);
        }

        public void DeleteUserToRoles(UserToRoles UserToRoles)
        {
            Delete(UserToRoles);
        }

        public void UpdateUserToRoles(UserToRoles UserToRoles)
        {
            Update(UserToRoles);
        }



        public async Task<IEnumerable<UserToRoles>> GetAllUserToRolesAsync()
        {
            return await FindAll()
          .OrderBy(ow => ow.RoleId)
          .ToListAsync();
        }

        public async Task<UserToRoles> GetUserToRolesByIdAsync(int id)
        {
            return await FindByCondition(rl => rl.RoleId.Equals(id))
               .FirstOrDefaultAsync();
        }

        public async Task<UserToRoles> GetUserToRolesWithDetailsAsync(int id)
        {
            return await FindByCondition(rls => rls.RoleId.Equals(id))
                  .FirstOrDefaultAsync();
        }

        public Task Update(int id)
        {
            throw new NotImplementedException();
        }
        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }


    }
}
