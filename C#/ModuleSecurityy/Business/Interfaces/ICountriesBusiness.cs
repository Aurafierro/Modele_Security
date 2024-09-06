using Entity.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface ICountriesBusiness
    {
        Task<IEnumerable<CountriesDto>> GetAll();
        Task<Countries> GetById(int id);
     
        Task Update(CountriesDto entity);
        Task Delete(int id);
        Task<CountriesDto> Save(CountriesDto countriesDto);
    }
}
