using LightPi.Data;
using LightPi.Shared;
using Microsoft.AspNetCore.Mvc;

namespace LightPi.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LightsController : ControllerBase
    {
        private readonly ILogger<LightsController> _logger;
        private readonly LightsContext _context;

        public LightsController(ILogger<LightsController> logger, LightsContext lightsContext)
        {
            _logger = logger;
            _context = lightsContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Light>> GetLights()
        {
            //TODO add filter querry and pageing when necessary due to lartge quantities of stored lights
            return Ok(_context.Lights);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Light>> GetLight(int id)
        {
            var found = await _context.Lights.FindAsync(id);
            if (found != null)
            {
                return Ok(found);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<Light>> CreateLight([FromBody] Light lightToAdd)
        {
            await _context.Lights.AddAsync(lightToAdd);

            await _context.SaveChangesAsync();
            return CreatedAtRoute(lightToAdd.LightID, lightToAdd);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Light>> UpdateLight(int id, [FromBody] Light updateWith)
        {
            var found = await _context.Lights.FindAsync(id);
            if (found == null)
            {
                return NotFound();
            }

            if (updateWith.LightID != null && found.LightID != updateWith.LightID)
            {
                return BadRequest($"The {nameof(Light.LightID)} value of the request model must either be blank or match the requested {nameof(id)} in the request Path!");
            }

            found.Update(updateWith);
            await _context.SaveChangesAsync();

            return Ok(found);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<Light>>> DeleteLight(int id)
        {
            var found = await _context.Lights.FindAsync(id);
            if (found == null)
            {
                return NotFound();
            }
            _context.Lights.Remove(found);

            await _context.SaveChangesAsync();

            return Ok(GetLights());
        }
    }
}