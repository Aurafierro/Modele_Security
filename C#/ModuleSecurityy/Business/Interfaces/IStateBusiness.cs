using Entity.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IStateBusiness
    {

        Task Delete(int id);
        Task<State> GetById(int id);
        Task<IEnumerable<StateDto>> GetAll();
        Task<State> Save(StateDto entity);
        Task Update(StateDto entity);
    }
}
