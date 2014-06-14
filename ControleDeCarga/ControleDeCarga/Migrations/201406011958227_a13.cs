namespace ControleDeCarga.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a13 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Filial",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Cidade = c.String(),
                        UfId = c.Int(nullable: false),
                        Endereco = c.String(),
                        Telefone = c.String(),
                        Radio = c.String(),
                        Email = c.String(),
                        Contato = c.String(),
                        CriadoPorUserId = c.String(maxLength: 128),
                        CriadoEm = c.DateTime(),
                        ModificadoPorUserId = c.String(maxLength: 128),
                        ModificadoEm = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CriadoPorUserId)
                .ForeignKey("dbo.AspNetUsers", t => t.ModificadoPorUserId)
                .ForeignKey("dbo.UF", t => t.UfId, cascadeDelete: true)
                .Index(t => t.CriadoPorUserId)
                .Index(t => t.ModificadoPorUserId)
                .Index(t => t.UfId);
            
            AddColumn("dbo.Carga", "FilialId", c => c.Int());
            CreateIndex("dbo.Carga", "FilialId");
            AddForeignKey("dbo.Carga", "FilialId", "dbo.Filial", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carga", "FilialId", "dbo.Filial");
            DropForeignKey("dbo.Filial", "UfId", "dbo.UF");
            DropForeignKey("dbo.Filial", "ModificadoPorUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Filial", "CriadoPorUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Carga", new[] { "FilialId" });
            DropIndex("dbo.Filial", new[] { "UfId" });
            DropIndex("dbo.Filial", new[] { "ModificadoPorUserId" });
            DropIndex("dbo.Filial", new[] { "CriadoPorUserId" });
            DropColumn("dbo.Carga", "FilialId");
            DropTable("dbo.Filial");
        }
    }
}
