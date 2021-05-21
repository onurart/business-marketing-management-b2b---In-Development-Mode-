using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TredeWeb.DataLayer;
using TredeWeb.Interfaces;

namespace TredeWeb.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private IAccountRepository accountRepository;
        private ICategoriesRepository categoriesRepository;

        private IDeparmentsRepository deparmentsRepository;
        private IMarksRepository marksRepository;

        private IUserRepository userRepository;
        private IUserToRolesRepository userToRolesRepository;

        private readonly TradeDbContext _context;
        public RepositoryWrapper(TradeDbContext context)
        {

            _context = context;
        }


        public IAccountRepository Account
        {
            get
            {
                if (accountRepository == null)
                {
                    accountRepository = new AccountRepository(_context);
                }
                return accountRepository;
            }
        }

        public ICategoriesRepository Category
        {
            get
            {
                if (categoriesRepository == null)
                {
                    categoriesRepository = new CategoriesRepository(_context);
                }
                return categoriesRepository;
            }
        }

        public IDeparmentsRepository Deparment
        {
            get
            {
                if (deparmentsRepository == null)
                {
                    deparmentsRepository = new DepartmentRepository(_context);
                }
                return deparmentsRepository;
            }
        }
        public IMarksRepository Marks
        {
            get
            {
                if (marksRepository == null)
                {
                    marksRepository = new MarksRepository(_context);
                }
                return marksRepository;
            }
        }
        public IUserRepository User
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new UserRepository(_context);
                }
                return userRepository;
            }
        }
        public IUserToRolesRepository UserToRoles
        {
            get
            {
                if (userToRolesRepository == null)
                {
                    userToRolesRepository = new UserToRolesRepository(_context);
                }
                return userToRolesRepository;
            }
        }

    }
}
