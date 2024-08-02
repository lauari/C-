using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Security
{
    internal class Person
    {
        // Atributos
        private int idPerson { get; set; }
        private string First_name { get; set; }
        private string Last_name { get; set; }
        private string Email { get; set; }
        private string Addres { get; set; }
        private string Type_document { get; set; }
        private int Document { get; set; }
        private DateTime Birth_of_date { get; set; }
        private string CreateAt { get; set; }
        private string UpdateAt { get; set; }
        private string DeleteAt { get; set; }
        private int Phone { get; set; }
        private string State { get; set; }

        // Constructor con parámetros
        public Person(int idPerson, string First_name, string Last_name, string Email, string Addres, 
            string Type_document, DateTime Birth_of_date, string CreateAt, string UpdateAt, string DeleteAt, 
            int Phone, string State)
        {
            this.idPerson = idPerson;
            this.First_name = First_name;
            this.Last_name = Last_name;
            this.Email = Email;
            this.Addres = Addres;
            this.Type_document = Type_document;
            this.Birth_of_date = Birth_of_date;
            this.CreateAt = CreateAt;
            this.UpdateAt = UpdateAt;
            this.DeleteAt = DeleteAt;
            this.Phone = Phone;
            this.State = State;
        }

        //public override string ToString()
        //{
        //    return $"Nombre Producto: {nombreProducto}, Descripción: {descripcion}, Categoria: {categoria}";
        //}
    }
}

