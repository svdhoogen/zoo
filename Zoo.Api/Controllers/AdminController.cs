using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Zoo.Core.Services;

namespace Zoo.Api.Controllers
{
    [Authorize(Policy = "Admin")]
    public class AdminController : BaseController
    {
        private readonly ISeederService _seederService;

        /// <summary>
        /// Constructor
        /// </summary>
        public AdminController(ISeederService seederService)
        {
            _seederService = seederService;
        }

        /// <summary>
        /// GET: /admin/seed
        /// </summary>
        /// <returns></returns>
        [HttpGet("seed")]
        public async Task<IActionResult> Seed()
        {
            await _seederService.SeedAsync();

            return Ok();
        }
    }
}