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
    public class userRoleBusiness : IUserRoleBusiness
    {
        protected readonly IUserRoleData data;
        public userRoleBusiness(IUserRoleData data)
        {
            this.data = data;
        }
        public async Task Delete(int id)
        {
            await this.data.Delete(id);
        }
        public async Task<IEnumerable<UserRoleDto>> GetAll()
        {
            IEnumerable<UserRole> userRoles = await this.data.GetAll();
            var userRoleDtos = userRoles.Select(UserRole => new UserRoleDto
            {
                Id = UserRole.Id,
                State = UserRole.State,
                User_id = UserRole.User_id,
                Role_id=UserRole.Role_id,



            });
            return userRoleDtos;
        }

        public Task<UserRole> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public UserRole MappingData(UserRole userRole, UserRoleDto entity)
        {
            userRole.Id = entity.Id;
            userRole.State = entity.State;
            userRole.User_id = entity.User_id;
            userRole.Role_id = entity.Role_id;


            return userRole;
        }
        public async Task<UserRole> Save(UserRoleDto entity)
        {
            UserRole userRole = new UserRole();
            userRole.CreateAt = DateTime.Now.AddHours(-5);
            userRole = this.MappingData(userRole, entity);
            userRole.userrole_id = null;

            return await this.data.Save(userRole);
        }

        public Task<User> Save(UserRole userRole)
        {
            throw new NotImplementedException();
        }

        public async Task Update(UserRoleDto entity)
        {
            UserRole userRole = await this.data.GetById(entity.Id);
            if (userRole == null)
            {
                throw new Exception("Registro no encontrado");
            }
            userRole = this.MappingData(userRole, entity);
            await this.data.Update(userRole);
        }

        public Task Update(UserRole userRole)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<UserRole>> IUserRoleBusiness.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
