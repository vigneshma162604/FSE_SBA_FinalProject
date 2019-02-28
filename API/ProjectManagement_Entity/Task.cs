using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement_Entity
{
    //[Table("tblTask")]
    public class Task
    {
        [Key]
        public int TaskID { get; set; }
        public int? ParentTaskId { get; set; }
        public int? ProjectId { get; set; }
        public string TaskDesc { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Priority { get; set; }
        public bool Status { get; set; }
    }
}
