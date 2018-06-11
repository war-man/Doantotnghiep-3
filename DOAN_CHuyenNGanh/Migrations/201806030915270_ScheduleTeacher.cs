namespace DOAN_CHuyenNGanh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ScheduleTeacher : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ScheduleTeachers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Lesson = c.Int(nullable: false),
                        weekdays = c.Int(nullable: false),
                        Semester_Id = c.String(maxLength: 128),
                        Teacher_Id = c.String(maxLength: 128),
                        Year_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Semesters", t => t.Semester_Id)
                .ForeignKey("dbo.Teachers", t => t.Teacher_Id)
                .ForeignKey("dbo.Years", t => t.Year_Id)
                .Index(t => t.Semester_Id)
                .Index(t => t.Teacher_Id)
                .Index(t => t.Year_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ScheduleTeachers", "Year_Id", "dbo.Years");
            DropForeignKey("dbo.ScheduleTeachers", "Teacher_Id", "dbo.Teachers");
            DropForeignKey("dbo.ScheduleTeachers", "Semester_Id", "dbo.Semesters");
            DropIndex("dbo.ScheduleTeachers", new[] { "Year_Id" });
            DropIndex("dbo.ScheduleTeachers", new[] { "Teacher_Id" });
            DropIndex("dbo.ScheduleTeachers", new[] { "Semester_Id" });
            DropTable("dbo.ScheduleTeachers");
        }
    }
}
