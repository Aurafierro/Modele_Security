using Entity.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IRoleviewBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<RoleViewDto>> GetAll();
        Task<RoleView> GetById(int id);
        Task<RoleView> Save(RoleViewDto entity);
        Task Update(RoleViewDto entity);
    }
}
