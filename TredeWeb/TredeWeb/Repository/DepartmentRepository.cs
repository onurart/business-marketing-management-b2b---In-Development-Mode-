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
    public class DepartmentRepository : RepositoryBase<Departments>, IDeparmentsRepository
    {
        public DepartmentRepository(TradeDbContext context)
        : base(context)
        {
        }

        public void CreateDeparments(Departments Deparments)
        {
            Create(Deparments);
        }
        public void DeleteDeparments(Departments Deparments)
        {
            Delete(Deparments);
        }
        public void UpdateDeparments(Departments Deparments)
        {
            Update(Deparments);
        }



        public async Task<IEnumerable<Departments>> GetAllDeparmentsAsync()
        {
            return await FindAll()
                        .OrderBy(ow => ow.Id)
                        .ToListAsync();
        }
        public async Task<Departments> GetDeparmentsByIdAsync(int id)
        {
            return await FindByCondition(departmen => departmen.Id.Equals(id))
                           .FirstOrDefaultAsync();
        }
        public async Task<Departments> GetDeparmentsWithDetailsAsync(int id)
        {
            return await FindByCondition(department => department.Id.Equals(id))
          .Include(ac => ac.InverseParentDepartmentNavigation)
          .Include(ac => ac.Positions)
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
