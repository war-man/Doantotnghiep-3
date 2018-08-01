namespace DOAN_CHuyenNGanh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateImageTeacher : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teachers", "urlImage", c => c.String());
            AddColumn("dbo.Students", "urlImage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teachers", "urlImage");
            DropColumn("dbo.Students", "urlImage");
        }
    }
}
