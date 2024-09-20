using Entity.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IRoleViewBusiness
    {
        Task Delete(int id);
        Task<RoleViewDto> GetById(int id);
        Task<RoleView> Save(RoleViewDto entity);
        Task Update(RoleViewDto entity);
    }
}
