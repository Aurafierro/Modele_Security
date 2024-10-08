﻿using Business.Interfaces;
using Data.Implements;
using Entity.Dto;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Interface;

namespace Web.Controllers.Implements
{
    [ApiController]
    [Route("[controller]")]
    public class RoleViewController : ControllerBase, IRoleViewController
    {
        private readonly IRoleviewBusiness _roleviewBusiness;

        public RoleViewController(IRoleviewBusiness roleviewBusiness)
        {
            _roleviewBusiness = roleviewBusiness;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleViewDto>>> GetAll()
        {
            var result = await _roleviewBusiness.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoleViewDto>> GetById(int id)
        {
            var result = await _roleviewBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<RoleView>> Save([FromBody] RoleViewDto roleViewDto)
        {
            if (roleViewDto == null)
            {
                return BadRequest("Entity is null");
            }

            var result = await _roleviewBusiness.Save(roleViewDto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] RoleViewDto roleViewDto)
        {
            if (roleViewDto == null || roleViewDto.Id == 0)
            {
                return BadRequest();
            }

            await _roleviewBusiness.Update(roleViewDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _roleviewBusiness.Delete(id);
            return NoContent();
        }
    }
}
