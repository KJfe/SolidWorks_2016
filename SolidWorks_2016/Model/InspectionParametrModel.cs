using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolidWorks_2016.Model.MyException;

namespace SolidWorks_2016.Model
{
    class InspectionParametrModel
    {
        public static double Parametr(string edit, string editDesc)
        {
            double doubleEdit = 0;
            try
            {
                doubleEdit = Convert.ToDouble(edit);
            }
            catch (Exception)
            {
                throw new CellFormatException(editDesc);
            }

            if (doubleEdit < 0)
            {
                throw new CellOutOfRangeException(editDesc);
            }
            return doubleEdit;
        }
    }
}
