namespace ControleDeCarga.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a9 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LocalDeDevolucao",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        CriadoPorUserId = c.String(maxLength: 128),
                        CriadoEm = c.DateTime(),
                        ModificadoPorUserId = c.String(maxLength: 128),
                        ModificadoEm = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CriadoPorUserId)
                .ForeignKey("dbo.AspNetUsers", t => t.ModificadoPorUserId)
                .Index(t => t.CriadoPorUserId)
                .Index(t => t.ModificadoPorUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LocalDeDevolucao", "ModificadoPorUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.LocalDeDevolucao", "CriadoPorUserId", "dbo.AspNetUsers");
            DropIndex("dbo.LocalDeDevolucao", new[] { "ModificadoPorUserId" });
            DropIndex("dbo.LocalDeDevolucao", new[] { "CriadoPorUserId" });
            DropTable("dbo.LocalDeDevolucao");
        }
    }
}
