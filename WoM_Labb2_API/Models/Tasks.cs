using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace WoM_Labb2.Models
{
    public class Tasks
    {
        [Key]
        public int TaskID { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime BeginDateTime { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DeadlineDateTime { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Requirements { get; set; }
        public IList<Assignments> Assignments { get; set; }

    }
}
