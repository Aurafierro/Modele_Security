using Entity.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IUserRoleBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<UserRoleDto>> GetAll();
        Task<UserRole> GetById(int id);
        Task<UserRole> Save(UserRoleDto entity);
        Task Update(UserRoleDto entity);
    }
}
