using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TredeWeb.Interfaces
{
    public interface IRepositoryWrapper
    {
        IAccountRepository Account { get; }
        ICategoriesRepository Category { get; }
        IDeparmentsRepository Deparment { get; }

        IMarksRepository Marks { get; }
        IUserRepository User { get; }
        IUserToRolesRepository UserToRoles { get; }
    }
}
