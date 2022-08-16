using MetiJob.DataAccess;
using Microsoft.EntityFrameworkCore;
using MetiJob.Domain.Aggregates.Basic;

namespace MetiJob.Application.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BasicAggregate
    {
        private readonly DataContext _context;
        private readonly DbSet<TEntity> _dBSet;
        public GenericRepository(DataContext context)
        {
            _context = context;
            _dBSet = _context.Set<TEntity>();
        }

        public async Task AddEntity(TEntity entity)
        {
            entity.CreatedAt = DateTime.Now;
            await _context.AddAsync(entity);
        }

        public void DeleteEntity(TEntity entity)
        {
            entity.IsRemoved = true;
            EditEntity(entity);
        }

        public async Task DeleteEntity(long entityId)
        {
            DeleteEntity(await GetEntityById(entityId));
        }

        public void DeletePermanet(TEntity entity)
        {
            _context.Remove(entity);
        }

        public async Task DeletePermanet(long entityId)
        {
            DeletePermanet(await GetEntityById(entityId));
        }

        public async ValueTask DisposeAsync()
        {
            if (_context != null) await _context.DisposeAsync();

        }

        public void EditEntity(TEntity entity)
        {
            _context.Update(entity);
        }

        public async Task<TEntity> GetEntityById(long entityId)
        {
            return await _dBSet.SingleOrDefaultAsync(p => p.Id == entityId);
        }

        public IQueryable<TEntity> GetQuery()
        {
            return _dBSet.AsQueryable();
        }

        public async Task<bool> IsExist(long entityId)
        {
            if (await _dBSet.AnyAsync(p => p.Id == entityId)) return true;
            return false;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
