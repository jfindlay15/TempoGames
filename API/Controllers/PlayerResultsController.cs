using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerResultsController(IPlayerStatsService service) : ControllerBase
    {
        // GET: api/<GameResultsController>
        [HttpGet("{playerName}")]
        public async Task<IActionResult> Get(string playerName)
        {
            var data = await service.GetPlayerStats(playerName);

            if(data==null)
            {
                return new NotFoundResult();
            }

            return Ok(data);
        }       
    }
}
