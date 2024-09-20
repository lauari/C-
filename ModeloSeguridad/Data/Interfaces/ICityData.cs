using Entity.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface ICityData
    {
        Task<City> GetById(int id);
        Task<City> GetByName(string name);
        Task<City> Save(City entity);
        Task Update(City entity);
        Task Delete(int id);
        Task<IEnumerable<City>> GetAll();
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
    }
}
