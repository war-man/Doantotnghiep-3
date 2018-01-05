namespace DOAN_CHuyenNGanh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class focusexams : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FocusExams", "Mark", c => c.String());
            AddColumn("dbo.FocusExams", "DateTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.FocusExams", "Location");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FocusExams", "Location", c => c.String());
            DropColumn("dbo.FocusExams", "DateTime");
            DropColumn("dbo.FocusExams", "Mark");
        }
    }
}
