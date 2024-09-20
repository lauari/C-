using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IUserRoleData
    {
        Task Delete(int id);
        Task<UserRole> GetById(int id);
        Task<UserRole> Save(UserRole entity);
        Task Update(UserRole entity);
        public Task<IEnumerable<UserRole>> GetAll();

    }
}
