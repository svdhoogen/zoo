using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Zoo.Core.Data;
using Zoo.Core.Models;

namespace Zoo.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _dbContext;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbContext"></param>
        public UnitOfWork(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<TModel> GetAll<TModel>(bool tracking) where TModel : class, IModel
            => tracking ? _dbContext.Set<TModel>().AsQueryable() : _dbContext.Set<TModel>().AsNoTracking().AsQueryable();

        public async Task AddAsync<TModel>(TModel model) where TModel : class, IModel
            => await _dbContext.AddAsync(model);

        public async Task AddRangeAsync<TModel>(List<TModel> models) where TModel : class, IModel
            => await _dbContext.AddRangeAsync(models);

        public void UpdateAsync<TModel>(TModel model) where TModel : class, IModel
            => _dbContext.Update(model);

        public void UpdateRangeAsync<TModel>(List<TModel> models) where TModel : class, IModel
            => _dbContext.UpdateRange(models);

        public void RemoveAsync<TModel>(TModel model) where TModel : class, IModel
            => _dbContext.Remove(model);

        public void RemoveRangeAsync<TModel>(List<TModel> models) where TModel : class, IModel
            => _dbContext.RemoveRange(models);

        public async Task SaveChangesAsync() => await _dbContext.SaveChangesAsync();

        public async Task<IDbContextTransaction> BeginTransactionAsync() => await _dbContext.Database.BeginTransactionAsync();
    }
}