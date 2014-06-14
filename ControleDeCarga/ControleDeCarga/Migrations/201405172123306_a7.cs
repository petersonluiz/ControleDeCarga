namespace ControleDeCarga.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a7 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PortoSeco",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PortoSeco", "UfId", "dbo.UF");
            DropForeignKey("dbo.PortoSeco", "ModificadoPorUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.PortoSeco", "CriadoPorUserId", "dbo.AspNetUsers");
            DropIndex("dbo.PortoSeco", new[] { "UfId" });
            DropIndex("dbo.PortoSeco", new[] { "ModificadoPorUserId" });
            DropIndex("dbo.PortoSeco", new[] { "CriadoPorUserId" });
            DropTable("dbo.PortoSeco");
        }
    }
}
