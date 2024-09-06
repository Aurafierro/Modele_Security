using Entity.Dto;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interface
{
    public interface IRoleController
    {
        Task<ActionResult<IEnumerable<RoleDto>>> GetAll();
        Task<ActionResult<RoleDto>> GetById(int id);
        Task<ActionResult<Role>> Save([FromBody] RoleDto roleDto);
        Task<IActionResult> Update([FromBody] RoleDto roleDto);
        Task<IActionResult> Delete(int id);
    }
}