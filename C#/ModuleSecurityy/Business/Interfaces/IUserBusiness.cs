using Entity.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IUserBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<UserDto>> GetAll();
        Task<User> GetById(int id);
        Task<User> Save(UserDto entity);
        Task Update(UserDto entity);
    }
}
