using System.Collections.Generic;
using System.Threading.Tasks;
using Zoo.Core;
using Zoo.Core.Models;
using Zoo.Core.Services;

namespace Zoo.Services
{
    public class GiraffeService : IGiraffeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GiraffeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <inheritdoc />
        public async Task<List<Giraffe>> GetAllAsync()
        {
            return await _unitOfWork.Giraffes.GetAllAsync();
        }
    }
}