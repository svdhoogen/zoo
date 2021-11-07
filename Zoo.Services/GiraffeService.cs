using System;
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
            // Return all giraffes
            return await _unitOfWork.GetAll<Giraffe>(tracking: false).ToListAsync();
        }

        /// <inheritdoc />
        public async Task<Giraffe> GetAsync(int id)
        {
            // Get giraffe
            var giraffe = await _unitOfWork.GetAll<Giraffe>(tracking: false).FirstAsync(giraffe => giraffe.Id == id);
            if (giraffe == null)
                throw new Exception($"Couldn't find giraffe by id: {id}");

            return giraffe;
        }

        /// <inheritdoc />
        public async Task CreateAsync(Giraffe giraffe)
        {
            // Create new giraffe
            await _unitOfWork.AddAsync(giraffe);
            await _unitOfWork.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task UpdateAsync(Giraffe giraffe)
        {
            // Get giraffe
            var giraffeDb = await GetAsync(giraffe.Id);

            // Update giraffe
            giraffeDb.Name = giraffe.Name;
            giraffeDb.NeckLengthInCm = giraffe.NeckLengthInCm;
            giraffeDb.EnclosureId = giraffe.EnclosureId;

            // Update giraffe
            _unitOfWork.Update(giraffe);
            await _unitOfWork.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task DeleteAsync(int id)
        {
            // Get giraffe
            var giraffe = await GetAsync(id);

            // Remove giraffe
            _unitOfWork.Remove(giraffe);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}