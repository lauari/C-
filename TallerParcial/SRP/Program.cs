using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var Valentina = new Person("Laura");
            var Karen = new Person("Karen");
            Valentina.Speak();
            Karen.Speak();

            var database = new Database();
            database.SaveToDatabe(Karen);
            var calcular = new SalarioCalculado();
            Console.WriteLine($"{Karen.Name} tiene un salario de: {calcular.CalcularSalario(Karen)}");
            var Maria = new Gerente("Maria");
            Console.WriteLine($"{Maria.Name} tiene un salario de: {calcular.CalcularSalario(Maria)}");
            var director = new Director("jefe");
            Console.WriteLine($"{director.Name} tiene un salario de: {calcular.CalcularSalario(director)}");
        }
    }
    public  class Person
    {
        public virtual decimal TarifaDiaria => 0;
        public Person(String name)
        {
            Name = name;
        }
        public int Id { get; set; }
        public String Name { get; set; }

        public void Speak()
        {
            Console.WriteLine($"Mi Nombre Es {Name}"); 
        }
    }
    public class Empleada : Person
    {
        public override decimal TarifaDiaria => 100;
        public Empleada(String name) : base(name)
        {
        }

    }
    public class Gerente : Person
    {
        public override decimal TarifaDiaria => 200;
        public Gerente(String name) : base(name)
        {
        }

    }
    public class Director : Person
    {
        public override decimal TarifaDiaria => 300;
        public Director(String name) : base(name)
        {

        }
    }
    public class SalarioCalculado
    {
        public decimal CalcularSalario(Person person)
        {
            return person.TarifaDiaria * 365;
        }    
    }
    public class Database
    {
        public void SaveToDatabe(Person person)
        {
            Console.WriteLine($"Guarde {person.Name}");
        }
    }
    public interface IRepository
    {
        bool Create(Person person);
        Person Get(int id);
        IEnumerable<Person> GetAll();
        bool Update(Person person);
        bool Delete(int id);
    }
    public class Repository : IRepository
    {
        public bool Create(Person person)
        {
            throw new NotImplementedException();
        }
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
        public Person Get(int id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Person>GetAll();
        {
            throw new NotImplementedException();
        }
        public bool Update(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
