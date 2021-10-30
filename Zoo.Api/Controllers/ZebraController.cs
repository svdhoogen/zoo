using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Zoo.Core.Services;

namespace Zoo.Api.Controllers
{
    public class ZebraController : BaseController
    {
        private readonly IZebraService _zebraService;

        /// <summary>
        /// Constructor
        /// </summary>
        public ZebraController(IZebraService zebraService)
        {
            _zebraService = zebraService;
        }

        /// <summary>
        /// GET: /zebra
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            // Get zebras
            var zebras = _zebraService.GetAllAsync();

            return Ok(zebras);
        }
    }
}