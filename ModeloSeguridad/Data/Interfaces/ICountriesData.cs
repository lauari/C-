using Entity.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface ICountriesData
    {
        Task<Countries> GetById(int id);
        Task<Countries> GetByName(string name);
        Task<Countries> Save(Countries entity);
        Task Update(Countries entity);
        Task Delete(int id);
        Task<IEnumerable<Countries>> GetAll();
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
    }
}
