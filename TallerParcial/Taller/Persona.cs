using System;
using System.Threading.Tasks;

namespace Taller
{
    internal class Persona
    {
        protected const decimal SalarioMinimo = 1300000.00m; // Salario mínimo

        // Atributos de instancia de la clase Persona
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Direccion { get; set; }
        public int DiasTrabajados { get; set; }

        // Constructor para inicializar los atributos
        public Persona(string nombre, int edad, string direccion, int diasTrabajados)
        {
            Nombre = nombre;
            Edad = edad;
            Direccion = direccion;
            DiasTrabajados = diasTrabajados;
        }

        // Método para mostrar información de la persona en la consola
        public void MostrarInformacion()
        {
            Console.WriteLine($"Nombre: {Nombre}");
            Console.WriteLine($"Edad: {Edad}");
            Console.WriteLine($"Dirección: {Direccion}");
            Console.WriteLine($"Días trabajados: {DiasTrabajados}");
        }
    }

    internal class Empleado : Persona, ICalculable
    {
        // Constructor para inicializar los atributos de Empleado
        public Empleado(string nombre, int edad, string direccion, int diasTrabajados)
            : base(nombre, edad, direccion, diasTrabajados) { }

        // Método asincrónico para mostrar la información del empleado
        public async Task MostrarInformacionAsync()
        {
            // Simula una operación de espera
            await Task.Delay(1000);
            Console.WriteLine($"Nombre: {Nombre}");
            Console.WriteLine($"Edad: {Edad}");
            Console.WriteLine($"Dirección: {Direccion}");
            Console.WriteLine($"Días trabajados: {DiasTrabajados}");

        }

        // Implementación del método CalcularSalario de la interfaz ICalculable
        public decimal CalcularSalario()
        {
            // Calcular el salario diario
            decimal salarioDiario = SalarioMinimo / 30;
            // Calcular el salario basado en los días trabajados
            return salarioDiario * DiasTrabajados;
        }

        // Método para mostrar información del empleado, incluyendo el salario
        public new void MostrarInformacion()
        {
            base.MostrarInformacion();

        }
    }

    internal class Program
    {
        public static async Task Main(string[] args)
        {
            // Pedir datos al usuario
            Console.WriteLine("Ingrese el nombre del empleado:");
            string nombre = Console.ReadLine();

            Console.WriteLine("Ingrese la edad del empleado:");
            int edad = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese la dirección del empleado:");
            string direccion = Console.ReadLine();

            Console.WriteLine("Ingrese los días trabajados por el empleado:");
            int diasTrabajados = int.Parse(Console.ReadLine());

            // Crear un objeto Empleado con los datos ingresados por el usuario
            Empleado empleado = new Empleado(nombre, edad, direccion, diasTrabajados);

            // Mostrar la información del empleado asincrónicamente
            await empleado.MostrarInformacionAsync();

            // Calcular el salario usando la interfaz ICalculable
            ICalculable empleadoCalculable = empleado;
            Console.WriteLine($"Salario calculado: {empleadoCalculable.CalcularSalario():C}"); // Muestra el salario calculado
        }
    }
}

