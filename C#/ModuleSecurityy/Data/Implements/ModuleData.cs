﻿using Data.Interfaces;
using Entity.Context;
using Entity.Dto;
using Entity.Model.Security; 
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;


namespace Data.Implements
{
    public class ModuleData : IModuleData
    {

        private readonly ApplicationDBContext context;
        protected readonly IConfiguration configuration;


        public ModuleData(ApplicationDBContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()

        {
            var sql = @"SELECT
                Id,
                Description
                FROM
                Module
                WHERE Deleted_at IS NULL AND State = 1
                ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }
        public async Task<IEnumerable<Module>> GetAll()

        {
            var sql = @"SELECT
                *
                FROM
                Module
                WHERE Deleted_at IS NULL AND State = 1
                ORDER BY Id ASC";
            return await context.QueryAsync<Module>(sql);
        }

        public async Task Delete(int Id)
        {
            var entity = await GetById(Id);
            if (entity == null)
            {
                throw new Exception("Registro NO encontrado");
            }
            entity.DeletedAt = DateTime.Parse(DateTime.Today.ToString());
            context.Modules.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task<Module> GetById(int id)
        {
            var sql = @"SELECT * FROM Module WHERE Id = @Id ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<Module>(sql, new
            {
                Id = id
            });
        }

        public async Task<Module> Save(Module entity)

        {
            context.Modules.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }


        public async Task Update(Module entity)
        {

            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }

        Task<Module> IModuleData.Update(Module entity)
        {
            throw new NotImplementedException();
        }
    }
}
