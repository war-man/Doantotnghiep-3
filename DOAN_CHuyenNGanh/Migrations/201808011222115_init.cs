namespace DOAN_CHuyenNGanh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actions",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Url = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        DeleteFlag = c.Boolean(nullable: false),
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
                        birth_place = c.Int(nullable: false),
                        ngayvaodoan = c.String(nullable: false),
                        ngayvaodoi = c.String(nullable: false),
                        name_birth_place = c.String(nullable: false),
                        quequan = c.String(nullable: false),
                        description = c.String(nullable: false),
                        urlImage = c.String(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        Parent_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Parents", t => t.Parent_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Parent_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
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
                        name_Teacher = c.String(nullable: false, maxLength: 100),
                        sex = c.Boolean(nullable: false),
                        address = c.String(nullable: false, maxLength: 100),
                        first_name = c.String(maxLength: 50),
                        birth_day = c.String(nullable: false),
                        birth_place = c.Int(nullable: false),
                        name_birth_place = c.String(nullable: false),
                        people = c.String(nullable: false, maxLength: 10),
                        phone_number = c.String(nullable: false),
                        email = c.String(nullable: false),
                        prefecture = c.String(nullable: false),
                        city = c.String(nullable: false),
                        phuongxa = c.String(nullable: false),
                        matrimony = c.String(nullable: false),
                        identity_card_number = c.Long(nullable: false),
                        gifted = c.String(nullable: false, maxLength: 255),
                        status_heal = c.String(nullable: false),
                        disabilities = c.String(nullable: false),
                        start_date_social_insurance = c.String(nullable: false),
                        number_social_insurance = c.Long(nullable: false),
                        numberBank = c.Long(nullable: false),
                        nameBank = c.String(nullable: false),
                        status_deleted = c.Boolean(nullable: false),
                        SubjectId = c.String(maxLength: 128),
                        urlImage = c.String(),
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
                        ClassId = c.String(nullable: false, maxLength: 128),
                        YearId = c.String(nullable: false, maxLength: 128),
                        TeacherId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.ClassId, t.YearId })
                .ForeignKey("dbo.Classes", t => t.ClassId)
                .ForeignKey("dbo.Teachers", t => t.TeacherId)
                .ForeignKey("dbo.Years", t => t.YearId)
                .Index(t => t.ClassId)
                .Index(t => t.YearId)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        LinkImage = c.String(),
                        DeleteFlag = c.Boolean(nullable: false),
                        Category_Id = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        Category_Id1 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id1)
                .Index(t => t.Category_Id1);
            
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
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.ScheduleTeachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Lesson = c.Int(nullable: false),
                        weekdays = c.Int(nullable: false),
                        SemesterId = c.String(maxLength: 128),
                        YearId = c.String(maxLength: 128),
                        TeacherId = c.String(maxLength: 128),
                        ClassId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Classes", t => t.ClassId)
                .ForeignKey("dbo.Semesters", t => t.SemesterId)
                .ForeignKey("dbo.Teachers", t => t.TeacherId)
                .ForeignKey("dbo.Years", t => t.YearId)
                .Index(t => t.SemesterId)
                .Index(t => t.YearId)
                .Index(t => t.TeacherId)
                .Index(t => t.ClassId);
            
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
            DropForeignKey("dbo.ScheduleTeachers", "YearId", "dbo.Years");
            DropForeignKey("dbo.ScheduleTeachers", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.ScheduleTeachers", "SemesterId", "dbo.Semesters");
            DropForeignKey("dbo.ScheduleTeachers", "ClassId", "dbo.Classes");
            DropForeignKey("dbo.RoleActions", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.RoleActions", "ActionId", "dbo.Actions");
            DropForeignKey("dbo.Posts", "Category_Id1", "dbo.Categories");
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
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ClassStudents", "ClassId", "dbo.Classes");
            DropIndex("dbo.SetColumnContacts", new[] { "TeacherId" });
            DropIndex("dbo.SetColumnContacts", new[] { "YearId" });
            DropIndex("dbo.ScheduleTeachers", new[] { "ClassId" });
            DropIndex("dbo.ScheduleTeachers", new[] { "TeacherId" });
            DropIndex("dbo.ScheduleTeachers", new[] { "YearId" });
            DropIndex("dbo.ScheduleTeachers", new[] { "SemesterId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.RoleActions", new[] { "RoleId" });
            DropIndex("dbo.RoleActions", new[] { "ActionId" });
            DropIndex("dbo.Posts", new[] { "Category_Id1" });
            DropIndex("dbo.HomeRoomTeachers", new[] { "TeacherId" });
            DropIndex("dbo.HomeRoomTeachers", new[] { "YearId" });
            DropIndex("dbo.HomeRoomTeachers", new[] { "ClassId" });
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
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Students", new[] { "Parent_Id" });
            DropIndex("dbo.Students", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ClassStudents", new[] { "YearId" });
            DropIndex("dbo.ClassStudents", new[] { "ClassId" });
            DropIndex("dbo.ClassStudents", new[] { "StudentId" });
            DropTable("dbo.SetColumnContacts");
            DropTable("dbo.ScheduleTeachers");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.RoleActions");
            DropTable("dbo.Posts");
            DropTable("dbo.HomeRoomTeachers");
            DropTable("dbo.FocusExams");
            DropTable("dbo.Semesters");
            DropTable("dbo.Contacts");
            DropTable("dbo.Teachers");
            DropTable("dbo.Subjects");
            DropTable("dbo.ClassTeachers");
            DropTable("dbo.Years");
            DropTable("dbo.Parents");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Students");
            DropTable("dbo.ClassStudents");
            DropTable("dbo.Classes");
            DropTable("dbo.Categories");
            DropTable("dbo.Actions");
        }
    }
}
