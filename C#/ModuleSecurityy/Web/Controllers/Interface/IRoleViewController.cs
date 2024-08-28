using Entity.Dto;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interface
{
    public interface IRoleViewController
    {
        Task<ActionResult<IEnumerable<RoleViewDto>>> GetAll();
        Task<ActionResult<RoleViewDto>> GetById(int id);
        Task<ActionResult<RoleView>> Save([FromBody] RoleViewDto entity);
        Task<IActionResult> Update([FromBody] RoleViewDto entity);
        Task<IActionResult> Delete(int id);
    }
}
