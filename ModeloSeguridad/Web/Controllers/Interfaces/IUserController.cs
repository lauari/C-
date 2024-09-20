using Entity.Dto;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Web.Controllers.Interfaces
{
    public interface IUserController
    {
        Task<ActionResult<UserDto>> GetById(int id);
        Task<ActionResult<User>> Save([FromBody] UserDto userDto);
        Task<IActionResult> Update([FromBody] UserDto userDto);
        Task<IActionResult> Delete(int id);

    }
}
