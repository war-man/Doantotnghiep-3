namespace DOAN_CHuyenNGanh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class students : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "phonenumber", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "phonenumber");
        }
    }
}
