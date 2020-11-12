using System;
using System.Collections.Generic;
using System.Text;

namespace PU.Core.Entities
{
    public  class User: BaseEntity
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
    }
}
