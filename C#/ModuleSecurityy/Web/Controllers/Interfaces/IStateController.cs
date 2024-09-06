using Entity.Dto;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interfaces
{
    public interface IStateController
    {
        Task<ActionResult<IEnumerable<StateDto>>> GetAll();
        Task<ActionResult<StateDto>> GetById(int id);
        Task<ActionResult<State>> Save([FromBody] StateDto stateDto);
        Task<IActionResult> Update([FromBody] StateDto stateDto);
        Task<IActionResult> Delete(int id);
    }
}
