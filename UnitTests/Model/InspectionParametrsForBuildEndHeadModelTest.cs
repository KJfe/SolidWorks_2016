using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SolidWorks_2016.Model;
using SolidWorks_2016.Model.MyException;

namespace UnitTests.Model
{
    [TestFixture]
    class InspectionParametrsForBuildEndHeadModelTest
    {
        /// <summary>
        /// положительные тесты InspectionParametrsForBuildEndHeadModel
        /// </summary>
        /// <param name="heightFirstCylinder"></param>
        /// <param name="depthOfWorkSurface"></param>
        /// <returns></returns>
        [TestCase(3, 2, ExpectedResult = true, TestName = "InspectionParametrsForBuildEndHeadModel.InspectionHeightAndDeep при (3,2)")]
        [TestCase(5.5, 0.8, ExpectedResult = true, TestName = "InspectionParametrsForBuildEndHeadModel.InspectionHeightAndDeep при (5.5, 0.8)")]
        public bool InspectonParametrsForBuildEndHead(double heightFirstCylinder, double depthOfWorkSurface)
        {
            return InspectionParametrsForBuildEndHeadModel.InspectionHeightAndDeep(heightFirstCylinder, depthOfWorkSurface);
        }
        /// <summary>
        /// отрицательные тесты InspectionParametrsForBuildEndHeadModel
        /// </summary>
        /// <param name="heightFirstCylinder"></param>
        /// <param name="depthOfWorkSurface"></param>
        [TestCase(3, 10, TestName = "CellDeepExtrusionException при (3, 10)")]
        [TestCase(3.8, 4, TestName = "CellDeepExtrusionException при (3.8, 4)")]
        public void InspectonParametrCellDeepExtrusionException(double heightFirstCylinder, double depthOfWorkSurface)
        {
            Assert.Throws<CellDeepExtrusionException>(() => InspectionParametrsForBuildEndHeadModel.InspectionHeightAndDeep(heightFirstCylinder, depthOfWorkSurface));
        }
        /// <summary>
        /// отрицательные тесты InspectionParametrsForBuildEndHeadModel
        /// </summary>
        /// <param name="heightFirstCylinder"></param>
        /// <param name="depthOfWorkSurface"></param>
        [TestCase(3, 10, TestName = "CellRadiusException при (3, 10)")]
        [TestCase(3.8, 4, TestName = "CellRadiusException при (3.8, 4)")]
        public void InspectonParametrCellRadiusException(double heightFirstCylinder, double depthOfWorkSurface)
        {
            Assert.Throws<CellRadiusException>(() => InspectionParametrsForBuildEndHeadModel.InspectionFirstAndSecondRadius(heightFirstCylinder, depthOfWorkSurface));
        }
    }
}
