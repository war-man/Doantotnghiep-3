namespace DOAN_CHuyenNGanh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ScheduleTeacher3 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.ScheduleTeachers", new[] { "Class_Id" });
            DropIndex("dbo.ScheduleTeachers", new[] { "Semester_Id" });
            DropIndex("dbo.ScheduleTeachers", new[] { "Teacher_Id" });
            DropIndex("dbo.ScheduleTeachers", new[] { "Year_Id" });
            DropColumn("dbo.ScheduleTeachers", "ClassId");
            DropColumn("dbo.ScheduleTeachers", "SemesterId");
            DropColumn("dbo.ScheduleTeachers", "TeacherId");
            DropColumn("dbo.ScheduleTeachers", "YearId");
            RenameColumn(table: "dbo.ScheduleTeachers", name: "Class_Id", newName: "ClassId");
            RenameColumn(table: "dbo.ScheduleTeachers", name: "Semester_Id", newName: "SemesterId");
            RenameColumn(table: "dbo.ScheduleTeachers", name: "Teacher_Id", newName: "TeacherId");
            RenameColumn(table: "dbo.ScheduleTeachers", name: "Year_Id", newName: "YearId");
            AlterColumn("dbo.ScheduleTeachers", "SemesterId", c => c.String(maxLength: 128));
            AlterColumn("dbo.ScheduleTeachers", "YearId", c => c.String(maxLength: 128));
            AlterColumn("dbo.ScheduleTeachers", "TeacherId", c => c.String(maxLength: 128));
            AlterColumn("dbo.ScheduleTeachers", "ClassId", c => c.String(maxLength: 128));
            CreateIndex("dbo.ScheduleTeachers", "SemesterId");
            CreateIndex("dbo.ScheduleTeachers", "YearId");
            CreateIndex("dbo.ScheduleTeachers", "TeacherId");
            CreateIndex("dbo.ScheduleTeachers", "ClassId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.ScheduleTeachers", new[] { "ClassId" });
            DropIndex("dbo.ScheduleTeachers", new[] { "TeacherId" });
            DropIndex("dbo.ScheduleTeachers", new[] { "YearId" });
            DropIndex("dbo.ScheduleTeachers", new[] { "SemesterId" });
            AlterColumn("dbo.ScheduleTeachers", "ClassId", c => c.Int(nullable: false));
            AlterColumn("dbo.ScheduleTeachers", "TeacherId", c => c.Int(nullable: false));
            AlterColumn("dbo.ScheduleTeachers", "YearId", c => c.Int(nullable: false));
            AlterColumn("dbo.ScheduleTeachers", "SemesterId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.ScheduleTeachers", name: "YearId", newName: "Year_Id");
            RenameColumn(table: "dbo.ScheduleTeachers", name: "TeacherId", newName: "Teacher_Id");
            RenameColumn(table: "dbo.ScheduleTeachers", name: "SemesterId", newName: "Semester_Id");
            RenameColumn(table: "dbo.ScheduleTeachers", name: "ClassId", newName: "Class_Id");
            AddColumn("dbo.ScheduleTeachers", "YearId", c => c.Int(nullable: false));
            AddColumn("dbo.ScheduleTeachers", "TeacherId", c => c.Int(nullable: false));
            AddColumn("dbo.ScheduleTeachers", "SemesterId", c => c.Int(nullable: false));
            AddColumn("dbo.ScheduleTeachers", "ClassId", c => c.Int(nullable: false));
            CreateIndex("dbo.ScheduleTeachers", "Year_Id");
            CreateIndex("dbo.ScheduleTeachers", "Teacher_Id");
            CreateIndex("dbo.ScheduleTeachers", "Semester_Id");
            CreateIndex("dbo.ScheduleTeachers", "Class_Id");
        }
    }
}
