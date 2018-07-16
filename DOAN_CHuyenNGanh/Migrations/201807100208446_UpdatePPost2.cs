namespace DOAN_CHuyenNGanh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePPost2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "DateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "DateTime");
        }
    }
}
