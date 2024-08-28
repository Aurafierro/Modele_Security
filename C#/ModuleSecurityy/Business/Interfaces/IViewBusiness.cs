using Entity.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IViewBusiness
    {

        Task Delete(int id);
        Task<IEnumerable<ViewDto>> GetAll();
        Task<View> GetById(int id);
        Task<View> Save(ViewDto entity);
        Task Update(ViewDto entity);

    }
}
