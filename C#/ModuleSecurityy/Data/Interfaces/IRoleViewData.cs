using Entity.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IRoleViewData
    {
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<RoleView>> GetAll();
        Task Delete(int id);
        Task<RoleView> GetById(int id);
        Task<RoleView> Save(RoleView entity);
        Task<RoleView> Update(RoleView entity);
    }
}
