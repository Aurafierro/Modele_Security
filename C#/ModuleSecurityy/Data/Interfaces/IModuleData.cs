using Entity.Dto;
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
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<Module> GetById(int id);
        Task<Module> Save(Module entity);
        Task Update(Module entity);
        Task<Module> GetByCode(int code);
    }
}
