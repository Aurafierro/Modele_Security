using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Security
{
    public class UserRole
    {

        public int Id { get; set; }



        public DateTime CreateAt { get; set; }

        public DateTime UpdateAt { get; set; }

        public DateTime DelatedAt { get; set; }


        public Boolean State { get; set; }

        public User User_id { get; set; }

        public Role Role_id { get; set; }

    }
}
