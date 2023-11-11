namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialize_Database : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Cat_Id = c.Int(nullable: false, identity: true),
                        Cat_Type = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Cat_Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Prod_Id = c.Int(nullable: false, identity: true),
                        Prod_Name = c.String(nullable: false),
                        Prod_Type = c.String(nullable: false),
                        Sup_Id = c.Int(nullable: false),
                        Cat_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Prod_Id)
                .ForeignKey("dbo.Categories", t => t.Cat_Id, cascadeDelete: true)
                .ForeignKey("dbo.Suppliers", t => t.Sup_Id, cascadeDelete: true)
                .Index(t => t.Sup_Id)
                .Index(t => t.Cat_Id);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        Sup_id = c.Int(nullable: false, identity: true),
                        Sup_name = c.String(nullable: false, maxLength: 30),
                        Sup_phno = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Sup_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Sup_Id", "dbo.Suppliers");
            DropForeignKey("dbo.Products", "Cat_Id", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "Cat_Id" });
            DropIndex("dbo.Products", new[] { "Sup_Id" });
            DropTable("dbo.Suppliers");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
