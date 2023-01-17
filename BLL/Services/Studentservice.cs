

using AutoMapper;

namespace BLL
{
    public class Studentservice : IStudentservice
    {
        IUnitOfWork uow;
        IMapper mapper;
        public Studentservice(IUnitOfWork _uow, IMapper _mapper)
        {
            uow = _uow;
            mapper = _mapper;
        }

        public APIResponse Delete_Student()
        {
            throw new NotImplementedException();
        }

        public async Task<APIResponse> Get_All_Student()
        {
            StudentSpecification AllStudent = new StudentSpecification();
            var all = await uow.Student.GetAllAsync(AllStudent);
            //var all = uow.Student.Get();
            return new APIResponse
            {
                Data = all,
                Code = 200,
                IsError = false,
                Message = "return data"
            };
        }

        public APIResponse Get_By_Id_Student(int Id)
        {
            throw new NotImplementedException();
        }

        public APIResponse Store_Student()
        {
            throw new NotImplementedException();
        }

        public APIResponse Update_Student()
        {
            throw new NotImplementedException();
        }
    }
}
