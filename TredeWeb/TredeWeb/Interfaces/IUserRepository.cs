using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TredeWeb.DataLayer;

namespace TredeWeb.Interfaces
{
    public interface IUserRepository : IRepositoryBase<Users>
    {
        Task<IEnumerable<Users>> GetAllUserAsync();
        Task<Users> GetUserByIdAsync(int id);
        Task<Users> GetUserWithDetailsAsync(int id);
        void CreateUser(Users User);
        void UpdateUser(Users User);
        void DeleteUser(Users User);
        Task Update(int id);
    }
}
