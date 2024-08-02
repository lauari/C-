using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Security
{
    internal class Role
    {
        private int idRole { get; set; }
        private String Name { get; set; }
        private string Description { get; set; }
        private string CreateAt { get; set; }
        private string UpdateAt { get; set; }
        private string DeleteAt { get; set; }
        private string State { get; set; }


        // Constructor con parámetros
        public Role(int idRole, String Name, string Description, string CreateAt, string UpdateAt, string DeleteAt,string State)
        {
            this.idRole = idRole;
            this.Name = Name;
            this.Description = Description;
            this.CreateAt = CreateAt;
            this.UpdateAt = UpdateAt;
            this.DeleteAt = DeleteAt;
            this.State = State;
        }
    }
}
