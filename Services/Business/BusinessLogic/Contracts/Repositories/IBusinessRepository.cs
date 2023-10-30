using be = Business.DataAccess.Entities;

namespace Business.BusinessLogic.Contracts.Repositories
{
    public interface IBusinessRepository
    {
        Task<be.Business> GetByIdAsync(int id);
        Task<IReadOnlyList<be.Business>> ListAllAsync();
        Task<be.Business> AddAsync(be.Business entity);
        Task UpdateAsync(be.Business entity);
        Task DeleteAsync(be.Business entity);
    }
}
