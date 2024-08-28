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

   
    public class userBusiness : IUserBusiness
    {
        protected readonly IUserData data;
        public userBusiness(IUserData data)
        {
            this.data = data;
        }
        public async Task Delete(int id)
        {
            await this.data.Delete(id);
        }
        public async Task<IEnumerable<UserDto>> GetAll()
        {
            IEnumerable<User> users = await this.data.GetAll();
            var userDtos = users.Select(User => new UserDto
            {
                Id = User.Id,
                Username = User.Username,
                Password = User.Password,



            });
            return userDtos;
        }

        public Task<User> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public User MappingData(User user, UserDto entity)
        {
            user.Id = entity.Id;
            user.Username = entity.Username;
            user.Password = entity.Password;


            return user;
        }
        public async Task<User> Save(UserDto entity)
        {
            User user = new User();
            user.CreateAt = DateTime.Now.AddHours(-5);
            user = this.MappingData(user, entity);
            user.user_id = null;

            return await this.data.Save(user);
        }

        public Task<User> Save(User user)
        {
            throw new NotImplementedException();
        }

        public async Task Update(UserDto entity)
        {
            User user = await this.data.GetById(entity.Id);
            if (user == null)
            {
                throw new Exception("Registro no encontrado");
            }
            user = this.MappingData(user, entity);
            await this.data.Update(user);
        }

        public Task Update(User user)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<UserDto>> IUserBusiness.GetAll()
        {
            throw new NotImplementedException();
        }

        
    }
}
