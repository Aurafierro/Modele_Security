using Entity.Dto;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interface
{
    public interface IPersonController
    {
        Task<ActionResult<IEnumerable<PersonDto>>> GetAll();
        Task<ActionResult<PersonDto>> GetById(int id);
        Task<ActionResult<Person>> Save([FromBody] PersonDto personDto);
        Task<IActionResult> Update([FromBody] PersonDto personDto);
        Task<IActionResult> Delete(int id);
    }
}