using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace WoM_Labb2.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
