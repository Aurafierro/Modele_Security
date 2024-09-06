using Entity.Dto;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interface
{

    public interface IModuleController
    {
        Task<ActionResult<IEnumerable<ModuleDto>>> GetAll();
        Task<ActionResult<ModuleDto>> GetById(int id);
        Task<ActionResult<Module>> Save([FromBody] ModuleDto moduleDto);
        Task<IActionResult> Update([FromBody] ModuleDto moduleDto);
        Task<IActionResult> Delete(int id);
    }
}