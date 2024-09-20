using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Entity.Dto
{
    public class CityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Estado { get; set; }

        public int StateId { get; set; }
        public string State { get; set; }
    }
}
