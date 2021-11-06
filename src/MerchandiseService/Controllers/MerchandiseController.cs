using System.Threading;
using System.Threading.Tasks;
using MerchandiseHttpModels;
using MerchandiseService.Services;
using Microsoft.AspNetCore.Mvc;

namespace MerchandiseService.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class MerchandiseController : Controller
    {
        private readonly IMerchandiseService _merchandiseService;

        public MerchandiseController(IMerchandiseService merchandiseService)
        {
            _merchandiseService = merchandiseService;
        }
        
        [HttpPost("GetInfo")]
        public async ValueTask<IActionResult> GetMerchandiseInfo([FromBody] GetMerchandiseInfoRequest getMerchandiseInfoRequest, 
            CancellationToken ct)
        {
            await _merchandiseService.GetMerchandiseInfo(ct);
            return Ok(new GetMerchandiseInfoResponse());
        }
        
        [HttpPost("GiveOut")]
        public async ValueTask<IActionResult> GiveOutMerchandise([FromBody] GiveOutMerchandiseRequest giveOutMerchandiseRequest, 
            CancellationToken ct)
        {
            await _merchandiseService.GiveOutMerchandise(ct);
            return Ok(new GiveOutMerchandiseResponse());
        }
    }
}