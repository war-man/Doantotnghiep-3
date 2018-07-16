namespace DOAN_CHuyenNGanh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePPost : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Posts", new[] { "Category_Id" });
            AddColumn("dbo.Posts", "Category_Id1", c => c.Int(nullable: false));
            AlterColumn("dbo.Posts", "Category_Id", c => c.String());
            CreateIndex("dbo.Posts", "Category_Id1");
            AddForeignKey("dbo.Posts", "Category_Id1", "dbo.Categories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "Category_Id1", "dbo.Categories");
            DropIndex("dbo.Posts", new[] { "Category_Id1" });
            AlterColumn("dbo.Posts", "Category_Id", c => c.Int());
            DropColumn("dbo.Posts", "Category_Id1");
            CreateIndex("dbo.Posts", "Category_Id");
            AddForeignKey("dbo.Posts", "Category_Id", "dbo.Categories", "Id");
        }
    }
}
