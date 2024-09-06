using Entity.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface ICityBusiness
    {
        Task<IEnumerable<CityDto>> GetAll();
        Task<City> GetById(int id);
        Task<City> Save(CityDto entity);
        Task Update(CityDto entity);
        Task Delete(int id);
    }
}
