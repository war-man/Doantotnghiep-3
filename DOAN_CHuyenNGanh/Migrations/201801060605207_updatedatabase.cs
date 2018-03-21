namespace DOAN_CHuyenNGanh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actions",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        name_Class = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ClassStudents",
                c => new
                    {
                        StudentId = c.String(nullable: false, maxLength: 128),
                        ClassId = c.String(nullable: false, maxLength: 128),
                        YearId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.StudentId, t.ClassId, t.YearId })
                .ForeignKey("dbo.Classes", t => t.ClassId)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .ForeignKey("dbo.Years", t => t.YearId)
                .Index(t => t.StudentId)
                .Index(t => t.ClassId)
                .Index(t => t.YearId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        lastname_Student = c.String(nullable: false),
                        firstname_Student = c.String(nullable: false),
                        birthDay = c.String(nullable: false),
                        sex = c.Boolean(nullable: false),
                        address = c.String(nullable: false),
                        phonenumber = c.String(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        Parent_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Parents", t => t.Parent_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Parent_Id);
            
            CreateTable(
                "dbo.Parents",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        name_Parent = c.String(nullable: false),
                        birthDay = c.String(nullable: false),
                        phonenumber = c.String(nullable: false),
                        job = c.String(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Years",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ClassTeachers",
                c => new
                    {
                        ClassId = c.String(nullable: false, maxLength: 128),
                        SubjectId = c.String(nullable: false, maxLength: 128),
                        TeacherId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.ClassId, t.SubjectId })
                .ForeignKey("dbo.Classes", t => t.ClassId, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.SubjectId)
                .ForeignKey("dbo.Teachers", t => t.TeacherId)
                .Index(t => t.ClassId)
                .Index(t => t.SubjectId)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        name_Subject = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        name_Teacher = c.String(nullable: false),
                        sex = c.Boolean(nullable: false),
                        address = c.String(nullable: false),
                        SubjectId = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Subjects", t => t.SubjectId)
                .Index(t => t.SubjectId)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        CLassId = c.String(nullable: false, maxLength: 128),
                        StudentId = c.String(nullable: false, maxLength: 128),
                        SubjectId = c.String(nullable: false, maxLength: 128),
                        YearId = c.String(nullable: false, maxLength: 128),
                        SemesterId = c.String(nullable: false, maxLength: 128),
                        mark_5m1 = c.String(),
                        mark_5m2 = c.String(),
                        mark_5m3 = c.String(),
                        mark_5m4 = c.String(),
                        mark_5m5 = c.String(),
                        mark_15m1 = c.String(),
                        mark_15m2 = c.String(),
                        mark_15m3 = c.String(),
                        mark_15m4 = c.String(),
                        mark_15m5 = c.String(),
                        mark_45m1 = c.String(),
                        mark_45m2 = c.String(),
                        mark_45m3 = c.String(),
                        mark_45m4 = c.String(),
                        mark_subjects = c.String(),
                        comment = c.String(),
                        comment1 = c.String(),
                        comment2 = c.String(),
                    })
                .PrimaryKey(t => new { t.CLassId, t.StudentId, t.SubjectId, t.YearId, t.SemesterId })
                .ForeignKey("dbo.Classes", t => t.CLassId)
                .ForeignKey("dbo.Semesters", t => t.SemesterId)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .ForeignKey("dbo.Subjects", t => t.SubjectId)
                .ForeignKey("dbo.Years", t => t.YearId)
                .Index(t => t.CLassId)
                .Index(t => t.StudentId)
                .Index(t => t.SubjectId)
                .Index(t => t.YearId)
                .Index(t => t.SemesterId);
            
            CreateTable(
                "dbo.Semesters",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FocusExams",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        SubjectId = c.String(nullable: false, maxLength: 128),
                        YearId = c.String(nullable: false, maxLength: 128),
                        SemesterId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Mark = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        Grade = c.String(),
                    })
                .PrimaryKey(t => new { t.Id, t.SubjectId, t.YearId, t.SemesterId })
                .ForeignKey("dbo.Semesters", t => t.SemesterId)
                .ForeignKey("dbo.Subjects", t => t.SubjectId)
                .ForeignKey("dbo.Years", t => t.YearId)
                .Index(t => t.SubjectId)
                .Index(t => t.YearId)
                .Index(t => t.SemesterId);
            
            CreateTable(
                "dbo.HomeRoomTeachers",
                c => new
                    {
                        TeacherId = c.String(nullable: false, maxLength: 128),
                        ClassId = c.String(nullable: false, maxLength: 128),
                        YearId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.TeacherId, t.ClassId, t.YearId })
                .ForeignKey("dbo.Classes", t => t.ClassId)
                .ForeignKey("dbo.Teachers", t => t.TeacherId)
                .ForeignKey("dbo.Years", t => t.YearId)
                .Index(t => t.TeacherId)
                .Index(t => t.ClassId)
                .Index(t => t.YearId);
            
            CreateTable(
                "dbo.RoleActions",
                c => new
                    {
                        ActionId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.ActionId, t.RoleId })
                .ForeignKey("dbo.Actions", t => t.ActionId)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.ActionId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.SetColumnContacts",
                c => new
                    {
                        YearId = c.String(nullable: false, maxLength: 128),
                        TeacherId = c.String(nullable: false, maxLength: 128),
                        mark_5m = c.Int(nullable: false),
                        mark_15m = c.Int(nullable: false),
                        mark_45m = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.YearId, t.TeacherId })
                .ForeignKey("dbo.Teachers", t => t.TeacherId)
                .ForeignKey("dbo.Years", t => t.YearId)
                .Index(t => t.YearId)
                .Index(t => t.TeacherId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SetColumnContacts", "YearId", "dbo.Years");
            DropForeignKey("dbo.SetColumnContacts", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.RoleActions", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.RoleActions", "ActionId", "dbo.Actions");
            DropForeignKey("dbo.HomeRoomTeachers", "YearId", "dbo.Years");
            DropForeignKey("dbo.HomeRoomTeachers", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.HomeRoomTeachers", "ClassId", "dbo.Classes");
            DropForeignKey("dbo.FocusExams", "YearId", "dbo.Years");
            DropForeignKey("dbo.FocusExams", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.FocusExams", "SemesterId", "dbo.Semesters");
            DropForeignKey("dbo.Contacts", "YearId", "dbo.Years");
            DropForeignKey("dbo.Contacts", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Contacts", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Contacts", "SemesterId", "dbo.Semesters");
            DropForeignKey("dbo.Contacts", "CLassId", "dbo.Classes");
            DropForeignKey("dbo.ClassTeachers", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Teachers", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Teachers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ClassTeachers", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.ClassTeachers", "ClassId", "dbo.Classes");
            DropForeignKey("dbo.ClassStudents", "YearId", "dbo.Years");
            DropForeignKey("dbo.ClassStudents", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Students", "Parent_Id", "dbo.Parents");
            DropForeignKey("dbo.Parents", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Students", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ClassStudents", "ClassId", "dbo.Classes");
            DropIndex("dbo.SetColumnContacts", new[] { "TeacherId" });
            DropIndex("dbo.SetColumnContacts", new[] { "YearId" });
            DropIndex("dbo.RoleActions", new[] { "RoleId" });
            DropIndex("dbo.RoleActions", new[] { "ActionId" });
            DropIndex("dbo.HomeRoomTeachers", new[] { "YearId" });
            DropIndex("dbo.HomeRoomTeachers", new[] { "ClassId" });
            DropIndex("dbo.HomeRoomTeachers", new[] { "TeacherId" });
            DropIndex("dbo.FocusExams", new[] { "SemesterId" });
            DropIndex("dbo.FocusExams", new[] { "YearId" });
            DropIndex("dbo.FocusExams", new[] { "SubjectId" });
            DropIndex("dbo.Contacts", new[] { "SemesterId" });
            DropIndex("dbo.Contacts", new[] { "YearId" });
            DropIndex("dbo.Contacts", new[] { "SubjectId" });
            DropIndex("dbo.Contacts", new[] { "StudentId" });
            DropIndex("dbo.Contacts", new[] { "CLassId" });
            DropIndex("dbo.Teachers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Teachers", new[] { "SubjectId" });
            DropIndex("dbo.ClassTeachers", new[] { "TeacherId" });
            DropIndex("dbo.ClassTeachers", new[] { "SubjectId" });
            DropIndex("dbo.ClassTeachers", new[] { "ClassId" });
            DropIndex("dbo.Parents", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Students", new[] { "Parent_Id" });
            DropIndex("dbo.Students", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ClassStudents", new[] { "YearId" });
            DropIndex("dbo.ClassStudents", new[] { "ClassId" });
            DropIndex("dbo.ClassStudents", new[] { "StudentId" });
            DropTable("dbo.SetColumnContacts");
            DropTable("dbo.RoleActions");
            DropTable("dbo.HomeRoomTeachers");
            DropTable("dbo.FocusExams");
            DropTable("dbo.Semesters");
            DropTable("dbo.Contacts");
            DropTable("dbo.Teachers");
            DropTable("dbo.Subjects");
            DropTable("dbo.ClassTeachers");
            DropTable("dbo.Years");
            DropTable("dbo.Parents");
            DropTable("dbo.Students");
            DropTable("dbo.ClassStudents");
            DropTable("dbo.Classes");
            DropTable("dbo.Actions");
        }
    }
}
