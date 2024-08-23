using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto
{
    public class RoleViewDto
    {
        public Boolean State { get; set; }

        public Role Role_id { get; set; }

        public View View_id { get; set; }
    }
}
