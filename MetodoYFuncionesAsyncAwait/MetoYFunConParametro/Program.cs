using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetoYFunConParametro
{
    internal class Program
    {

        // Función para calcular el área de un rectángulo, que recibe dos parámetros: base y altura
        public static double CalcularAreaRectangulo(double baseRectangulo, double alturaRectangulo)
        {
            return baseRectangulo * alturaRectangulo;
        }
        public static void Main()
        {
            Console.WriteLine("Calculadora de área de un rectángulo");

            // Solicitamos al usuario los valores de base y altura
            Console.Write("Ingrese la base del rectángulo: ");
            double baseRectangulo = Convert.ToDouble(Console.ReadLine());

            Console.Write("Ingrese la altura del rectángulo: ");
            double alturaRectangulo = Convert.ToDouble(Console.ReadLine());

            // Llamamos a la función CalcularAreaRectangulo con los parámetros baseRectangulo y alturaRectangulo
            double area = CalcularAreaRectangulo(baseRectangulo, alturaRectangulo);

            // Mostramos el resultado
            Console.WriteLine($"El área del rectángulo es: {area}");
        }
    }
}
