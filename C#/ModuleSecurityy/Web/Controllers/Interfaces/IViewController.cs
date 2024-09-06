using Entity.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interface
{
    public interface IViewController
    {

        Task<ActionResult<IEnumerable<ViewDto>>> GetAll();
        Task<ActionResult<ViewDto>> GetById(int id);
        Task<ActionResult<ViewDto>> Save([FromBody] ViewDto viewDto);
        Task<IActionResult> Update([FromBody] ViewDto viewDto);
        Task<IActionResult> Delete(int id);
    }
}