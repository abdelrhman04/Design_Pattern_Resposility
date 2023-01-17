using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface ITeacherServices
    {
        APIResponse Get_All_Teacher();
        APIResponse Update_Teacher();
        APIResponse Delete_Teacher();
        APIResponse Store_Teacher();
        APIResponse Get_By_Id_Teacher(int Id);
    }
}
