
using AutoMapper;

namespace BLL
{
    public class TeacherServices : ITeacherServices
    {
        IUnitOfWork uow;
        IMapper mapper;
        public TeacherServices(IUnitOfWork _uow, IMapper _mapper)
        {
            uow = _uow;
            mapper = _mapper;
        }
        public APIResponse Delete_Teacher()
        {
            throw new NotImplementedException();
        }

        public APIResponse Get_All_Teacher()
        {
            var all = uow.Teacher.Get();
            return new APIResponse
            {
                Data= all,
                Code=200,
                IsError=false,
                Message="return data"
            };
        }

        public APIResponse Get_By_Id_Teacher(int Id)
        {
            throw new NotImplementedException();
        }

        public APIResponse Store_Teacher()
        {
            throw new NotImplementedException();
        }

        public APIResponse Update_Teacher()
        {
            throw new NotImplementedException();
        }
    }
}
