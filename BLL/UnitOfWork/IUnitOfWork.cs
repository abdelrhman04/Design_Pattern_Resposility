

using CORE;
using CORE.DAL;

namespace BLL
{
    public interface IUnitOfWork
    {

        IRepository<Student> Student { get; }
        IRepository<Teacher> Teacher { get; }
        IRepository<School> School { get; }
        void Save();
    }
}
