using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Security
{
    internal class UserRole
    {
        // Atributos
        private int idUserRole { get; set; }
        private string CreateAt { get; set; }
        private string UpdateAt { get; set; }
        private string DeleteAt { get; set; }
        private string State { get; set; }

        // Constructor con parámetros
        public UserRole(int idUserRole, string CreateAt, string UpdateAt, string DeleteAt, String State)
        {
            this.idUserRole = idUserRole;
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

