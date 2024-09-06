using Business.Interfaces;
using Data.Interfaces;
using Entity.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.implements
{
    public class StateBusiness : IStateBusiness
    {
        private readonly IStateData data;

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
              
            });
            return stateDtos;
        }

        public async Task<State> GetById(int id)
        {
            return await this.data.GetById(id);
        }

        public State MappingData(State state, StateDto entity)
        {
            state.Id = entity.Id;
            state.Name = entity.Name;
        
            return state;
        }

        public async Task<State> Save(StateDto entity)
        {
            State state = new State
            {
                CreateAt = DateTime.Now.AddHours(-5)
            };
            state = MappingData(state, entity);
            state.state_id = null; 
            return await this.data.Save(state);
        }

        public async Task Update(StateDto entity)
        {
            State state = await this.data.GetById(entity.Id);
            if (state == null)
            {
                throw new Exception("Registro no encontrado");
            }
            state = MappingData(state, entity);
            await this.data.Update(state);
        }
    }
}
