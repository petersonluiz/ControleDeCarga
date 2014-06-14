namespace ControleDeCarga.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a12 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.HistoricoCarga", "Eventos_Id", "dbo.Eventos");
            DropIndex("dbo.HistoricoCarga", new[] { "Eventos_Id" });
            CreateTable(
                "dbo.Evento",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        ProximoStatusId = c.Int(nullable: false),
                        EnviarEmail = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StatusCarga", t => t.ProximoStatusId, cascadeDelete: true)
                .Index(t => t.ProximoStatusId);
            
            CreateIndex("dbo.HistoricoCarga", "EventoId");
            AddForeignKey("dbo.HistoricoCarga", "EventoId", "dbo.Evento", "Id");
            DropColumn("dbo.HistoricoCarga", "Eventos_Id");
            DropTable("dbo.Eventos");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Eventos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Evento = c.String(),
                        EnviarEmail = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.HistoricoCarga", "Eventos_Id", c => c.Int());
            DropForeignKey("dbo.Evento", "ProximoStatusId", "dbo.StatusCarga");
            DropForeignKey("dbo.HistoricoCarga", "EventoId", "dbo.Evento");
            DropIndex("dbo.Evento", new[] { "ProximoStatusId" });
            DropIndex("dbo.HistoricoCarga", new[] { "EventoId" });
            DropTable("dbo.Evento");
            CreateIndex("dbo.HistoricoCarga", "Eventos_Id");
            AddForeignKey("dbo.HistoricoCarga", "Eventos_Id", "dbo.Eventos", "Id");
        }
    }
}
