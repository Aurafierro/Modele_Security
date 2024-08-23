using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto
{
    public class UserRoleDto
    {
        public Boolean State { get; set; }

        public User User_id { get; set; }

        public Role Role_id { get; set; }
    }
}
