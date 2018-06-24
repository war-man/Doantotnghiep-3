namespace DOAN_CHuyenNGanh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class homeroomteacheredit : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.HomeRoomTeachers", new[] { "TeacherId" });
            DropPrimaryKey("dbo.HomeRoomTeachers");
            AlterColumn("dbo.HomeRoomTeachers", "TeacherId", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.HomeRoomTeachers", new[] { "ClassId", "YearId" });
            CreateIndex("dbo.HomeRoomTeachers", "TeacherId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.HomeRoomTeachers", new[] { "TeacherId" });
            DropPrimaryKey("dbo.HomeRoomTeachers");
            AlterColumn("dbo.HomeRoomTeachers", "TeacherId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.HomeRoomTeachers", new[] { "TeacherId", "ClassId", "YearId" });
            CreateIndex("dbo.HomeRoomTeachers", "TeacherId");
        }
    }
}
