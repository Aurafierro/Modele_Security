using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Data.Interfaces;

namespace Data.Implements
{
    public class PersonData : IPersonData
    {
        private readonly ApplicationDbContext _context;
        protected readonly IConfiguration _configuration;

        public DateTime DelatedAt { get; private set; }

        public PersonData(ApplicationDbContext context, IConfiguration configuration)
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
            _context.Roles.Update(entity);
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

        public async Task<PersonData> GetById(int id)
        {
            var sql = @"SELECT * FROM Role WHERE Id = @Id ORDER BY Id ASC";
            return await _context.QueryFirstOrDefaultAsync<PersonData>(sql, new { Id = id });
        }

        public async Task<PersonData> Save(PersonData entity)
        {
            _context.Roles.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(PersonData entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }



        public async Task<PersonData> GetByName(string name)
        {
            return await _context.Roles.AsNoTracking().Where(item =>
            {
                return item.Name
                       == name;
            }).FirstOrDefaultAsync();
        }

        public class DataSelectDto
        {
        }
    }
}

