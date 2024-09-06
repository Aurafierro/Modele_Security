using Business.implements;
using Business.Interfaces;
using Data.Implements;
using Data.Interfaces;
using Entity.Dto;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Interface;
using Web.Controllers.Interfaces;

namespace Web.Controllers.Implements
{
    [ApiController]
    [Route("[controller]")]
    public class CountriesController : ControllerBase, ICountriesController
    {
        private readonly ICountriesBusiness _countriesBusiness;

        public CountriesController(ICountriesBusiness countriesBusiness)
        {
            _countriesBusiness = countriesBusiness;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CountriesDto>>> GetAll()
        {
            var result = await _countriesBusiness.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CountriesDto>> GetById(int id)
        {
            var result = await _countriesBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<State>> Save([FromBody] CountriesDto countriesDto)
        {
            if (countriesDto == null)
            {
                return BadRequest("Entity is null");
            }

            var result = await _countriesBusiness.Save(countriesDto); ;
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] CountriesDto countriesDto)
        {
            if (countriesDto == null || countriesDto.Id == 0)
            {
                return BadRequest();
            }

            await _countriesBusiness.Update(countriesDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _countriesBusiness.Delete(id);
            return NoContent();
        }
    }
}
