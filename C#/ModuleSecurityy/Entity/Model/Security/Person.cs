using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Security
{
    public class Person
    {

        public int Id { get; set; }

        public string First_name { get; set; }

        public string Last_name { get; set; }

        public string Email { get; set; }

        public string Type_document { get; set; }

        public string Document { get; set; }

        public DateTime Birth_of_date { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime UpdateAt { get; set; }

        public DateTime DelatedAt { get; set; }

        public Boolean State { get; set; }
        public DateTime DeletedAt { get; set; }
        public object person_id { get; set; }
    }
       
    
}
