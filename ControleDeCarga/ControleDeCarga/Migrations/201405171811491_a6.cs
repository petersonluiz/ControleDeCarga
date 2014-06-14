namespace ControleDeCarga.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Veiculo", "CreatedByUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Veiculo", "ModifiedByUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Veiculo", new[] { "CreatedByUserId" });
            DropIndex("dbo.Veiculo", new[] { "ModifiedByUserId" });
            AddColumn("dbo.Veiculo", "CriadoPorUserId", c => c.String(maxLength: 128));
            AddColumn("dbo.Veiculo", "ModificadoPorUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Veiculo", "CriadoPorUserId");
            CreateIndex("dbo.Veiculo", "ModificadoPorUserId");
            AddForeignKey("dbo.Veiculo", "CriadoPorUserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Veiculo", "ModificadoPorUserId", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Veiculo", "CreatedByUserId");
            DropColumn("dbo.Veiculo", "ModifiedByUserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Veiculo", "ModifiedByUserId", c => c.String(maxLength: 128));
            AddColumn("dbo.Veiculo", "CreatedByUserId", c => c.String(maxLength: 128));
            DropForeignKey("dbo.Veiculo", "ModificadoPorUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Veiculo", "CriadoPorUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Veiculo", new[] { "ModificadoPorUserId" });
            DropIndex("dbo.Veiculo", new[] { "CriadoPorUserId" });
            DropColumn("dbo.Veiculo", "ModificadoPorUserId");
            DropColumn("dbo.Veiculo", "CriadoPorUserId");
            CreateIndex("dbo.Veiculo", "ModifiedByUserId");
            CreateIndex("dbo.Veiculo", "CreatedByUserId");
            AddForeignKey("dbo.Veiculo", "ModifiedByUserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Veiculo", "CreatedByUserId", "dbo.AspNetUsers", "Id");
        }
    }
}
