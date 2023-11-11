using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeedingDatabase
{
    [Table("Employee")]
    class ClsEmployee
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Emp_Id
        {
            set;get;
        }
        [Required]
        public string EmpName
        {
            set;get;
        }
        public virtual ICollection<ClsSkill> ClsSkills
        {
            set;get;
        }
    }
}
