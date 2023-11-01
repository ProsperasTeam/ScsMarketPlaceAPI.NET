using System;
using Currency.CurrencyLogic.Contracts.Repositories;
using Currency.DataAccess;
using cu = Currency.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Currency.CurrencyLogic.Implementations.Repositories
{
	public class CurrencyRepository : ICurrencyRepository
	{
        public AppDbContext Context { get; }
        public CurrencyRepository(AppDbContext context)
        {
            Context = context;
        }

        public async Task<cu.Currency> GetByIdAsync(int id)
        {
            return await Context.Set<cu.Currency>().Where(e => e.Id == id).AsNoTracking().FirstOrDefaultAsync();

        }

        public async Task<IReadOnlyList<cu.Currency>> ListAllAsync()
        {
            return await Context.Currency.AsNoTracking().ToListAsync();

        }

        public async Task<cu.Currency> AddAsync(cu.Currency entity)
        {
            await Context.AddAsync(entity);
            await Context.SaveChangesAsync();

            return entity;
        }

        public async Task UpdateAsync(cu.Currency entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }

        public async Task DeleteAsync(cu.Currency entity)
        {
            Context.Remove(entity);
            await Context.SaveChangesAsync();
        }
        
    }
}

