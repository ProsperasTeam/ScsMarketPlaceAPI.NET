using  Lenders.DataAccess.Entities;

namespace Lenders.LendersLogic.Contracts.Repositories
{
    public interface ILendersRepository
    {
        Task<Lender> GetByIdAsync(int id);
        Task<IReadOnlyList<Lender>> ListAllAsync();
        Task<Lender> AddAsync(Lender entity);
        Task UpdateAsync(Lender entity);
        Task DeleteAsync(Lender entity);
    }
}
