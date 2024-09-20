using Entity.Dto;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interfaces
{
    public interface IRoleViewController
    {
        //Task<ActionResult<IEnumerable<RoleViewDto>>> GetAll();
        Task<ActionResult<RoleViewDto>> GetById(int id);
        Task<ActionResult<RoleView>> Save([FromBody] RoleViewDto roleviewDto);
        Task<IActionResult> Update([FromBody] RoleViewDto roleviewDto);
        Task<IActionResult> Delete(int id);
    }
}
