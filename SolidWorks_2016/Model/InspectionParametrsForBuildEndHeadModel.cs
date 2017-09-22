using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolidWorks_2016.Model.MyException;

namespace SolidWorks_2016.Model
{
    /// <summary>
    /// Класс проверяющий данные на коректность
    /// </summary>
    public class InspectionParametrsForBuildEndHeadModel
    {
        /// <summary>
        /// Проверка, что выота должна быть больше глубины выреза
        /// </summary>
        /// <param name="heightFirstCylinder"></param>
        /// <param name="depthOfWorkSurface"></param>
        /// <returns></returns>
        public static bool InspectionHeightAndDeep(double heightFirstCylinder, double depthOfWorkSurface)
        {
            if (heightFirstCylinder < depthOfWorkSurface)
            {
                throw new CellDeepExtrusionException();
            }
            else return true;
        }
        /// <summary>
        /// Проверка, что первый радиус  должен быть больше второго радиуса 
        /// </summary>
        /// <param name="firstRadius"></param>
        /// <param name="secondRadius"></param>
        /// <returns></returns>
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
