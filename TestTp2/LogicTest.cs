using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tp2UniTest;

namespace TestTp2
{
    [TestClass]
    public class LogicTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestExcepcionArgumentOutOfRange()
        {
            Logic logic = new Logic();
            logic.ExcepcionArgumentOutOfRange();
        }
        [TestMethod]
        [ExpectedException(typeof(MiExepcion))]
        public void TestMiExepcion()
        {
            Logic logic = new Logic();
            logic.ExcepcionPersonalizada() ;
        }
    }
}
