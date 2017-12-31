namespace DOAN_CHuyenNGanh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class st1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Parents", "birthDay", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "birthDay", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "birthDay", c => c.DateTime(nullable: false));
            DropColumn("dbo.Parents", "birthDay");
        }
    }
}
