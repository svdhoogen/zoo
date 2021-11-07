using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Zoo.Core.Models;
using Zoo.Core.Services;

namespace Zoo.Api.Controllers
{
    public class GiraffeController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IGiraffeService _giraffeService;

        /// <summary>
        /// Constructor
        /// </summary>
        public GiraffeController(IMapper mapper, IGiraffeService giraffeService)
        {
            _mapper = mapper;
            _giraffeService = giraffeService;
        }

        /// <summary>
        /// GET: /giraffe
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Get giraffes
            var giraffes = await _giraffeService.GetAllAsync();

            return Ok(giraffes);
        }

        /// <summary>
        /// GET: /giraffe/{id}
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            // Get giraffe
            var giraffe = await _giraffeService.GetAsync(id);

            return Ok(giraffe);
        }

        /// <summary>
        /// POST: /giraffe/create
        /// </summary>
        /// <returns></returns>
        [HttpPost("create")]
        public async Task<IActionResult> Create(ViewModels.Giraffe.Create.RequestViewModel request)
        {
            // Map giraffe
            var giraffe = _mapper.Map<ViewModels.Giraffe.Create.RequestViewModel, Giraffe>(request);

            // Create giraffes
            await _giraffeService.CreateAsync(giraffe);

            return Ok();
        }

        /// <summary>
        /// PUT: /giraffe/update
        /// </summary>
        /// <returns></returns>
        [HttpPut("update")]
        public async Task<IActionResult> Update(ViewModels.Giraffe.Update.RequestViewModel request)
        {
            // Map giraffe
            var giraffe = _mapper.Map<ViewModels.Giraffe.Update.RequestViewModel, Giraffe>(request);

            // Update giraffes
            await _giraffeService.UpdateAsync(giraffe);

            return Ok();
        }

        /// <summary>
        /// DELETE: /giraffe/{id}
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            // Delete giraffes
            await _giraffeService.DeleteAsync(id);

            return Ok();
        }
    }
}