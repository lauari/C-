using Entity.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IRoleBusiness
    {
        Task Delete(int id);
        Task<Role> Save(RoleDto entity);
        Task<IEnumerable<RoleDto>> GetAll();
        Task<RoleDto> GetById(int id);
        Task Update(RoleDto entity);
        Task<Role> GetByName(string name);
    }
}
