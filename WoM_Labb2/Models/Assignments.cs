using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WoM_Labb2.Models
{
    public class Assignments
    {
        
        public int TaskID { get; set; }
        public virtual Tasks Task { get; set; }
        public int UserID { get; set; }
        public virtual Users User { get; set; }
    }
}
