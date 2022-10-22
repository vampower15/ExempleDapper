using ExempleDapper.Interfaces;
using ExempleDapper.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExempleDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThailandPostController : Controller
    {
        private readonly IThailandPost _state;
        public ThailandPostController(IThailandPost state)
        {
            _state = state;
        }

        [HttpGet("All")]
        public async Task<IActionResult> ThailandPostAll()
        {
            try
            {
                var states = await _state.GetThailandPostAsync();
                return Ok(states);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);

            }
        }

        [HttpGet("{ZipCode}")]
        public async Task<IActionResult> GetThailandPostByIdAsync(string ZipCode)
        {
            try
            {
                var states = await _state.GetThailandPostByIdAsync(ZipCode);
                if (states is null)
                    return NotFound();

                return Ok(states);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> InsertThailandPost(ThailandPostModel model)
        {
            try
            {
                await _state.InsertThailandPostAsync(model);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateThailandPost(string id, ThailandPostModel model)
        {
            try
            {
                var states = await _state.GetThailandPostByIdAsync(id);
                if (states is null)
                    return NotFound();

                await _state.UpdateThailandPostAsync(states.ZipCode, model);
                return NoContent();

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteThailandPost(string id)
        {
            try
            {
                var states = await _state.GetThailandPostByIdAsync(id);
                if (states is null)
                    return NotFound();

                await _state.DeleteThailandPostAsync(states.ZipCode);
                return NoContent();

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
