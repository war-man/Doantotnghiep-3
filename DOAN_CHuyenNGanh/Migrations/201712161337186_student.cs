namespace DOAN_CHuyenNGanh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class student : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "Class_Id", "dbo.Classes");
            DropIndex("dbo.Students", new[] { "Class_Id" });
            RenameColumn(table: "dbo.Students", name: "Class_Id", newName: "ClassId");
            AlterColumn("dbo.Students", "ClassId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Students", "ClassId");
            AddForeignKey("dbo.Students", "ClassId", "dbo.Classes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "ClassId", "dbo.Classes");
            DropIndex("dbo.Students", new[] { "ClassId" });
            AlterColumn("dbo.Students", "ClassId", c => c.String(maxLength: 128));
            RenameColumn(table: "dbo.Students", name: "ClassId", newName: "Class_Id");
            CreateIndex("dbo.Students", "Class_Id");
            AddForeignKey("dbo.Students", "Class_Id", "dbo.Classes", "Id");
        }
    }
}
