using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolidWorks_2016.Model.MyException;

namespace SolidWorks_2016.Model
{
    public class InspectionParametrsForBuildEndHeadModel
    {
        public static bool InspectionHeightAndDeep(double heightFirstCylinder, double depthOfWorkSurface)
        {
            if (heightFirstCylinder < depthOfWorkSurface)
            {
                throw new CellDeepExtrusionException();
            }
            else return true;
        }

        public static bool InspectionFirstAndSecondRadius(double firstRadius, double secondRadius)
        {
            if (firstRadius < secondRadius)
            {
                throw new CellRadiusException();
            }
            else return true;
        }
    }
}
