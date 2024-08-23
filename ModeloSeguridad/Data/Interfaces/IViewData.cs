
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IViewData
    {
        Task Delete(int id);
        Task<View> GetById(int id);
        Task<View> Save(View entity);
        Task Update(View entity);

        Task<IEnumerable<View>> GetAll();
    }
}
