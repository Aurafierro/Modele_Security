using Entity.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IViewData
    {
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<View>> GetAll();
        Task Delete(int id);
        Task<View> GetById(int id);
        Task<View> Save(View entity);
        Task<View> Update(View entity);
    }
}
