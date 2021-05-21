using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TredeWeb.DataLayer;

namespace TredeWeb.Interfaces
{
    public interface IUserToRolesRepository : IRepositoryBase<UserToRoles>
    {
        Task<IEnumerable<UserToRoles>> GetAllUserToRolesAsync();
        Task<UserToRoles> GetUserToRolesByIdAsync(int id);
        Task<UserToRoles> GetUserToRolesWithDetailsAsync(int id);
        void CreateUserToRoles(UserToRoles UserToRoles);
        void UpdateUserToRoles(UserToRoles UserToRoles);
        void DeleteUserToRoles(UserToRoles UserToRoles);
        Task Update(int id);

    }
}
