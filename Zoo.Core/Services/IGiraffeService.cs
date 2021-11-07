using System.Collections.Generic;
using System.Threading.Tasks;
using Zoo.Core.Models;

namespace Zoo.Core.Services
{
    public interface IGiraffeService
    {
        /// <summary>
        /// Returns a list of all giraffes.
        /// </summary>
        /// <returns></returns>
        Task<List<Giraffe>> GetAllAsync();

        /// <summary>
        /// Returns a giraffe by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Giraffe> GetAsync(int id);

        /// <summary>
        /// Creates a new giraffe instance.
        /// </summary>
        /// <param name="giraffe"></param>
        /// <returns></returns>
        Task CreateAsync(Giraffe giraffe);

        /// <summary>
        /// Updates a giraffe.
        /// </summary>
        /// <param name="giraffe"></param>
        /// <returns></returns>
        Task UpdateAsync(Giraffe giraffe);

        /// <summary>
        /// Deletes a giraffe by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(int id);
    }
}