using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Zoo.Core.Data;
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
            // Return all zebras
            return await _unitOfWork.GetAll<Zebra>(tracking: false).ToListAsync();
        }

        /// <inheritdoc />
        public async Task<Zebra> GetAsync(int id)
        {
            // Get zebra
            var zebra = await _unitOfWork.GetAll<Zebra>(tracking: false).FirstAsync(zebra => zebra.Id == id);
            if (zebra == null)
                throw new Exception($"Couldn't find zebra by id: {id}");

            return zebra;
        }

        /// <inheritdoc />
        public async Task CreateAsync(Zebra zebra)
        {
            // Create new zebra
            await _unitOfWork.AddAsync(zebra);
            await _unitOfWork.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task UpdateAsync(Zebra zebra)
        {
            // Get zebra
            var zebraDb = await GetAsync(zebra.Id);

            // Update zebra
            zebraDb.Name = zebra.Name;
            zebraDb.EnclosureId = zebra.EnclosureId;

            // Update zebra
            _unitOfWork.Update(zebraDb);
            await _unitOfWork.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task DeleteAsync(int id)
        {
            // Get zebra
            var zebra = await _unitOfWork.GetAll<Zebra>(tracking: true)
                .FirstOrDefaultAsync(zebra => zebra.Id == id);

            // Remove zebra
            _unitOfWork.Remove(zebra);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}