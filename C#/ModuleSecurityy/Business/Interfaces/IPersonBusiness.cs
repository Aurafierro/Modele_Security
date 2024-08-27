using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IPersonBusiness
    {
        Task<IEnumerable<Person>> GetAll();
    }
}
