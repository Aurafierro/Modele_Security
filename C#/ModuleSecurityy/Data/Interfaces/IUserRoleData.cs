using Entity.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    internal interface IUserRoleData
    {
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<UserRole>> GetAll();
        Task Delete(int id);
        Task<UserRole> GetById(int id);
        Task<UserRole> Save(UserRole entity);
        Task<UserRole> Update(UserRole entity);
    }
}
