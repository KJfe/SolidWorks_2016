using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using UnitTests.Model;

namespace UnitTests
{
    [TestFixture]
    class StressTesting
    {
        [Test]
        [TestCase(1, "C:\\test\\t1", ".SLDPRT", TestName = "Тестирование при построении 1 документа-модели")]
        [TestCase(2, "C:\\test\\t2", ".SLDPRT", TestName = "Тестирование при построении 2 документа-модели")]
        [TestCase(3, "C:\\test\\t3", ".SLDPRT", TestName = "Тестирование при построении 3 документа-модели")]
        [TestCase(4, "C:\\test\\t4", ".SLDPRT", TestName = "Тестирование при построении 4 документа-модели")]
        [TestCase(5, "C:\\test\\t5", ".SLDPRT", TestName = "Тестирование при построении 5 документа-модели")]
        [TestCase(6, "C:\\test\\t6", ".SLDPRT", TestName = "Тестирование при построении 6 документа-модели")]
        [TestCase(7, "C:\\test\\t7", ".SLDPRT", TestName = "Тестирование при построении 7 документа-модели")]
        [TestCase(8, "C:\\test\\t8", ".SLDPRT", TestName = "Тестирование при построении 8 документа-модели")]
        [TestCase(9, "C:\\test\\t9", ".SLDPRT", TestName = "Тестирование при построении 9 документа-модели")]
        //[TestCase(10,"C:\\test\\t10", ".SLDPRT", TestName = "Тестирование при построении 10 документа-модели")]
        public void Testing(int count, string path, string sldprt)
        {
            BuildEndHeadTest build = new BuildEndHeadTest();
            for (int i=1; i<=count; i++)
            {
                build.BuildEndHead(true, "17", "10", "20", "12", "18", "1", "2",path+i.ToString()+ sldprt);
            }
        }
    }
}
