using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidWorks_2016.Model.MyException
{
    public class CellDeepExtrusionException : ApplicationException
    {
        public CellDeepExtrusionException() : base(string.Format("Глубина выреза рабочей поверхности не может быть больше высоты первого цилиндра"))
        {

        }
    }
}
