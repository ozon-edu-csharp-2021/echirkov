using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MerchandiseService.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class MerchendiseController : Controller
    {
        public MerchendiseController()
        { }
        
        [HttpGet("Merchendise")]
        public async ValueTask Get()
        {
            throw new NotImplementedException();
        }
    }
}