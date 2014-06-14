namespace ControleDeCarga.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a14 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Carga", "ArmadorId", "dbo.Armador");
            DropForeignKey("dbo.Carga", "LocalDeDevolucaoId", "dbo.LocalDeDevolucao");
            DropForeignKey("dbo.Carga", "NavioId", "dbo.Navio");
            DropForeignKey("dbo.Carga", "PortoSecoId", "dbo.PortoSeco");
            DropIndex("dbo.Carga", new[] { "ArmadorId" });
            DropIndex("dbo.Carga", new[] { "LocalDeDevolucaoId" });
            DropIndex("dbo.Carga", new[] { "NavioId" });
            DropIndex("dbo.Carga", new[] { "PortoSecoId" });
            CreateTable(
                "dbo.Container",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CargaContainerId = c.Int(nullable: false),
                        TipoContainer = c.String(),
                        Identificador = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Carga", t => t.CargaContainerId, cascadeDelete: true)
                .Index(t => t.CargaContainerId);
            
            AddColumn("dbo.Carga", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Carga", "ArmadorId");
            CreateIndex("dbo.Carga", "LocalDeDevolucaoId");
            CreateIndex("dbo.Carga", "NavioId");
            CreateIndex("dbo.Carga", "PortoSecoId");
            AddForeignKey("dbo.Carga", "ArmadorId", "dbo.Armador", "Id");
            AddForeignKey("dbo.Carga", "LocalDeDevolucaoId", "dbo.LocalDeDevolucao", "Id");
            AddForeignKey("dbo.Carga", "NavioId", "dbo.Navio", "Id");
            AddForeignKey("dbo.Carga", "PortoSecoId", "dbo.PortoSeco", "Id");
            DropColumn("dbo.Carga", "TipoContainer");
            DropColumn("dbo.Carga", "Container");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Carga", "Container", c => c.String());
            AddColumn("dbo.Carga", "TipoContainer", c => c.String());
            DropForeignKey("dbo.Carga", "PortoSecoId", "dbo.PortoSeco");
            DropForeignKey("dbo.Carga", "NavioId", "dbo.Navio");
            DropForeignKey("dbo.Carga", "LocalDeDevolucaoId", "dbo.LocalDeDevolucao");
            DropForeignKey("dbo.Container", "CargaContainerId", "dbo.Carga");
            DropForeignKey("dbo.Carga", "ArmadorId", "dbo.Armador");
            DropIndex("dbo.Carga", new[] { "PortoSecoId" });
            DropIndex("dbo.Carga", new[] { "NavioId" });
            DropIndex("dbo.Carga", new[] { "LocalDeDevolucaoId" });
            DropIndex("dbo.Container", new[] { "CargaContainerId" });
            DropIndex("dbo.Carga", new[] { "ArmadorId" });
            DropColumn("dbo.Carga", "Discriminator");
            DropTable("dbo.Container");
            CreateIndex("dbo.Carga", "PortoSecoId");
            CreateIndex("dbo.Carga", "NavioId");
            CreateIndex("dbo.Carga", "LocalDeDevolucaoId");
            CreateIndex("dbo.Carga", "ArmadorId");
            AddForeignKey("dbo.Carga", "PortoSecoId", "dbo.PortoSeco", "Id");
            AddForeignKey("dbo.Carga", "NavioId", "dbo.Navio", "Id");
            AddForeignKey("dbo.Carga", "LocalDeDevolucaoId", "dbo.LocalDeDevolucao", "Id");
            AddForeignKey("dbo.Carga", "ArmadorId", "dbo.Armador", "Id");
        }
    }
}
