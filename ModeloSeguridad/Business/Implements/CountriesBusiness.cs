using Business.Interface;
using Data.Implements;
using Data.Interfaces;
using Entity.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implements
{
    public class CountriesBusiness : ICountriesBusiness
    {
        protected readonly ICountriesData data;

        public CountriesBusiness(ICountriesData data)
        {
            this.data = data;
        }

        public async Task Delete(int id)
        {
            await this.data.Delete(id);
        }

        public async Task<IEnumerable<CountriesDto>> GetAll()
        {
            IEnumerable<Countries> countries = await this.data.GetAll();
            var countriesDtos = countries.Select(countries => new CountriesDto
            {
                Id = countries.Id,
                Name = countries.Name,
                State = countries.State,
            });

            return countriesDtos;
        }

        public async Task<CountriesDto> GetById(int id)
        {
            Countries countries = await this.data.GetById(id);
            CountriesDto countriesDto = new CountriesDto
            {
                Id = countries.Id,
                Name = countries.Name,
                State=countries.State,
            };
            return countriesDto;
        }

        public Countries mapearDatos(Countries countries, CountriesDto entity)
        {
            countries.Id = entity.Id;
            countries.Name = entity.Name;
            countries.State = entity.State;
            return countries;
        }

        public async Task<Countries> Save(CountriesDto entity)
        {
            Countries countries = new Countries
            {
                CreateAt = DateTime.Now.AddHours(-5)
            };
            countries = this.mapearDatos(countries, entity);

            return await this.data.Save(countries);
        }

        public async Task Update(CountriesDto entity)
        {
            Countries countries = await this.data.GetById(entity.Id);
            if (countries == null)
            {
                throw new Exception("Registro no encontrado");
            }

            countries = this.mapearDatos(countries, entity);
            await this.data.Update(countries);
        }
    }
}
