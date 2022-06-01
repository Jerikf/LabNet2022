using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp2UniTest
{
    public static class ExtensionDivision
    {
        public static void DividirPorCero(this int num)
        {
            try
            {
                float resultado = num / 0;
                Console.WriteLine("RESULTADO EXITOSO");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
                throw new DivideByZeroException();
                
                
            }
            finally
            {
                Console.WriteLine("SE TERMINÓ DE REALIZAR LA OPERACIÓN");
            }
        }

        public static float DividirEntreDosNumeros(int num1, int num2)
        {
            float resultado;
            try
            {
                resultado = num1 / num2;
                Console.WriteLine($"El resultado de dividir {num1} entre {num2} es : {resultado}");
                return resultado;
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("UPS! SOLO CHUCK NORRIS DIVIDE POR CERO");
                Console.WriteLine(ex.Message);
                throw new DivideByZeroException();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception();
            }
        }

    }
}
