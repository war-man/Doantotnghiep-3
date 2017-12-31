namespace DOAN_CHuyenNGanh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class amrk : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contacts", "mark_5m1", c => c.String());
            AlterColumn("dbo.Contacts", "mark_5m2", c => c.String());
            AlterColumn("dbo.Contacts", "mark_5m3", c => c.String());
            AlterColumn("dbo.Contacts", "mark_5m4", c => c.String());
            AlterColumn("dbo.Contacts", "mark_5m5", c => c.String());
            AlterColumn("dbo.Contacts", "mark_15m1", c => c.String());
            AlterColumn("dbo.Contacts", "mark_15m2", c => c.String());
            AlterColumn("dbo.Contacts", "mark_15m3", c => c.String());
            AlterColumn("dbo.Contacts", "mark_15m4", c => c.String());
            AlterColumn("dbo.Contacts", "mark_15m5", c => c.String());
            AlterColumn("dbo.Contacts", "mark_45m1", c => c.String());
            AlterColumn("dbo.Contacts", "mark_45m2", c => c.String());
            AlterColumn("dbo.Contacts", "mark_45m3", c => c.String());
            AlterColumn("dbo.Contacts", "mark_45m4", c => c.String());
            AlterColumn("dbo.Contacts", "mark_subjects", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contacts", "mark_subjects", c => c.Single(nullable: false));
            AlterColumn("dbo.Contacts", "mark_45m4", c => c.Single(nullable: false));
            AlterColumn("dbo.Contacts", "mark_45m3", c => c.Single(nullable: false));
            AlterColumn("dbo.Contacts", "mark_45m2", c => c.Single(nullable: false));
            AlterColumn("dbo.Contacts", "mark_45m1", c => c.Single(nullable: false));
            AlterColumn("dbo.Contacts", "mark_15m5", c => c.Single(nullable: false));
            AlterColumn("dbo.Contacts", "mark_15m4", c => c.Single(nullable: false));
            AlterColumn("dbo.Contacts", "mark_15m3", c => c.Single(nullable: false));
            AlterColumn("dbo.Contacts", "mark_15m2", c => c.Single(nullable: false));
            AlterColumn("dbo.Contacts", "mark_15m1", c => c.Single(nullable: false));
            AlterColumn("dbo.Contacts", "mark_5m5", c => c.Single(nullable: false));
            AlterColumn("dbo.Contacts", "mark_5m4", c => c.Single(nullable: false));
            AlterColumn("dbo.Contacts", "mark_5m3", c => c.Single(nullable: false));
            AlterColumn("dbo.Contacts", "mark_5m2", c => c.Single(nullable: false));
            AlterColumn("dbo.Contacts", "mark_5m1", c => c.Single(nullable: false));
        }
    }
}
