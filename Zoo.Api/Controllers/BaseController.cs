using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Zoo.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Policy = "Api")]
    public abstract class BaseController : Controller
    {

    }
}