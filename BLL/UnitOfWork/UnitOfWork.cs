
using CORE;
using CORE.DAL;
using Microsoft.EntityFrameworkCore;
using System;

namespace BLL
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly MyContext context;

        public UnitOfWork(MyContext _context)
        {
            context = _context;
        }

        private IRepository<Student> student;
        public IRepository<Student> Student
        {
            get { return student ?? (student = new Repository<Student>(context)); }
        }

        private IRepository<Teacher> teacher;
        public IRepository<Teacher> Teacher
        {
            get { return teacher ?? (teacher = new Repository<Teacher>(context)); }
        }

        private IRepository<School> school;
        public IRepository<School> School
        {
            get { return school ?? (school = new Repository<School>(context)); }
        }
        public void Save()
        {
            context.SaveChanges();
        }
        public void Dispose()
        {
            context.Dispose();
            System.GC.SuppressFinalize(this);
        }
    }
}
