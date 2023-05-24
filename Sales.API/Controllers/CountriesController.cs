using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sales.Api.Data;
using Sales.Shared.Entities;

namespace Sales.Api.Controllers
{
    [ApiController]
    [Route("/api/countries")]
    public class CountriesController:ControllerBase
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
        public async Task<IActionResult> GetAsync() =>  Ok(await _Context.Countries.ToListAsync());

        [HttpPost]
        public async Task<ActionResult> PostAsync(Country country)
        {
            //try
            //{
                _Context.Add(country);
               await _Context.SaveChangesAsync();

                return Ok(country);
            //}
            //catch (Exception)
            //{

            //    return ;
            //}
        }

    }
}
