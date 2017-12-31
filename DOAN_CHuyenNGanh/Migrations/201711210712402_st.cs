namespace DOAN_CHuyenNGanh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class st : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "birthDay", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "birthDay");
        }
    }
}
