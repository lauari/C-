﻿

using Data.Interfaces;
using Entity.Context;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.Implements
{
    public class RoleData : IRoleData
    {
        private readonly ApplicationDBContext context;
        protected readonly IConfiguration configuration;

        public RoleData(ApplicationDBContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        public async Task Delete(int id)
        {
                var entity = await GetById(id);
                if (entity == null)
                    throw new Exception("Registro no encontrado");

                entity.DeleteAt = DateTime.Parse(DateTime.Today.ToString());
                context.Role.Update(entity);
                await context.SaveChangesAsync();
            }


        //public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        //{
        //    var sql = @"SELECT Id, CONCAT(Name, ' - ', Description) AS TextoMostrar
        //                FROM Role
        //                WHERE Deleted_at IS NULL AND State = 1
        //                ORDER BY Id ASC";
        //    return await context.QueryAsync<DataSelectDto>(sql);
        //}

        public async Task<Role> GetById(int id)
        {
            try
            {
                var sql = @"SELECT * FROM Role WHERE Id = @Id ORDER BY Id ASC";
                return await this.context.QueryFirstOrDefaultAsync<Role>(sql, new { Id = id });
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<Role> Save(Role entity)
        {

                context.Role.Add(entity);
                await context.SaveChangesAsync();
                return entity;
            }
       

        public async Task Update(Role entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<Role> GetByName(string name)
        {

                return await this.context.Role.AsNoTracking().Where(item => item.Name == name).FirstOrDefaultAsync();
            }
         

        //public async Task<IEnumerable<Role>> GetAll()
        //{
        //    var sql = @"SELECT * FROM Role ORDER BY Id ASC";
        //    return await this.context.QueryAsync<Role>(sql);
        //}
    }
}
