﻿using Data.Interfaces;
using Entity.Context;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implements
{
    public class ViewData : IViewData
    {
        private readonly ApplicationDBContext context;
        protected readonly IConfiguration configuration;

        public ViewData(ApplicationDBContext context, IConfiguration configuration)
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
            context.View.Update(entity);
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

        public async Task<View> GetById(int id)
        {
            try
            {
                var sql = @"SELECT * FROM Role WHERE Id = @Id ORDER BY Id ASC";
                return await this.context.QueryFirstOrDefaultAsync<View>(sql, new { Id = id });
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<View> Save(View entity)
        {
            context.View.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(View entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<View>> GetAll()
        {
            var sql = @"SELECT * FROM Role ORDER BY Id ASC";
            return await this.context.QueryAsync<View>(sql);
        }

        //public async Task<RoleView> GetByName(string name)
        //{
        //    return await this.context.RoleView.AsNoTracking().Where(item => item.First_name == name).FirstOrDefaultAsync();
    }
}
