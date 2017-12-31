namespace DOAN_CHuyenNGanh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Contact : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Contacts", name: "Semester_Id1", newName: "SemesterId");
            RenameIndex(table: "dbo.Contacts", name: "IX_Semester_Id1", newName: "IX_SemesterId");
            DropPrimaryKey("dbo.Contacts");
            CreateTable(
                "dbo.Years",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Contacts", "YearId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Contacts", new[] { "CLassId", "StudentId", "SubjectId", "YearId", "SemesterId" });
            CreateIndex("dbo.Contacts", "YearId");
            AddForeignKey("dbo.Contacts", "YearId", "dbo.Years", "Id");
            DropColumn("dbo.Contacts", "Semester_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "Semester_Id", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.Contacts", "YearId", "dbo.Years");
            DropIndex("dbo.Contacts", new[] { "YearId" });
            DropPrimaryKey("dbo.Contacts");
            DropColumn("dbo.Contacts", "YearId");
            DropTable("dbo.Years");
            AddPrimaryKey("dbo.Contacts", new[] { "CLassId", "StudentId", "SubjectId", "Semester_Id" });
            RenameIndex(table: "dbo.Contacts", name: "IX_SemesterId", newName: "IX_Semester_Id1");
            RenameColumn(table: "dbo.Contacts", name: "SemesterId", newName: "Semester_Id1");
        }
    }
}
