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
    public class RoleData : IRoleData
    {

        private readonly ApplicationDBContext context;
        protected readonly IConfiguration configuration;


        public RoleData(ApplicationDBContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()

        {
            var sql = @"SELECT Id, CONCAT(Name, ' - ', Description) AS TextoMostrar
                        FROM Role
                        WHERE DelatedAt IS NULL AND State = 1
                        ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }
        public async Task<IEnumerable<Role>> GetAll()

        {
            var sql = @"SELECT
                *
                FROM
                Module
                WHERE Deleted_at IS NULL AND State = 1
                ORDER BY Id ASC";
            return await context.QueryAsync<Role>(sql);
        }

        public async Task Delete(int Id)
        {
            var entity = await GetById(Id);
            if (entity == null)
            {
                throw new Exception("Registro NO encontrado");
            }
            entity.DelatedAt = DateTime.Parse(DateTime.Today.ToString());
            context.Roles.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task<Role> GetById(int id)
        {
            var sql = @"SELECT * FROM Role WHERE Id = @Id ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<Role>(sql, new
            {
                Id = id
            });
        }

        public async Task<Role> Save(Role entity)

        {
            context.Roles.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }


        public async Task Update(Role entity)
        {

            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }

        Task<Role> IRoleData.Update(Role entity)
        {
            throw new NotImplementedException();
        }
    }
}
