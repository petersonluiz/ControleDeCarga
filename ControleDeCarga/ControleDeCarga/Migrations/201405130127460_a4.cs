namespace ControleDeCarga.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LocalDeEntrega",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cidade = c.String(),
                        UfId = c.Int(nullable: false),
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
            
            CreateTable(
                "dbo.UF",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Sigla = c.String(),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LocalDeEntrega", "UfId", "dbo.UF");
            DropForeignKey("dbo.LocalDeEntrega", "ModificadoPorUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.LocalDeEntrega", "CriadoPorUserId", "dbo.AspNetUsers");
            DropIndex("dbo.LocalDeEntrega", new[] { "UfId" });
            DropIndex("dbo.LocalDeEntrega", new[] { "ModificadoPorUserId" });
            DropIndex("dbo.LocalDeEntrega", new[] { "CriadoPorUserId" });
            DropTable("dbo.UF");
            DropTable("dbo.LocalDeEntrega");
        }
    }
}
