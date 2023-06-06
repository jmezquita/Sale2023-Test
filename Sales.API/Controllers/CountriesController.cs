using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sales.Api.Data;
using Sales.Shared.Entities;

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly DataContext _Context;

        public CountriesController(DataContext context)
        {
            _Context = context;
        }

        /// <summary>
        /// Get contries Async Data
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAsync() => Ok(await _Context.Countries.ToListAsync());


        /// <summary>
        /// Get contries Async Data
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var _country = await _Context.Countries.FirstOrDefaultAsync(w => w.Id == id);
            return (_country == null ? NotFound() : Ok(_country));
        }


        [HttpPost]
        public async Task<ActionResult> PostAsync(Country country)
        {

            try
            {

                _Context.Add(country);
                await _Context.SaveChangesAsync();

                return Ok(country);
            }
            catch (DbUpdateException upex)
            {

                if (upex.InnerException!.Message.Contains("duplicada"))
                {
                    return BadRequest("Ya existe un pais con el mismo nombre.");
                }

                return BadRequest(upex.Message);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(Country country)
        {

            try
            {
                _Context.Update(country);
                await _Context.SaveChangesAsync();

                return Ok(country);
            }
            catch (DbUpdateException updEx)
            {
                if (updEx.InnerException!.Message.Contains("duplicada"))
                {
                    return BadRequest("Ya existe un pais con el mismo nombre.");
                }

                return BadRequest(updEx.Message);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var _country = await _Context.Countries.FirstOrDefaultAsync(w => w.Id == id);
            if (_country != null)
            {
                _Context.Remove(_country);
                await _Context.SaveChangesAsync();
            }
            return NoContent();
        }

    }
}
