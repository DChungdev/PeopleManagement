using PersonManagement.Common.Data;
using PersonManagement.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonManagement.Infrastructure.Repository
{
    public class PersonRepository : Repository<Person>
    {
        public PersonRepository(SchoolContext context) : base(context)
        {
        }
    }
}
