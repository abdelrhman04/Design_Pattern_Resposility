using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SchoolService : ISchoolService
    {
        IUnitOfWork uow;
        IMapper mapper;
        public SchoolService(IUnitOfWork _uow, IMapper _mapper)
        {
            uow = _uow;
            mapper = _mapper;
        }
        public APIResponse Delete_School()
        {
            throw new NotImplementedException();
        }

        public APIResponse Get_All_School()
        {
            var all = uow.School.Get();
            return new APIResponse
            {
                Data = all,
                Code = 200,
                IsError = false,
                Message = "return data"
            };
        }

        public APIResponse Get_By_Id_School(int Id)
        {
            throw new NotImplementedException();
        }

        public APIResponse Store_School()
        {
            throw new NotImplementedException();
        }

        public APIResponse Update_School()
        {
            throw new NotImplementedException();
        }
    }
}
