using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IUserData
    {
        Task Delete(int id);
        Task<User> GetById(int id);
        Task<User> Save(User entity);
        Task Update(User entity);
    }
}
