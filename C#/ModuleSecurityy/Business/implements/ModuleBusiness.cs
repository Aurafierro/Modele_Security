using Business.Interfaces;
using Data.Implements;
using Data.Interfaces;
using Entity.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.implements
{
    public class ModuleBusiness : IModuleBusiness
    {
        protected readonly IModuleData data;
        public ModuleBusiness(IModuleData data)
        {
            this.data = data;
        }
        public async Task Delete(int id)
        {
            await this.data.Delete(id);
        }
        public async Task<IEnumerable<ModuleDto>> GetAll()
        {
            IEnumerable<Module> modules = await this.data.GetAll();
            var ModuleDtos = modules.Select(module => new ModuleDto
            {
                Id = module.Id,
                State = module.State,
                Description = module.Description,


            });
            return ModuleDtos;
        }

        public Task<Module> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Module MappingData(Module module, ModuleDto entity)
        {
            module.Id = entity.Id;
            module.State = entity.State;
            module.Description = entity.Description;

            return module;
        }
        public async Task<Module> Save(ModuleDto entity)
        {
            Module module = new Module();
            module.CreateAt = DateTime.Now.AddHours(-5);
            module = this.MappingData(module, entity);
            module.Module_id = null;

            return await this.data.Save(module);
        }

        public Task<Module> Save(Module module)
        {
            throw new NotImplementedException();
        }

        public async Task Update(ModuleDto entity)
        {
            Module module = await this.data.GetById(entity.Id);
            if (module == null)
            {
                throw new Exception("Registro no encontrado");
            }
            module = this.MappingData(module, entity);
            await this.data.Update(module);
        }

        public Task Update(Module module)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<ModuleDto>> IModuleBusiness.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
