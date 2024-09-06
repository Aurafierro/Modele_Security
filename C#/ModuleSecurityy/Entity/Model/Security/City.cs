﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Security
{
    public class City
    {
        
        public object city_id;

        public int Id { get; set; }

        public string Name { get; set; }

        public string Postalcode { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime UpdateAt { get; set; }

        
        public DateTime DeletedAt { get; set; }
    }
}
