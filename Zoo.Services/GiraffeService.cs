using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Zoo.Core.Data;
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
            return await _unitOfWork.GetAll<Giraffe>(tracking: false).ToListAsync();
        }
    }
}