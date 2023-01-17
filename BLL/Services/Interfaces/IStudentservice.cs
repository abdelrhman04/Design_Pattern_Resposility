using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IStudentservice
    {
        Task<APIResponse> Get_All_Student();
        APIResponse Update_Student();
        APIResponse Delete_Student();
        APIResponse Store_Student();
        APIResponse Get_By_Id_Student(int Id);
    }
}
