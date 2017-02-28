using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolidWorks_2016.Model.MyException;

namespace SolidWorks_2016.Model
{
    class InspectionParametrsForBuildEndHeadModel
    {
        public static void Parametrs(double heightFirstCylinder, double depthOfWorkSurface)
        {
            if (heightFirstCylinder < depthOfWorkSurface)
            {
                throw new CellDeepExtrusionException();
            }
            
        }
    }
}
