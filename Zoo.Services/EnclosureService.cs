using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Zoo.Core.Data;
using Zoo.Core.Models;
using Zoo.Core.Services;

namespace Zoo.Services
{
    public class EnclosureService : IEnclosureService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EnclosureService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <inheritdoc />
        public async Task<List<Enclosure>> GetAllAsync()
        {
            // Return all enclosures
            return await _unitOfWork.GetAll<Enclosure>(tracking: false).ToListAsync();
        }

        /// <inheritdoc />
        public async Task<Enclosure> GetAsync(int id)
        {
            // Get enclosure
            var enclosure = await _unitOfWork.GetAll<Enclosure>(tracking: false).FirstAsync(enclosure => enclosure.Id == id);
            if (enclosure == null)
                throw new Exception($"Couldn't find enclosure by id: {id}");

            return enclosure;
        }

        /// <inheritdoc />
        public async Task CreateAsync(Enclosure enclosure)
        {
            // Create new enclosure
            await _unitOfWork.AddAsync(enclosure);
            await _unitOfWork.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task UpdateAsync(Enclosure enclosure)
        {
            // Get enclosure
            var enclosureDb = await GetAsync(enclosure.Id);

            // Update enclosure
            enclosureDb.Name = enclosure.Name;

            // Update enclosure
            _unitOfWork.Update(enclosureDb);
            await _unitOfWork.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task DeleteAsync(int id)
        {
            // Get enclosure
            var enclosure = await GetAsync(id);

            // Remove enclosure
            _unitOfWork.Remove(enclosure);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}