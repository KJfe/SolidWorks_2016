using System;
using NUnit.Framework;
using SolidWorks_2016.Model;
using SolidWorks_2016.Model.MyException;

namespace UnitTests.Model
{
    [TestFixture]
    class InspectionParametrModelTest
    {
        [Test]
        //положительные тесты InspectionParametrModel
        [TestCase("5", "Height", ExpectedResult = 5, TestName = "InspectionParametr.Parametr при (5,Height)")]
        [TestCase("5,5", "Radius", ExpectedResult = 5.5, TestName = "InspectionParametr.Parametr при (5,5 ,Height)")]
        public double InspectonParametrs(string edit, string editDesc)
        {
            return InspectionParametrModel.Parametr(edit, editDesc);
        }
        /// <summary>
        /// Отрицательные тесты InspectionParametrModel
        /// </summary>
        /// <param name="edit"></param>
        /// <param name="editDesc"></param>
        [TestCase("-5fg", "Area", TestName = "InspectionParametr.Parametr при (-5fg, Area)")]
        [TestCase("feflk", "Area", TestName = "InspectionParametr.Parametr при (feflk, Area)")]
        public void InspectonParametrCellFormatException(string edit, string editDesc)
        {
            Assert.Throws<CellFormatException>(() => InspectionParametrModel.Parametr(edit, editDesc));
        }
        /// <summary>
        /// Отрицательные тесты InspectionParametrModel
        /// </summary>
        /// <param name="edit"></param>
        /// <param name="editDesc"></param>
        [TestCase("-5", "Area", TestName = "InspectionParametr.Parametr при -5")]
        //[TestCase("0", "Area", TestName = "InspectionParametr.Parametr при 0")]
        public void InspectonParametrCellOutOfRangeExxeption(string edit, string editDesc)
        {
            Assert.Throws<CellOutOfRangeException>(() => InspectionParametrModel.Parametr(edit, editDesc));
        }
       
    }
}
