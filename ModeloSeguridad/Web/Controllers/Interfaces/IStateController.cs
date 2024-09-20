using Entity.Dto;
using Entity.Model.Security;

namespace Web.Controllers.Interfaces
{
    public interface IStateController
    {
        Task<IEnumerable<StateDto>> GetAll();
        Task<StateDto> GetById(int id);
        Task<State> Save(StateDto stateDto);
        Task Update(StateDto stateDto);
        Task Delete(int id);
    }
}
