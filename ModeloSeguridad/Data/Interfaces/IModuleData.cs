using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IModuleData
    {
        Task Delete(int id);
        Task<Module> GetById(int id);
        Task<Module> Save(Module entity);
        Task Update(Module entity);
        Task<IEnumerable<Module>> GetAll();
        //Task<Module> GetByName(string name);
    }
}
