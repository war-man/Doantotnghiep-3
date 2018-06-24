namespace DOAN_CHuyenNGanh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ScheduleTeacher4 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.ScheduleTeachers");
            AlterColumn("dbo.ScheduleTeachers", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.ScheduleTeachers", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.ScheduleTeachers");
            AlterColumn("dbo.ScheduleTeachers", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.ScheduleTeachers", "Id");
        }
    }
}
