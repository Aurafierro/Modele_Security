using Business.Interfaces;
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
    public class roleBusiness : IRoleBusiness
    {
        protected readonly IRoleData data;
        public roleBusiness(IRoleData data)
        {
            this.data = data;
        }
        public async Task Delete(int id)
        {
            await this.data.Delete(id);
        }
        public async Task<IEnumerable<RoleDto>> GetAll()
        {
            IEnumerable<Role> rols = await this.data.GetAll();
            var roleDtos = rols.Select(Role => new RoleDto
            {
                Id = Role.Id,
                Description = Role.Description,
                Name = Role.Name,
             
          

            });
            return roleDtos;
        }

        public Task<Role> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Role MappingData(Role role, RoleDto entity)
        {
            role.Id = entity.Id;
            role.Name = entity.Name;
            role.Description = entity.Description;
           

            return role;
        }
        public async Task<Role> Save(RoleDto entity)
        {
            Role role = new Role();
            role.CreateAt = DateTime.Now.AddHours(-5);
            role = this.MappingData(role, entity);
            role.role_id = null;

            return await this.data.Save(role);
        }

        public Task<Role> Save(Role role)
        {
            throw new NotImplementedException();
        }

        public async Task Update(RoleDto entity)
        {
            Role role = await this.data.GetById(entity.Id);
            if (role == null)
            {
                throw new Exception("Registro no encontrado");
            }
            role = this.MappingData(role, entity);
            await this.data.Update(role);
        }

        public Task Update(Role role)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<RoleDto>> IRoleBusiness.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
