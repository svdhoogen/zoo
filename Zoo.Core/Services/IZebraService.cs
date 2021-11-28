using System.Collections.Generic;
using System.Threading.Tasks;
using Zoo.Core.Models;

namespace Zoo.Core.Services
{
    public interface IZebraService
    {
        /// <summary>
        /// Returns a list of all zebras.
        /// </summary>
        /// <returns></returns>
        Task<List<Zebra>> GetAllAsync();

        /// <summary>
        /// Returns a zebra by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Zebra> GetAsync(int id);

        /// <summary>
        /// Creates a new zebra instance.
        /// </summary>
        /// <param name="zebra"></param>
        /// <returns></returns>
        Task CreateAsync(Zebra zebra);

        /// <summary>
        /// Updates a zebra.
        /// </summary>
        /// <param name="zebra"></param>
        /// <returns></returns>
        Task UpdateAsync(Zebra zebra);

        /// <summary>
        /// Deletes a zebra by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(int id);
    }
}