namespace DOAN_CHuyenNGanh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teacherhomeroom : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Teachers", name: "ClassId", newName: "Class_Id");
            RenameIndex(table: "dbo.Teachers", name: "IX_ClassId", newName: "IX_Class_Id");
            CreateTable(
                "dbo.HomeRoomTeachers",
                c => new
                    {
                        TeacherId = c.String(nullable: false, maxLength: 128),
                        ClassId = c.String(nullable: false, maxLength: 128),
                        YearId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.TeacherId, t.ClassId, t.YearId })
                .ForeignKey("dbo.Classes", t => t.ClassId)
                .ForeignKey("dbo.Teachers", t => t.TeacherId)
                .ForeignKey("dbo.Years", t => t.YearId)
                .Index(t => t.TeacherId)
                .Index(t => t.ClassId)
                .Index(t => t.YearId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HomeRoomTeachers", "YearId", "dbo.Years");
            DropForeignKey("dbo.HomeRoomTeachers", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.HomeRoomTeachers", "ClassId", "dbo.Classes");
            DropIndex("dbo.HomeRoomTeachers", new[] { "YearId" });
            DropIndex("dbo.HomeRoomTeachers", new[] { "ClassId" });
            DropIndex("dbo.HomeRoomTeachers", new[] { "TeacherId" });
            DropTable("dbo.HomeRoomTeachers");
            RenameIndex(table: "dbo.Teachers", name: "IX_Class_Id", newName: "IX_ClassId");
            RenameColumn(table: "dbo.Teachers", name: "Class_Id", newName: "ClassId");
        }
    }
}
