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
    [Table("Skills")]
    class ClsSkill
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Skill_Id
        {
            set;get;
        }
        [Required]
        public string Skill_Name
        {
            set;get;
        }
        [ForeignKey("ClsEmployee")]
        public int Emp_Id
        {
            set;get;
        }
        public virtual ClsEmployee ClsEmployee
        {
            set;get;
        }
    }
}
