using System.Collections.Generic;
using System.Threading.Tasks;
using Zoo.Core.Models;

namespace Zoo.Core.Services
{
    public interface IEnclosureService
    {
        /// <summary>
        /// Returns a list of all enclosures.
        /// </summary>
        /// <returns></returns>
        Task<List<Enclosure>> GetAllAsync();

        /// <summary>
        /// Returns a enclosure by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Enclosure> GetAsync(int id);

        /// <summary>
        /// Creates a new enclosure instance.
        /// </summary>
        /// <param name="enclosure"></param>
        /// <returns></returns>
        Task CreateAsync(Enclosure enclosure);

        /// <summary>
        /// Updates a enclosure.
        /// </summary>
        /// <param name="enclosure"></param>
        /// <returns></returns>
        Task UpdateAsync(Enclosure enclosure);

        /// <summary>
        /// Deletes a enclosure by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(int id);
    }
}