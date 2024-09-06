using Entity.Dto;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interfaces
{
    public interface ICountriesController
    {
        Task<ActionResult<IEnumerable<CountriesDto>>> GetAll();
        Task<ActionResult<CountriesDto>> GetById(int id);
      
        Task<IActionResult> Update([FromBody] CountriesDto countriesDto);
        Task<IActionResult> Delete(int id);
    }
}
