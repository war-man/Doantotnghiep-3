namespace DOAN_CHuyenNGanh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class focusExamss : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FocusExams", "Grade", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.FocusExams", "Grade");
        }
    }
}
