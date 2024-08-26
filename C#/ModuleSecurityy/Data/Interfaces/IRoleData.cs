using Entity.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IRoleData
    {
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<Role>> GetAll();
        Task Delete(int id);
        Task<Role> GetById(int id);
        Task<Role> Save(Role entity);
        Task<Role> Update(Role entity);
    }
}
