using System.Collections.Generic;
using System.Threading.Tasks;
using Zoo.Core.Models;

namespace Zoo.Core.Repositories
{
    public interface IZebraRepository
    {
        /// <summary>
        /// Returns a list of all zebras.
        /// </summary>
        /// <returns></returns>
        Task<List<Zebra>> GetAllAsync();

        /// <summary>
        /// Returns zebra enclosure.
        /// </summary>
        /// <returns></returns>
        Task<Enclosure> GetEnclosureAsync();
    }
}