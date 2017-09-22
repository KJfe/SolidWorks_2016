using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidWorks_2016.Model.MyException
{
    public class CellRadiusException : ApplicationException
    {
        public CellRadiusException() : base(string.Format("Радиус основания не может быть меньше радиуска под посадочный квадрат"))
        {

        }
    }
}
