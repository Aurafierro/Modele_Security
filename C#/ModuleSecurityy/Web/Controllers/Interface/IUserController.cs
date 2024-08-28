using Entity.Dto;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interface
{
    public interface IUserController
    {
        Task<ActionResult<IEnumerable<UserDto>>> GetAll();
        Task<ActionResult<UserDto>> GetById(int id);
        Task<ActionResult<User>> Save([FromBody] UserDto entity);
        Task<IActionResult> Update([FromBody] UserDto entity);
        Task<IActionResult> Delete(int id);
    }
}
