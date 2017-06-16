using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stationnement.Controllers;
using System.Web.Mvc;

namespace TestUnitaire
{
    [TestClass]
    public class TestDivision
    {
        
        [TestMethod]
        public void Diviser6par2()
        {
            MathController math = new MathController();
            ViewResult result = (ViewResult) math.Divide(6, 2);

            Assert.AreEqual(result.Model, 3);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void Diviser6par0()
        {
            MathController math = new MathController();
            ViewResult result = (ViewResult)math.Divide(6, 0);

            Assert.Fail("Exception was expected!");
        }


    }
}
