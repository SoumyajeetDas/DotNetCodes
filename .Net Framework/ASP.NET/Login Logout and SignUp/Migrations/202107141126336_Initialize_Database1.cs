namespace Login_Logout_and_SignUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialize_Database1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserRoleUsers", "UserRole_UserRole_Id", "dbo.UserRoles");
            DropForeignKey("dbo.UserRoleUsers", "User_Id", "dbo.Users");
            DropIndex("dbo.UserRoleUsers", new[] { "UserRole_UserRole_Id" });
            DropIndex("dbo.UserRoleUsers", new[] { "User_Id" });
            CreateIndex("dbo.UserRoles", "User_Id");
            AddForeignKey("dbo.UserRoles", "User_Id", "dbo.Users", "Id", cascadeDelete: true);
            DropTable("dbo.UserRoleUsers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserRoleUsers",
                c => new
                    {
                        UserRole_UserRole_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserRole_UserRole_Id, t.User_Id });
            
            DropForeignKey("dbo.UserRoles", "User_Id", "dbo.Users");
            DropIndex("dbo.UserRoles", new[] { "User_Id" });
            CreateIndex("dbo.UserRoleUsers", "User_Id");
            CreateIndex("dbo.UserRoleUsers", "UserRole_UserRole_Id");
            AddForeignKey("dbo.UserRoleUsers", "User_Id", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserRoleUsers", "UserRole_UserRole_Id", "dbo.UserRoles", "UserRole_Id", cascadeDelete: true);
        }
    }
}
