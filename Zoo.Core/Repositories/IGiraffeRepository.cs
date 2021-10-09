using System.Collections.Generic;
using System.Threading.Tasks;
using Zoo.Core.Models;

namespace Zoo.Core.Repositories
{
    public interface IGiraffeRepository
    {
        /// <summary>
        /// Returns a list of all giraffes.
        /// </summary>
        /// <returns></returns>
        Task<List<Giraffe>> GetAllAsync();

        /// <summary>
        /// Returns giraffe enclosure.
        /// </summary>
        /// <returns></returns>
        Task<Enclosure> GetEnclosureAsync();
    }
}