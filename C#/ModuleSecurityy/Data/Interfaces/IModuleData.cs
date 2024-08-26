using Entity.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IModuleData
    {
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<Entity.Model.Security.Module>> GetAll();
        Task Delete(int id);
        Task<Entity.Model.Security.Module> GetById(int id);
        Task<Entity.Model.Security.Module> Save(Entity.Model.Security.Module entity);
        Task<Entity.Model.Security.Module> Update(Entity.Model.Security.Module entity);
    }
}
