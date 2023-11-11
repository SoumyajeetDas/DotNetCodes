namespace Login_Logout_and_SignUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialize_Database : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Designation = c.String(nullable: false),
                        Salary = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserRole_Id = c.Int(nullable: false, identity: true),
                        Role = c.String(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserRole_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Role = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserRoleUsers",
                c => new
                    {
                        UserRole_UserRole_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserRole_UserRole_Id, t.User_Id })
                .ForeignKey("dbo.UserRoles", t => t.UserRole_UserRole_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.UserRole_UserRole_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRoleUsers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserRoleUsers", "UserRole_UserRole_Id", "dbo.UserRoles");
            DropIndex("dbo.UserRoleUsers", new[] { "User_Id" });
            DropIndex("dbo.UserRoleUsers", new[] { "UserRole_UserRole_Id" });
            DropTable("dbo.UserRoleUsers");
            DropTable("dbo.Users");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Employees");
        }
    }
}
