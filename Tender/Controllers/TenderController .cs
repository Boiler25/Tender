using Microsoft.AspNetCore.Mvc;
using TenderApi.Services;

namespace TenderApi.Controllers
{
    [ApiController]
    [Route("api/tenders")]
    public class TenderController : ControllerBase
    {
        private readonly ITenderService _tenderService;

        public TenderController(ITenderService tenderService)
        {
            _tenderService = tenderService;
        }

        [HttpGet]
        public IActionResult GetTenders()
        {
            var tenders = _tenderService.GetAllTenders();
            return Ok(tenders);
        }
    }
}
