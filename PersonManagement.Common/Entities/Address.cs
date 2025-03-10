﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonManagement.Common.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }

        public ICollection<Person> People { get; set; }
    }
}
