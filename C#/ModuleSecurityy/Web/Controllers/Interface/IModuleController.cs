using Entity.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interface
{ 

   public interface IModuleController
{
    Task<ActionResult<IEnumerable<ModuleDto>>> GetAll();
    Task<ActionResult<ModuleDto>> GetById(int id);
    Task<ActionResult<ModuleDto>> Save([FromBody] ModuleDto entity);
    Task<IActionResult> Update([FromBody] ModuleDto entity);
    Task<IActionResult> Delete(int id);
}
}
