namespace DOAN_CHuyenNGanh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class focusexamm : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FocusExams", "StudentId", "dbo.Students");
            DropIndex("dbo.FocusExams", new[] { "StudentId" });
            DropPrimaryKey("dbo.FocusExams");
            AddPrimaryKey("dbo.FocusExams", new[] { "Id", "SubjectId", "YearId", "SemesterId" });
            DropColumn("dbo.FocusExams", "StudentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FocusExams", "StudentId", c => c.String(nullable: false, maxLength: 128));
            DropPrimaryKey("dbo.FocusExams");
            AddPrimaryKey("dbo.FocusExams", new[] { "Id", "StudentId", "SubjectId", "YearId", "SemesterId" });
            CreateIndex("dbo.FocusExams", "StudentId");
            AddForeignKey("dbo.FocusExams", "StudentId", "dbo.Students", "Id");
        }
    }
}
