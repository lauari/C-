﻿using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Data.Interfaces
{
    public interface IRoleData
    {
        Task Delete(int id);
        Task<Role> GetById(int id);
        Task<Role> Save(Role entity);
        Task Update(Role entity);
        Task<Role> GetByName(string name);
    }
}
