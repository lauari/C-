using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Security
{
    public class User
    {
        // Atributos
        public int Id { get; set; }
        public string Username { get; set; }
        public int Password { get; set; }
        public string CreateAt { get; set; }
        public string UpdateAt { get; set; }
        public DateTime DeleteAt { get; set; }
        public bool State { get; set; }

        private int PersonId { get; set; }
        private Person Person { get; set; }
    }
}
