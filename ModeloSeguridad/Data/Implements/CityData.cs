using Data.Interfaces;
using Entity.Context;
using Entity.Dto;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.Implements
{
    public class CityData : ICityData
    {
        private readonly ApplicationDBContext context;
        protected readonly IConfiguration configuration;

        public CityData(ApplicationDBContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            if (entity == null)
                throw new Exception("Registro no encontrado");

            context.City.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<City> GetById(int id)
        {
            var sql = @"SELECT * FROM City WHERE Id = @Id ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<City>(sql, new { Id = id });
        }
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            try
            {
                var sql = @"
                    SELECT Id, CONCAT(Name) AS TextoMostrar
                    FROM State
                    WHERE Deleted_at IS NULL AND State = 1
                    ORDER BY Id ASC";

                return await this.context.QueryAsync<DataSelectDto>(sql);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de selección de States", ex);
            }
        }
        public async Task<City> Save(City entity)
        {
            if (entity.State != null)
            {
                var existingstate = await context.State.FindAsync(entity.State.Id);
                if (existingstate != null)
                {
                    entity.State = existingstate;
                }
            }
            context.City.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(City entity)
        {
            if (entity.State != null)
            {
                var existingState = await context.State.FindAsync(entity.State.Id);

                if (existingState != null)
                {
                    context.Entry(existingState).State = EntityState.Unchanged;
                    entity.State = existingState;
                }
            }

            context.Entry(entity).State = EntityState.Modified;

            await context.SaveChangesAsync();
        }

        public async Task<City> GetByName(string name)
        {
            return await this.context.City.AsNoTracking().Where(item => item.Name == name).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<City>> GetAll()
        {
            try
            {
                return await context.City
                    .Where(s => s.Estado == true)
                    .OrderBy(s => s.Id)
                    .Include(s => s.State)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener todos los States", ex);
            }
        }
    }
}
