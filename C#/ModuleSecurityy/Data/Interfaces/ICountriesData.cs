using Entity.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface ICountriesData
    {
        Task Delete(int Id);
        Task<IEnumerable<Countries>> GetAll();
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<Countries> GetById(int id);
        Task<Countries> Save(Countries entity);
       
        public Task<Countries> Update(Countries entity);
    }
}
