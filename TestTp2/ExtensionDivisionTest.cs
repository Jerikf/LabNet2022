using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tp2UniTest;

namespace TestTp2
{
    [TestClass]
    public class ExtensionDivisionTest
    {
        //POS: CAPTURA EL LA EXCEPCION DE DIVISION POR 0
        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void TestDividirPorCero()
        {
            int num = 27;
            num.DividirPorCero();
        }
        

        //POS : VALIDA LA DIVISIÓN CORRECTA ENTRE DOS NÚMEROS
        [TestMethod]
        public void TestDividirEntreDosNumerosValido()
        {
            int num1 = 27;
            int num2 = 9;
            float resultadoEsperado = 3;
            Assert.AreEqual(ExtensionDivision.DividirEntreDosNumeros(num1, num2), resultadoEsperado);
        }

        //POS : VALIDA LA EXCEPCIÓN QUE LANZA SI EL 2DO NÚMERO PARA DIVIDIR ES 0.(CAPTURA EL ERROR DivideByZeroException)
        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void TestDividirEntreDosNumerosCapturaExcepcion()
        {
            int num1 = 27;
            int num2 = 0;
            ExtensionDivision.DividirEntreDosNumeros(num1, num2);
        }

    }
}
