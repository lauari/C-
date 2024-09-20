﻿using Business.Interface;
using Business.Interfaces;
using Data.Interfaces;
using Entity.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implements
{
    public class StateBusiness : IStateBusiness
    {
        protected readonly IStateData data;

        public StateBusiness(IStateData data)
        {
            this.data = data;
        }

        public async Task Delete(int id)
        {
            await this.data.Delete(id);
        }

        public async Task<IEnumerable<StateDto>> GetAll()
        {
            IEnumerable<State> states = await this.data.GetAll();
            var stateDtos = states.Select(state => new StateDto
            {
                Id = state.Id,
                Name = state.Name,
                state = state.state,
                CountriesId = state.CountriesId,
                Countries=state.Countries.Name,
            });

            return stateDtos;
        }

        public async Task<StateDto> GetById(int id)
        {
            State state = await this.data.GetById(id);
            StateDto stateDto = new StateDto
            {
                Id = state.Id,
                Name = state.Name,
                state = state.state,
                CountriesId = state.CountriesId,
                Countries=state.Countries.Name,
            };

            return stateDto;
        }

        public State mapearDatos(State state, StateDto entity)
        {
            state.Id = entity.Id;
            state.Name = entity.Name;
            state.state = entity.state;
            state.CountriesId = entity.CountriesId;

            return state;
        }

        public async Task<State> Save(StateDto entity)
        {
            State state = new State
            {
                CreateAt = DateTime.Now.AddHours(-5)
            };
            state = this.mapearDatos(state, entity);

            return await this.data.Save(state);
        }

        public async Task Update(StateDto entity)
        {
            State state = await this.data.GetById(entity.Id);
            if (state == null)
            {
                throw new Exception("Registro no encontrado");
            }

            state = this.mapearDatos(state, entity);
            await this.data.Update(state);
        }
    }
}
