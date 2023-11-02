using Lenders.LendersLogic.Contracts.Repositories;
using Lenders.DataAccess;
using Lenders.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;


namespace Lenders.LendersLogic.Implementations.Repositories
{
    public class LendersRepository : ILendersRepository
    {
        public AppDbContext Context { get; }
        public LendersRepository(AppDbContext context)
        {
            Context = context;
        }

        public async Task<Lender> GetByIdAsync(int id)
        {
            return await Context.Set<Lender>().Where(e => e.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<Lender>> ListAllAsync()
        {
            return await Context.Lenders.AsNoTracking().ToListAsync();
        }

        public async Task<Lender> AddAsync(Lender entity)
        {
            await Context.AddAsync(entity);
            await Context.SaveChangesAsync();

            return entity;
        }

        public async Task UpdateAsync(Lender entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Lender entity)
        {
            Context.Remove(entity);
            await Context.SaveChangesAsync();
        }

    }
}
