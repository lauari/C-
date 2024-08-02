using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Security
{
    internal class User
    {
        // Atributos
        private int idUser { get; set; }
        private string Username { get; set; }
        private int Password { get; set; }
        private string CreateAt { get; set; }
        private string UpdateAt { get; set; }
        private string DeleteAt { get; set; }
        private string State { get; set; }

        // Constructor con parámetros
        public User(int idUser, string Username, int Password,string CreateAt, string UpdateAt, string DeleteAt,String State)
        {
            this.idUser = idUser;
            this.Username = Username;
            this.Password = Password;
            this.CreateAt = CreateAt;
            this.UpdateAt = UpdateAt;
            this.DeleteAt = DeleteAt;
            this.State = State;
        }

        //public override string ToString()
        //{
        //    return $"Nombre Producto: {nombreProducto}, Descripción: {descripcion}, Categoria: {categoria}";
        //}
    }
}
