using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonManagement.Common.Entities
{
    public class Student : Person
    {
        public string StudentNumber { get; set; }
        public double AverageMark { get; set; }
    }
}
