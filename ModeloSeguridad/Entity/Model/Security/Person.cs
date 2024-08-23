﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Security
{
    public class Person
    {
        // Atributos
        public int Id { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string Email { get; set; }
        public string Addres { get; set; }
        public string Type_document { get; set; }
        public int Document { get; set; }
        public DateTime Birth_of_date { get; set; }
        public string CreateAt { get; set; }
        public string UpdateAt { get; set; }
        public DateTime DeleteAt { get; set; }
        public int Phone { get; set; }
        public bool State { get; set; }

        
    }
}

