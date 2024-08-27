using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Security
{
    public class Module
    {

        public int Id { get; set; }
        public string Description { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime UpdateAt { get; set; }

        public DateTime DelatedAt { get; set; }

        public Boolean State { get; set; }
        public DateTime DeletedAt { get; set; }
        public object Module_id { get; set; }
    }
}
