namespace DOAN_CHuyenNGanh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ScheduleTeacher21 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ScheduleTeachers", "SemesterId", c => c.Int(nullable: false));
            AddColumn("dbo.ScheduleTeachers", "YearId", c => c.Int(nullable: false));
            AddColumn("dbo.ScheduleTeachers", "TeacherId", c => c.Int(nullable: false));
            AddColumn("dbo.ScheduleTeachers", "ClassId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ScheduleTeachers", "ClassId");
            DropColumn("dbo.ScheduleTeachers", "TeacherId");
            DropColumn("dbo.ScheduleTeachers", "YearId");
            DropColumn("dbo.ScheduleTeachers", "SemesterId");
        }
    }
}
