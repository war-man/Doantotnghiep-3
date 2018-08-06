namespace DOAN_CHuyenNGanh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MarkAverage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "mark_average", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "mark_average");
        }
    }
}
