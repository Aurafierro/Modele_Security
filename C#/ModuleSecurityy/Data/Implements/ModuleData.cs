using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implements
{
    internal class ModuleData : IModuleData
    {
        private readonly ApplicationDbContext _context;
        protected readonly IConfiguration _configuration;

        public DateTime DelatedAt { get; private set; }

        public ModuleData(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            if (entity == null)
                throw new Exception("Registro no encontrado");

            entity.DelatedAt = DateTime.Today;
            _context.Modules
                .Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT Id, CONCAT(Name, ' - ', Description) AS TextoMostrar
                        FROM Role
                        WHERE Deleted_at IS NULL AND State = 1
                        ORDER BY Id ASC";
            return await _context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<ModuleData> GetById(int id)
        {
            var sql = @"SELECT * FROM Role WHERE Id = @Id ORDER BY Id ASC";
            return await _context.QueryFirstOrDefaultAsync<ModuleData>(sql, new { Id = id });
        }

        public async Task<ModuleData> Save(ModuleData entity)
        {
            _context.Modules.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Module entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }


        private static EntityState GetModified()
        {
            return EntityState.Modified;
        }

        public async Task<Module> GetByDescription(string description) => await _context.Modules.AsNoTracking().Where(item => item.Description == description).FirstOrDefaultAsync();

        public class DataSelectDto
        {
        }
    }

    internal class ApplicationDbContext
    {
        internal object Entry(ModuleData entity)
        {
            throw new NotImplementedException();
        }

        internal Task<IEnumerable<T>> QueryAsync<T>(string sql)
        {
            throw new NotImplementedException();
        }

        internal Task<T> QueryFirstOrDefaultAsync<T>(string sql, object value)
        {
            throw new NotImplementedException();
        }

        internal async Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
    

