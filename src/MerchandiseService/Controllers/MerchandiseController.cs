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
            CancellationToken cancellationToken)
        {
            await _merchandiseService.GetMerchandiseInfo(cancellationToken);
            return Ok();
        }
        
        [HttpPost("GiveOut")]
        public async ValueTask<IActionResult> GiveOutMerchandise([FromBody] GiveOutMerchandiseResponse giveOutMerchandiseResponse, 
            CancellationToken cancellationToken)
        {
            await _merchandiseService.GiveOutMerchandise(cancellationToken);
            return Ok();
        }
    }
}