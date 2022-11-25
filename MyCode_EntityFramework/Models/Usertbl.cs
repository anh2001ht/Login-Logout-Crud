using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyCode_EntityFramework.Models
{
 
    public partial class Usertbl
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
        public DateTime? BirthDay { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public int? Age { get; set; }
        public bool? Gender { get; set; }
        //public GenderEnum Gender { get; set; }
    }
   
}
