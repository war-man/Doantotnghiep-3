namespace DOAN_CHuyenNGanh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class focusExam : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FocusExams",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        StudentId = c.String(nullable: false, maxLength: 128),
                        SubjectId = c.String(nullable: false, maxLength: 128),
                        YearId = c.String(nullable: false, maxLength: 128),
                        SemesterId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => new { t.Id, t.StudentId, t.SubjectId, t.YearId, t.SemesterId })
                .ForeignKey("dbo.Semesters", t => t.SemesterId)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .ForeignKey("dbo.Subjects", t => t.SubjectId)
                .ForeignKey("dbo.Years", t => t.YearId)
                .Index(t => t.StudentId)
                .Index(t => t.SubjectId)
                .Index(t => t.YearId)
                .Index(t => t.SemesterId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FocusExams", "YearId", "dbo.Years");
            DropForeignKey("dbo.FocusExams", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.FocusExams", "StudentId", "dbo.Students");
            DropForeignKey("dbo.FocusExams", "SemesterId", "dbo.Semesters");
            DropIndex("dbo.FocusExams", new[] { "SemesterId" });
            DropIndex("dbo.FocusExams", new[] { "YearId" });
            DropIndex("dbo.FocusExams", new[] { "SubjectId" });
            DropIndex("dbo.FocusExams", new[] { "StudentId" });
            DropTable("dbo.FocusExams");
        }
    }
}
