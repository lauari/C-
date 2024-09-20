using Entity.Dto;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interfaces
{
    public interface ICityController
    {
        Task<IEnumerable<CityDto>> GetAll();
        Task<CityDto> GetById(int id);
        Task<ActionResult<City>> Save([FromBody] CityDto cityDto);
        Task Update(CityDto cityDto);
        Task Delete(int id);
        
    }
}
