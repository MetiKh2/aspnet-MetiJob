using MetiJob.DataAccess;
using MetiJob.Domain.Aggregates.Basic;
using Microsoft.EntityFrameworkCore;

namespace MetiJob.Application.GenericRepository
{
    public interface IGenericRepository<TEntity> where TEntity : BasicAggregate
    {
        Task<bool> IsExist(long entityId);
        Task AddEntity(TEntity entity);
        void EditEntity(TEntity entity);
        Task<TEntity> GetEntityById(long entityId);
        void DeleteEntity(TEntity entity);
        Task DeleteEntity(long entityId);
        void DeletePermanet(TEntity entity);
        Task DeletePermanet(long entityId);
        Task SaveChangesAsync();
        IQueryable<TEntity> GetQuery();
    }


}