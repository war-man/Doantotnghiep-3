namespace DOAN_CHuyenNGanh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class setcolumncontact : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SetColumnContacts",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        YearId = c.String(nullable: false, maxLength: 128),
                        TeacherId = c.String(nullable: false, maxLength: 128),
                        mark_5m = c.Int(nullable: false),
                        mark_15m = c.Int(nullable: false),
                        mark_45m = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Id, t.YearId, t.TeacherId })
                .ForeignKey("dbo.Teachers", t => t.TeacherId)
                .ForeignKey("dbo.Years", t => t.YearId)
                .Index(t => t.YearId)
                .Index(t => t.TeacherId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SetColumnContacts", "YearId", "dbo.Years");
            DropForeignKey("dbo.SetColumnContacts", "TeacherId", "dbo.Teachers");
            DropIndex("dbo.SetColumnContacts", new[] { "TeacherId" });
            DropIndex("dbo.SetColumnContacts", new[] { "YearId" });
            DropTable("dbo.SetColumnContacts");
        }
    }
}
