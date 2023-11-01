using System;
using cu = Currency.DataAccess.Entities;

namespace Currency.CurrencyLogic.Contracts.Repositories
{
	public interface ICurrencyRepository
	{
        Task<cu.Currency> GetByIdAsync(int id);
        Task<IReadOnlyList<cu.Currency>> ListAllAsync();
        Task<cu.Currency> AddAsync(cu.Currency entity);
        Task UpdateAsync(cu.Currency entity);
        Task DeleteAsync(cu.Currency entity);
    }
}

