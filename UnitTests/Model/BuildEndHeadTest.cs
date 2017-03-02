using NUnit.Framework;
using SolidWorks_2016.Model;
using SolidWorks_2016.ViewModel;

namespace UnitTests.Model
{
    [TestFixture]
    public class BuildEndHeadTest
    {
        [Test]
        [TestCase(true, "17", "10", "20", "12", "18", "1", "2", "C:\\test\\t1.SLDPRT", TestName = "Тестирование при корректных значениях параметров")]
       // [TestCase(true, "17", "10", "20", "12", "18", "1", "2", "C:\\test\\t1.SLDPRT", TestName = "Тестирование при корректных значениях параметров222")]
        public void BuildEndHead(bool res,
            string sizeOfWorkingSurface,
            string sizeAttachmentPortion,
            string heightFirstCylinder,
            string heightSecondCylinder,
            string depthOfWorkSurface,
            string wallThicknessFirstCylinder,
            string wallThicknessSecondCylinder,
            string path)
        {
            OpenOrCloseSWModel openOrClose = new OpenOrCloseSWModel();
            openOrClose.OpenSW();
            InputParametrs inputParametrs = new InputParametrs
            {
                SizeOfWorkingSurface = sizeOfWorkingSurface,
                SizeAttachmentPortion= sizeAttachmentPortion,
                HeightFirstCylinder = heightFirstCylinder,
                HeightSecondCylinder = heightSecondCylinder,
                DepthOfWorkSurface = depthOfWorkSurface,
                WallThicknessFirstCylinder= wallThicknessFirstCylinder,
                WallThicknessSecondCylinder= wallThicknessSecondCylinder
            };
            BuildEndHeadFigure buildEndHeadFigure = new BuildEndHeadFigure();
            buildEndHeadFigure.InputParametrsForBuilding(inputParametrs.InspectionInputParametrs());
            Assert.AreEqual(res, buildEndHeadFigure.BuildEndHead(openOrClose.SwApp, path));
        }
        
    }
}
