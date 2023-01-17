using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.DAL
{
    public class Student : BaseEntity
    {
        public string Name { get; set; }
        public int School_Id { get; set; }
        public int teacher_Id { get; set; }
        public School school { get; set; }
        public Teacher teacher { get; set; }
    }
}
