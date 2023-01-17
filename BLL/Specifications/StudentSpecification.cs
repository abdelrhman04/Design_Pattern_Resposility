using CORE.DAL;
using CORE.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BLL
{
    public class StudentSpecification : BaseSpecification<Student>
    {
        public StudentSpecification(Student_FilterParam productParams) : base(x =>
          (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search))
          )
        {
            AddOrderBy(p => p.Name);

            var skip = productParams.PageSize * (productParams.PageIndex - 1);
            var take = productParams.PageSize;
            ApplyPaging(skip, take);
        }

        public StudentSpecification(int id) : base(x => x.Id == id)
        {

        }
        public StudentSpecification(Expression<Func<Student, bool>> filter = null, Expression<Func<Student, object>> orderBy =null , params Expression<Func<Student, object>>[] includes) : base(filter)
        {
            foreach (Expression<Func<Student, object>> include in includes)
                AddInclude(include);
            if (orderBy !=null)
                AddOrderBy( orderBy);
        }

    }
}
