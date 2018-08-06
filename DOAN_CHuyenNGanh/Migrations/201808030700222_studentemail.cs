namespace DOAN_CHuyenNGanh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class studentemail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "email", c => c.String(nullable: false));
            AddColumn("dbo.Parents", "email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Parents", "email");
            DropColumn("dbo.Students", "email");
        }
    }
}
