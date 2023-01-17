using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface ISchoolService
    {
        APIResponse Get_All_School();
        APIResponse Update_School();
        APIResponse Delete_School();
        APIResponse Store_School();
        APIResponse Get_By_Id_School(int Id);
    }
}
