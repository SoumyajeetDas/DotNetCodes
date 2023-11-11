using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SeedingDatabase
{
    class EmpSkillEntity : DbContext
    {
        public EmpSkillEntity(): base ("name = SeedCodeConn")
        {

        }
        public DbSet<ClsEmployee> ClsEmployees { set; get; }
        public DbSet<ClsSkill> ClsSkills { set; get; }

    }


    
}
