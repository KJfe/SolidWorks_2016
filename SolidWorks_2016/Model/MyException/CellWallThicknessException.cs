using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidWorks_2016.Model.MyException
{
    public class CellWallThicknessException:Exception
    {
        public CellWallThicknessException(string editDesc) : base(string.Format("Толщина стенки не может быть меньше 1 мм, в {0}", editDesc))
        {

        }
    }
}
