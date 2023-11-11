namespace SeedingDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialize_Database1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        Emp_Id = c.Int(nullable: false, identity: true),
                        EmpName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Emp_Id);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        Skill_Id = c.Int(nullable: false, identity: true),
                        Skill_Name = c.String(nullable: false),
                        Emp_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Skill_Id)
                .ForeignKey("dbo.Employee", t => t.Emp_Id, cascadeDelete: true)
                .Index(t => t.Emp_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Skills", "Emp_Id", "dbo.Employee");
            DropIndex("dbo.Skills", new[] { "Emp_Id" });
            DropTable("dbo.Skills");
            DropTable("dbo.Employee");
        }
    }
}
