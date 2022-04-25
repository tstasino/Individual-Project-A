using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProjectA
{
    class AssignmentsPerStudent:Student
    {
        public Course Course { get; set; }
        public List<Assignment> Assignments;
    }
}
