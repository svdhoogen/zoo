using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Zoo.Core.Models;
using Zoo.Core.Services;

namespace Zoo.Api.Controllers
{
    public class EnclosureController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IEnclosureService _enclosureService;

        /// <summary>
        /// Constructor
        /// </summary>
        public EnclosureController(IMapper mapper, IEnclosureService enclosureService)
        {
            _mapper = mapper;
            _enclosureService = enclosureService;
        }

        /// <summary>
        /// GET: /enclosure
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Get enclosures
            var enclosures = await _enclosureService.GetAllAsync();

            return Ok(enclosures);
        }

        /// <summary>
        /// GET: /enclosure/{id}
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            // Get enclosure
            var enclosure = await _enclosureService.GetAsync(id);

            return Ok(enclosure);
        }

        /// <summary>
        /// POST: /enclosure
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(ViewModels.Enclosure.Create.RequestViewModel request)
        {
            // Map enclosure
            var enclosure = _mapper.Map<ViewModels.Enclosure.Create.RequestViewModel, Enclosure>(request);

            // Create enclosures
            await _enclosureService.CreateAsync(enclosure);

            return Ok();
        }

        /// <summary>
        /// PUT: /enclosure
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(ViewModels.Enclosure.Update.RequestViewModel request)
        {
            // Map enclosure
            var enclosure = _mapper.Map<ViewModels.Enclosure.Update.RequestViewModel, Enclosure>(request);

            // Update enclosures
            await _enclosureService.UpdateAsync(enclosure);

            return Ok();
        }

        /// <summary>
        /// DELETE: /enclosure/{id}
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            // Delete enclosures
            await _enclosureService.DeleteAsync(id);

            return Ok();
        }
    }
}