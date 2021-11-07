using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Zoo.Core.Models;
using Zoo.Core.Services;

namespace Zoo.Api.Controllers
{
    public class ZebraController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IZebraService _zebraService;

        /// <summary>
        /// Constructor
        /// </summary>
        public ZebraController(IMapper mapper, IZebraService zebraService)
        {
            _mapper = mapper;
            _zebraService = zebraService;
        }

        /// <summary>
        /// GET: /zebra
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Get zebras
            var zebras = await _zebraService.GetAllAsync();

            return Ok(zebras);
        }

        /// <summary>
        /// GET: /zebra/{id}
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            // Get zebra
            var zebra = await _zebraService.GetAsync(id);

            return Ok(zebra);
        }

        /// <summary>
        /// POST: /zebra/create
        /// </summary>
        /// <returns></returns>
        [HttpPost("create")]
        public async Task<IActionResult> Create(ViewModels.Zebra.Create.RequestViewModel request)
        {
            // Map zebra
            var zebra = _mapper.Map<ViewModels.Zebra.Create.RequestViewModel, Zebra>(request);

            // Create zebras
            await _zebraService.CreateAsync(zebra);

            return Ok();
        }

        /// <summary>
        /// PUT: /zebra/update
        /// </summary>
        /// <returns></returns>
        [HttpPut("update")]
        public async Task<IActionResult> Update(ViewModels.Zebra.Update.RequestViewModel request)
        {
            // Map zebra
            var zebra = _mapper.Map<ViewModels.Zebra.Update.RequestViewModel, Zebra>(request);

            // Update zebras
            await _zebraService.UpdateAsync(zebra);

            return Ok();
        }

        /// <summary>
        /// DELETE: /zebra/{id}
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            // Delete zebras
            await _zebraService.DeleteAsync(id);

            return Ok();
        }
    }
}