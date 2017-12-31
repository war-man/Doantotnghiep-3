namespace DOAN_CHuyenNGanh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class student2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "lastname_Student", c => c.String(nullable: false));
            AddColumn("dbo.Students", "firstname_Student", c => c.String(nullable: false));
            DropColumn("dbo.Students", "name_Student");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "name_Student", c => c.String(nullable: false));
            DropColumn("dbo.Students", "firstname_Student");
            DropColumn("dbo.Students", "lastname_Student");
        }
    }
}
