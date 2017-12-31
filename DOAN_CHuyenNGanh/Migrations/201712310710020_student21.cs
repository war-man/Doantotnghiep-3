namespace DOAN_CHuyenNGanh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class student21 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "ClassId", "dbo.Classes");
            DropIndex("dbo.Students", new[] { "ClassId" });
            CreateTable(
                "dbo.ClassStudents",
                c => new
                    {
                        StudentId = c.String(nullable: false, maxLength: 128),
                        ClassId = c.String(nullable: false, maxLength: 128),
                        YearId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.StudentId, t.ClassId, t.YearId })
                .ForeignKey("dbo.Classes", t => t.ClassId)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .ForeignKey("dbo.Years", t => t.YearId)
                .Index(t => t.StudentId)
                .Index(t => t.ClassId)
                .Index(t => t.YearId);
            
            DropColumn("dbo.Students", "ClassId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "ClassId", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.ClassStudents", "YearId", "dbo.Years");
            DropForeignKey("dbo.ClassStudents", "StudentId", "dbo.Students");
            DropForeignKey("dbo.ClassStudents", "ClassId", "dbo.Classes");
            DropIndex("dbo.ClassStudents", new[] { "YearId" });
            DropIndex("dbo.ClassStudents", new[] { "ClassId" });
            DropIndex("dbo.ClassStudents", new[] { "StudentId" });
            DropTable("dbo.ClassStudents");
            CreateIndex("dbo.Students", "ClassId");
            AddForeignKey("dbo.Students", "ClassId", "dbo.Classes", "Id", cascadeDelete: true);
        }
    }
}
