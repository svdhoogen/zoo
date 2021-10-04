using System.Collections.Generic;
using System.Threading.Tasks;
using Zoo.Core;
using Zoo.Core.Models;
using Zoo.Core.Services;

namespace Zoo.Services
{
    public class ZebraService : IZebraService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ZebraService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <inheritdoc />
        public async Task<List<Zebra>> GetAllAsync()
        {
            return await _unitOfWork.Zebras.GetAllAsync();
        }
    }
}