using ExempleDapper.Interfaces;
using ExempleDapper.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace ExempleDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomelandController : ControllerBase
    {
        private readonly IHomeland _book;
        public HomelandController(IHomeland book)
        {
            _book = book;
        }

        [HttpGet("All")]
        public async Task<IActionResult> HomelandAll()
        {
            try
            {
                var books = await _book.GetHomelandAllAsync();
                return Ok(books);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);

            }
        }
    
        [HttpGet("ById")]
        public async Task<IActionResult> HomelandById(int id)
        {
            try
            {
                var book = await _book.GetHomelandByIdAsync(id);
                if (book is null)
                    return NotFound();

                return Ok(book);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> InsertHomeland(HomelandNotId model)
        {
            try
            {
                await _book.InsertHomelandAsync(model);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateHomeland(int id, HomelandNotId model)
        {
            try
            {
                var book = await _book.GetHomelandByIdAsync(id);
                if (book is null)
                    return NotFound();

                await _book.UpdateHomelandAsync(book.IdBk, model);
                return NoContent();

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteHomeland(int id)
        {
            try
            {
                var book = await _book.GetHomelandByIdAsync(id);
                if (book is null)
                    return NotFound();

                await _book.DeleteHomelandAsync(book.IdBk);
                return NoContent();

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
