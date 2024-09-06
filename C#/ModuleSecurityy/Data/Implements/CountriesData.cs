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
    public class CountriesData : ICountriesData
    {

        private readonly ApplicationDBContext context;
        protected readonly IConfiguration configuration;


        public CountriesData(ApplicationDBContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()

        {
            var sql = @"SELECT
                Id,
                CONCAT(Name )
                FROM
                Countries 
                WHERE Deleted_at IS NULL AND State = 1
                ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }
        public async Task<IEnumerable<Countries>> GetAll()

        {
            var sql = @"SELECT
                *
                FROM
                Countries
                WHERE Deleted_at IS NULL AND State = 1
                ORDER BY Id ASC";
            return await context.QueryAsync<Countries>(sql);
        }

        public async Task Delete(int Id)
        {
            var entity = await GetById(Id);
            if (entity == null)
            {
                throw new Exception("Registro NO encontrado");
            }
            entity.DeletedAt = DateTime.Parse(DateTime.Today.ToString());
            context.contries.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task<Countries> GetById(int id)
        {
            var sql = @"SELECT * FROM Countries WHERE Id = @Id ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<Countries>(sql, new
            {
                Id = id
            });
        }

        public async Task<Countries> Save(Countries entity)

        {
            context.contries.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }


        public async Task Update(Countries entity)
        {

            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }

        Task<Countries> ICountriesData.Update(Countries Countries)
        {
            throw new NotImplementedException();
        }
    }
}
