namespace ControleDeCarga.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Armador", "CriadoPor_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Armador", "ModificadoPor_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Armador", new[] { "CriadoPor_Id" });
            DropIndex("dbo.Armador", new[] { "ModificadoPor_Id" });
            AlterColumn("dbo.Armador", "CriadoPorUserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Armador", "ModificadoPorUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Armador", "CriadoPorUserId");
            CreateIndex("dbo.Armador", "ModificadoPorUserId");
            AddForeignKey("dbo.Armador", "CriadoPorUserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Armador", "ModificadoPorUserId", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Armador", "CriadoPor_Id");
            DropColumn("dbo.Armador", "ModificadoPor_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Armador", "ModificadoPor_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Armador", "CriadoPor_Id", c => c.String(maxLength: 128));
            DropForeignKey("dbo.Armador", "ModificadoPorUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Armador", "CriadoPorUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Armador", new[] { "ModificadoPorUserId" });
            DropIndex("dbo.Armador", new[] { "CriadoPorUserId" });
            AlterColumn("dbo.Armador", "ModificadoPorUserId", c => c.String());
            AlterColumn("dbo.Armador", "CriadoPorUserId", c => c.String());
            CreateIndex("dbo.Armador", "ModificadoPor_Id");
            CreateIndex("dbo.Armador", "CriadoPor_Id");
            AddForeignKey("dbo.Armador", "ModificadoPor_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Armador", "CriadoPor_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
