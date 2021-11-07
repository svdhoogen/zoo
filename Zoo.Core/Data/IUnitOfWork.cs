using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using Zoo.Core.Models;

namespace Zoo.Core.Data
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// Returns queryable of all entries of type present in database context.
        /// </summary>
        /// <param name="tracking"></param>
        /// <typeparam name="TModel"></typeparam>
        /// <returns></returns>
        IQueryable<TModel> GetAll<TModel>(bool tracking) where TModel : class, IModel;

        Task AddAsync<TModel>(TModel model) where TModel : class, IModel;

        Task AddRangeAsync<TModel>(List<TModel> models) where TModel : class, IModel;

        void Update<TModel>(TModel model) where TModel : class, IModel;

        void UpdateRange<TModel>(List<TModel> models) where TModel : class, IModel;

        void Remove<TModel>(TModel model) where TModel : class, IModel;

        void RemoveRange<TModel>(List<TModel> models) where TModel : class, IModel;

        Task SaveChangesAsync();

        Task<IDbContextTransaction> BeginTransactionAsync();

        void DetachEntity<TModel>(TModel model) where TModel : class, IModel;
    }
}