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
    public class UserRoleData : IUserRoleData
    {
        private readonly ApplicationDBContext _context;
        private readonly IConfiguration _configuration;

        public UserRoleData(ApplicationDBContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            if (entity == null)
            {
                throw new Exception("Registro no encontrado");
            }

            entity.DelatedAt = DateTime.Now;
            _context.UserRoles.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT Id, CONCAT(Name, ' - ', Description) AS TextoMostrar
                        FROM Module
                        WHERE DelatedAt IS NULL AND State = 1
                        ORDER BY Id ASC";
            return await _context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<UserRole> GetById(int id)
        {

            var sql = @"SELECT * FROM parametro.Module WHERE Id = @Id ORDER BY Id ASC";


            return await _context.UserRoles
                .FromSqlRaw(sql, new { Id = id })
                .FirstOrDefaultAsync();
        }

        public async Task<UserRole> Save(UserRole entity)
        {
            _context.UserRoles.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(UserRole entity, DbContext dbContext)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }
        public async Task<UserRole> GetByCode(int code)
        {
            return await this._context.UserRoles.AsNoTracking().FirstOrDefaultAsync(item => item.Id == code);
        }



    }
}
