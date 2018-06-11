namespace DOAN_CHuyenNGanh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ScheduleTeacher2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ScheduleTeachers", "Class_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.ScheduleTeachers", "Class_Id");
            AddForeignKey("dbo.ScheduleTeachers", "Class_Id", "dbo.Classes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ScheduleTeachers", "Class_Id", "dbo.Classes");
            DropIndex("dbo.ScheduleTeachers", new[] { "Class_Id" });
            DropColumn("dbo.ScheduleTeachers", "Class_Id");
        }
    }
}
