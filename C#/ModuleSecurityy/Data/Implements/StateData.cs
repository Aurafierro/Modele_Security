using Data.Interfaces;
using Entity.Context;
using Entity.Dto;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Data.Implements
{
    public class StateData : IStateData
    {

        private readonly ApplicationDBContext context;
        protected readonly IConfiguration configuration;


        public StateData(ApplicationDBContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()

        {
            var sql = @"SELECT
                Id,
                CONCAT(Name)
                FROM
                State
                WHERE Deleted_at IS NULL AND State = 1
                ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }
        public async Task<IEnumerable<State>> GetAll()

        {
            var sql = @"SELECT
                *
                FROM
                State
                WHERE Deleted_at IS NULL AND State = 1
                ORDER BY Id ASC";
            return await context.QueryAsync<State>(sql);
        }

        public async Task Delete(int Id)
        {
            var entity = await GetById(Id);
            if (entity == null)
            {
                throw new Exception("Registro NO encontrado");
            }
            entity.DeletedAt = DateTime.Parse(DateTime.Today.ToString());
            context.States.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task<State> GetById(int id)
        {
            var sql = @"SELECT * FROM State WHERE Id = @Id ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<State>(sql, new
            {
                Id = id
            });
        }

        public async Task<State> Save(State entity)

        {
            context.States.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }


        public async Task Update(State entity)
        {

            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }

        Task<City> IStateData.Update(State entity)
        {
            throw new NotImplementedException();
        }
    }
}
