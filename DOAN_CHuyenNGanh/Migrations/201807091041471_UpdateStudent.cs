namespace DOAN_CHuyenNGanh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateStudent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "birth_place", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "ngayvaodoan", c => c.String(nullable: false));
            AddColumn("dbo.Students", "ngayvaodoi", c => c.String(nullable: false));
            AddColumn("dbo.Students", "name_birth_place", c => c.String(nullable: false));
            AddColumn("dbo.Students", "quequan", c => c.String(nullable: false));
            AddColumn("dbo.Students", "description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "description");
            DropColumn("dbo.Students", "quequan");
            DropColumn("dbo.Students", "name_birth_place");
            DropColumn("dbo.Students", "ngayvaodoi");
            DropColumn("dbo.Students", "ngayvaodoan");
            DropColumn("dbo.Students", "birth_place");
        }
    }
}
