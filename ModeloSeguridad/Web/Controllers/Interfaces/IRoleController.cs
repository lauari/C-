using Entity.Dto;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interfaces
{
    public interface IRoleController
    {
        Task<ActionResult<IEnumerable<RoleDto>>> GetAll();
        Task<ActionResult<RoleDto>> GetById(int id);
        Task<ActionResult<Role>> Save([FromBody] RoleDto roleviewDto);
        Task<IActionResult> Update([FromBody] RoleDto roleviewDto);
        Task<IActionResult> Delete(int id);
    }
}
