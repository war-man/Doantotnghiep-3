namespace DOAN_CHuyenNGanh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sercolumn : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.SetColumnContacts");
            AddPrimaryKey("dbo.SetColumnContacts", new[] { "YearId", "TeacherId" });
            DropColumn("dbo.SetColumnContacts", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SetColumnContacts", "Id", c => c.String(nullable: false, maxLength: 128));
            DropPrimaryKey("dbo.SetColumnContacts");
            AddPrimaryKey("dbo.SetColumnContacts", new[] { "Id", "YearId", "TeacherId" });
        }
    }
}
