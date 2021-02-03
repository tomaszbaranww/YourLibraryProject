﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace NowyProjekt.Model
{
    class Member
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
