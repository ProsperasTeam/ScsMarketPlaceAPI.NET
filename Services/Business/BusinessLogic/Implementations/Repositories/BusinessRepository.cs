using Business.BusinessLogic.Contracts.Repositories;
using Business.DataAccess;
using be = Business.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;


namespace Business.BusinessLogic.Implementations.Repositories
{
    public class BusinessRepository : IBusinessRepository
    {
        public AppDbContext Context { get; }
        public BusinessRepository(AppDbContext context)
        {
            Context = context;
        }

        public async Task<be.Business> GetByIdAsync(int id)
        {
            return await Context.Set<be.Business>().Where(e => e.Id == id).AsNoTracking().FirstOrDefaultAsync(); 
        }

        public async Task<IReadOnlyList<be.Business>> ListAllAsync()
        {
            return await Context.Business.AsNoTracking().ToListAsync();
        }

        public async Task<be.Business> AddAsync(DataAccess.Entities.Business entity)
        {
            await Context.AddAsync(entity);
            await Context.SaveChangesAsync();

            return entity;
        }

        public async Task UpdateAsync(be.Business entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }

        public async Task DeleteAsync(be.Business entity)
        {
            Context.Remove(entity);
            await Context.SaveChangesAsync();
        }   
       
    }
}
