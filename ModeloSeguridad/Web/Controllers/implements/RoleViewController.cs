using Business.Interfaces;
using Entity.Dto;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.implements
{
    [ApiController]
    [Route("[controller]")]
    public class RoleViewController : ControllerBase
    {
        private readonly IRoleViewBusiness _roleviewBusiness;

        public RoleViewController(IRoleViewBusiness roleviewBusiness)
        {
            _roleviewBusiness = roleviewBusiness;
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<RoleViewDto>>> GetAll()
        //{
        //    var result = await _roleviewBusiness.GetAll();
        //    return Ok(result);
        //}

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
        public async Task<ActionResult<RoleView>> Save([FromBody] RoleViewDto roleviewDto)
        {
            if (roleviewDto == null)
            {
                return BadRequest("Entity is null");
            }

            var result = await _roleviewBusiness.Save(roleviewDto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] RoleViewDto roleviewDto)
        {
            if (roleviewDto == null || roleviewDto.Id == 0)
            {
                return BadRequest();
            }

            await _roleviewBusiness.Update(roleviewDto);
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

