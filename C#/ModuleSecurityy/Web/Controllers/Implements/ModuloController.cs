using Business.Interfaces;
using Entity.Dto;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using Web.Controllers.Interface;

namespace Web.Controllers.Implements
{
    [ApiController]
    [Route("[controller]")]
    public class ModuloController : ControllerBase, IModuleController
    {
        private readonly IModuleBusiness _moduloBusiness;

        public ModuloController(IModuleBusiness moduloBusiness)
        {
            _moduloBusiness = moduloBusiness;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModuleDto>>> GetAll()
        {
            var result = await _moduloBusiness.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ModuleDto>> GetById(int id)
        {
            var result = await _moduloBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Entity.Model.Security.Module>> Save([FromBody] ModuleDto moduleDto)
        {
            if (moduleDto == null)
            {
                return BadRequest("Entity is null");
            }

            var result = await _moduloBusiness.Save(moduleDto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] ModuleDto moduleDto)
        {
            if (moduleDto == null || moduleDto.Id == 0)
            {
                return BadRequest();
            }

            await _moduloBusiness.Update(moduleDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _moduloBusiness.Delete(id);
            return NoContent();
        }


    }
}
