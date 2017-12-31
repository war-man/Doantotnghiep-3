namespace DOAN_CHuyenNGanh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class action : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RoleActions", "Id_Id", "dbo.AspNetRoles");
            DropIndex("dbo.RoleActions", new[] { "Id_Id" });
            RenameColumn(table: "dbo.RoleActions", name: "Id_Id", newName: "RoleId");
            DropPrimaryKey("dbo.RoleActions");
            AlterColumn("dbo.RoleActions", "RoleId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.RoleActions", new[] { "ActionId", "RoleId" });
            CreateIndex("dbo.RoleActions", "RoleId");
            AddForeignKey("dbo.RoleActions", "RoleId", "dbo.AspNetRoles", "Id", cascadeDelete: true);
            DropColumn("dbo.RoleActions", "Id_Role");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RoleActions", "Id_Role", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.RoleActions", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.RoleActions", new[] { "RoleId" });
            DropPrimaryKey("dbo.RoleActions");
            AlterColumn("dbo.RoleActions", "RoleId", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.RoleActions", new[] { "ActionId", "Id_Role" });
            RenameColumn(table: "dbo.RoleActions", name: "RoleId", newName: "Id_Id");
            CreateIndex("dbo.RoleActions", "Id_Id");
            AddForeignKey("dbo.RoleActions", "Id_Id", "dbo.AspNetRoles", "Id");
        }
    }
}
