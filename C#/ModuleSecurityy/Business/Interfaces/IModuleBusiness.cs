using Entity.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IModuleBusiness
    {
        Task<IEnumerable<ModuleDto>> GetAll();
        Task<Module> GetById(int id);
        Task<Module> Save(ModuleDto entity);
        Task Update(ModuleDto entity);
        Task Delete(int id);
    }
}
