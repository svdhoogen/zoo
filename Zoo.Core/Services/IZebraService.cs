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
    }
}