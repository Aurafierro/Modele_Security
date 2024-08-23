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
    public class ModuleData : IModuleData
    {
        private readonly ApplicationDBContext _context;
        private readonly IConfiguration _configuration;
        private object dbContext;

        public ModuleData(ApplicationDBContext context, IConfiguration configuration)
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
            _context.Modules.Update(entity);
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


        public async Task<Entity.Model.Security.Module> GetById(int id)
        {
       
            var sql = @"SELECT * FROM parametro.Module WHERE Id = @Id ORDER BY Id ASC";

           
            return await _context.Modules
                .FromSqlRaw(sql, new { Id = id }) 
                .FirstOrDefaultAsync(); 
        }

        public async Task<Entity.Model.Security.Module> Save(Entity.Model.Security.Module entity)
        {
            _context.Modules.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Entity.Model.Security.Module entity, DbContext dbContext)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }
        public async Task<Entity.Model.Security.Module> GetByCode(int code)
        {
            return await this._context.Modules.AsNoTracking().FirstOrDefaultAsync(item => item.Id == code);
        }

      
      
    }
}
