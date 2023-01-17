using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.DAL
{
    public class Teacher : BaseEntity
    {
        public string Name { get; set; }
        public int School_Id { get; set; }
        public School school { get; set; }
        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
