using Entity.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interface
{
    public interface IUserRoleController
    {
        Task<ActionResult<IEnumerable<UserRoleDto>>> GetAll();
        Task<ActionResult<UserRoleDto>> GetById(int id);
        Task<ActionResult<UserRoleDto>> Save([FromBody] UserRoleDto entity);
        Task<IActionResult> Update([FromBody] UserRoleDto entity);
        Task<IActionResult> Delete(int id);
    }
}
