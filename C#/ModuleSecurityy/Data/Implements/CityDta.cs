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
    public class CityDta : ICityDta
    {

        private readonly ApplicationDBContext context;
        protected readonly IConfiguration configuration;


        public CityDta(ApplicationDBContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()

        {
            var sql = @"SELECT
                Id,
                CONCAT(Name, ' -', PostalCode )
                FROM
                City
                WHERE Deleted_at IS NULL AND State = 1
                ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }
        public async Task<IEnumerable<City>> GetAll()

        {
            var sql = @"SELECT
                *
                FROM
                City
                WHERE Deleted_at IS NULL AND State = 1
                ORDER BY Id ASC";
            return await context.QueryAsync<City>(sql);
        }

        public async Task Delete(int Id)
        {
            var entity = await GetById(Id);
            if (entity == null)
            {
                throw new Exception("Registro NO encontrado");
            }
            entity.DeletedAt = DateTime.Parse(DateTime.Today.ToString());
            context.Citys.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task<City> GetById(int id)
        {
            var sql = @"SELECT * FROM City WHERE Id = @Id ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<City>(sql, new
            {
                Id = id
            });
        }

        public async Task<City> Save(City entity)

        {
            context.Citys.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }


        public async Task Update(City entity)
        {

            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }

        Task<City> ICityDta.Update(City entity)
        {
            throw new NotImplementedException();
        }
    }
}
