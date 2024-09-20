using Data.Interfaces;
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
    public class PersonData : IPersonData
    {
        private readonly ApplicationDBContext context;
        protected readonly IConfiguration configuration;

        public PersonData(ApplicationDBContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            if (entity == null)
                throw new Exception("Registro no encontrado");

            context.Person.Remove(entity);
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

        public async Task<Person> GetById(int id)
        {
            try
            {
                var sql = @"SELECT * FROM Person WHERE Id = @Id ORDER BY Id ASC";
                return await this.context.QueryFirstOrDefaultAsync<Person>(sql, new { Id = id });
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Person> Save(Person entity)
        {
            if (entity.City != null)
            {
                var existingcity = await context.City.FindAsync(entity.City.Id);
                if (existingcity != null)
                {
                    entity.City = existingcity;
                }
            }
            context.Person.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Person entity)
        {
            if (entity.City != null)
            {
                var existingCity = await context.City.FindAsync(entity.City.Id);

                if (existingCity != null)
                {
                    context.Entry(existingCity).State = EntityState.Unchanged;
                    entity.City = existingCity;
                }
            }

            context.Entry(entity).State = EntityState.Modified;

            await context.SaveChangesAsync();
        }

        public async Task<Person> GetByName(string name)
        {
            return await this.context.Person.AsNoTracking().Where(item => item.First_name == name).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<Person>> GetAll()
        {
            try
            {
                return await context.Person
                    .Where(s => s.State == true)
                    .OrderBy(s => s.Id)
                    .Include(s => s.City)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener todos los States", ex);
            }
        }
    }

}
