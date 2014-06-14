namespace ControleDeCarga.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a10 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carga",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImportadorId = c.Int(nullable: false),
                        ExportadorId = c.Int(nullable: false),
                        DTA = c.String(),
                        DI_DSI = c.String(),
                        MercadoriaId = c.Int(nullable: false),
                        EspecieId = c.Int(nullable: false),
                        Quantidade = c.Int(),
                        PortoSecoId = c.Int(),
                        LocalDeEntregaId = c.Int(nullable: false),
                        StatusId = c.Int(),
                        TipoContainer = c.String(),
                        Container = c.String(),
                        LocalDeDevolucaoId = c.Int(),
                        NavioId = c.Int(),
                        ArmadorId = c.Int(),
                        CriadoPorUserId = c.String(maxLength: 128),
                        CriadoEm = c.DateTime(),
                        ModificadoPorUserId = c.String(maxLength: 128),
                        ModificadoEm = c.DateTime(),
                        StatusCarga_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Armador", t => t.ArmadorId)
                .ForeignKey("dbo.AspNetUsers", t => t.CriadoPorUserId)
                .ForeignKey("dbo.Especie", t => t.EspecieId, cascadeDelete: true)
                .ForeignKey("dbo.Exportador", t => t.ExportadorId, cascadeDelete: true)
                .ForeignKey("dbo.Importador", t => t.ImportadorId, cascadeDelete: true)
                .ForeignKey("dbo.LocalDeDevolucao", t => t.LocalDeDevolucaoId)
                .ForeignKey("dbo.LocalDeEntrega", t => t.LocalDeEntregaId, cascadeDelete: true)
                .ForeignKey("dbo.Mercadoria", t => t.MercadoriaId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ModificadoPorUserId)
                .ForeignKey("dbo.Navio", t => t.NavioId)
                .ForeignKey("dbo.PortoSeco", t => t.PortoSecoId)
                .ForeignKey("dbo.StatusCarga", t => t.StatusCarga_Id)
                .Index(t => t.ArmadorId)
                .Index(t => t.CriadoPorUserId)
                .Index(t => t.EspecieId)
                .Index(t => t.ExportadorId)
                .Index(t => t.ImportadorId)
                .Index(t => t.LocalDeDevolucaoId)
                .Index(t => t.LocalDeEntregaId)
                .Index(t => t.MercadoriaId)
                .Index(t => t.ModificadoPorUserId)
                .Index(t => t.NavioId)
                .Index(t => t.PortoSecoId)
                .Index(t => t.StatusCarga_Id);
            
            CreateTable(
                "dbo.Especie",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Descricao = c.String(),
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
            
            CreateTable(
                "dbo.Exportador",
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
            
            CreateTable(
                "dbo.HistoricoCarga",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EventoId = c.Int(),
                        Data = c.DateTime(),
                        MotoristaId = c.Int(),
                        VeiculoId = c.Int(),
                        Observacoes = c.String(),
                        CargaId = c.Int(),
                        CriadoPorUserId = c.String(maxLength: 128),
                        CriadoEm = c.DateTime(),
                        ModificadoPorUserId = c.String(maxLength: 128),
                        ModificadoEm = c.DateTime(),
                        Eventos_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Carga", t => t.CargaId)
                .ForeignKey("dbo.AspNetUsers", t => t.CriadoPorUserId)
                .ForeignKey("dbo.Eventos", t => t.Eventos_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ModificadoPorUserId)
                .ForeignKey("dbo.Motorista", t => t.MotoristaId)
                .ForeignKey("dbo.Veiculo", t => t.VeiculoId)
                .Index(t => t.CargaId)
                .Index(t => t.CriadoPorUserId)
                .Index(t => t.Eventos_Id)
                .Index(t => t.ModificadoPorUserId)
                .Index(t => t.MotoristaId)
                .Index(t => t.VeiculoId);
            
            CreateTable(
                "dbo.Eventos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Evento = c.String(),
                        EnviarEmail = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Motorista",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Telefone = c.String(),
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
            
            CreateTable(
                "dbo.Importador",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        CNPJ = c.String(),
                        Endereco = c.String(),
                        Telefone = c.String(),
                        Email = c.String(),
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
            
            CreateTable(
                "dbo.Mercadoria",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Descricao = c.String(),
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
            
            CreateTable(
                "dbo.Navio",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Descricao = c.String(),
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
            
            CreateTable(
                "dbo.StatusCarga",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Despachante",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Telefone = c.String(),
                        Email = c.String(),
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
            
            CreateTable(
                "dbo.Parceiro",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Telefone = c.String(),
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
            DropForeignKey("dbo.Parceiro", "ModificadoPorUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Parceiro", "CriadoPorUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Despachante", "ModificadoPorUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Despachante", "CriadoPorUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Carga", "StatusCarga_Id", "dbo.StatusCarga");
            DropForeignKey("dbo.Carga", "PortoSecoId", "dbo.PortoSeco");
            DropForeignKey("dbo.Navio", "ModificadoPorUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Navio", "CriadoPorUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Carga", "NavioId", "dbo.Navio");
            DropForeignKey("dbo.Carga", "ModificadoPorUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Mercadoria", "ModificadoPorUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Mercadoria", "CriadoPorUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Carga", "MercadoriaId", "dbo.Mercadoria");
            DropForeignKey("dbo.Carga", "LocalDeEntregaId", "dbo.LocalDeEntrega");
            DropForeignKey("dbo.Carga", "LocalDeDevolucaoId", "dbo.LocalDeDevolucao");
            DropForeignKey("dbo.Importador", "ModificadoPorUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Importador", "CriadoPorUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Carga", "ImportadorId", "dbo.Importador");
            DropForeignKey("dbo.HistoricoCarga", "VeiculoId", "dbo.Veiculo");
            DropForeignKey("dbo.Motorista", "ModificadoPorUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.HistoricoCarga", "MotoristaId", "dbo.Motorista");
            DropForeignKey("dbo.Motorista", "CriadoPorUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.HistoricoCarga", "ModificadoPorUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.HistoricoCarga", "Eventos_Id", "dbo.Eventos");
            DropForeignKey("dbo.HistoricoCarga", "CriadoPorUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.HistoricoCarga", "CargaId", "dbo.Carga");
            DropForeignKey("dbo.Exportador", "ModificadoPorUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Exportador", "CriadoPorUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Carga", "ExportadorId", "dbo.Exportador");
            DropForeignKey("dbo.Especie", "ModificadoPorUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Especie", "CriadoPorUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Carga", "EspecieId", "dbo.Especie");
            DropForeignKey("dbo.Carga", "CriadoPorUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Carga", "ArmadorId", "dbo.Armador");
            DropIndex("dbo.Parceiro", new[] { "ModificadoPorUserId" });
            DropIndex("dbo.Parceiro", new[] { "CriadoPorUserId" });
            DropIndex("dbo.Despachante", new[] { "ModificadoPorUserId" });
            DropIndex("dbo.Despachante", new[] { "CriadoPorUserId" });
            DropIndex("dbo.Carga", new[] { "StatusCarga_Id" });
            DropIndex("dbo.Carga", new[] { "PortoSecoId" });
            DropIndex("dbo.Navio", new[] { "ModificadoPorUserId" });
            DropIndex("dbo.Navio", new[] { "CriadoPorUserId" });
            DropIndex("dbo.Carga", new[] { "NavioId" });
            DropIndex("dbo.Carga", new[] { "ModificadoPorUserId" });
            DropIndex("dbo.Mercadoria", new[] { "ModificadoPorUserId" });
            DropIndex("dbo.Mercadoria", new[] { "CriadoPorUserId" });
            DropIndex("dbo.Carga", new[] { "MercadoriaId" });
            DropIndex("dbo.Carga", new[] { "LocalDeEntregaId" });
            DropIndex("dbo.Carga", new[] { "LocalDeDevolucaoId" });
            DropIndex("dbo.Importador", new[] { "ModificadoPorUserId" });
            DropIndex("dbo.Importador", new[] { "CriadoPorUserId" });
            DropIndex("dbo.Carga", new[] { "ImportadorId" });
            DropIndex("dbo.HistoricoCarga", new[] { "VeiculoId" });
            DropIndex("dbo.Motorista", new[] { "ModificadoPorUserId" });
            DropIndex("dbo.HistoricoCarga", new[] { "MotoristaId" });
            DropIndex("dbo.Motorista", new[] { "CriadoPorUserId" });
            DropIndex("dbo.HistoricoCarga", new[] { "ModificadoPorUserId" });
            DropIndex("dbo.HistoricoCarga", new[] { "Eventos_Id" });
            DropIndex("dbo.HistoricoCarga", new[] { "CriadoPorUserId" });
            DropIndex("dbo.HistoricoCarga", new[] { "CargaId" });
            DropIndex("dbo.Exportador", new[] { "ModificadoPorUserId" });
            DropIndex("dbo.Exportador", new[] { "CriadoPorUserId" });
            DropIndex("dbo.Carga", new[] { "ExportadorId" });
            DropIndex("dbo.Especie", new[] { "ModificadoPorUserId" });
            DropIndex("dbo.Especie", new[] { "CriadoPorUserId" });
            DropIndex("dbo.Carga", new[] { "EspecieId" });
            DropIndex("dbo.Carga", new[] { "CriadoPorUserId" });
            DropIndex("dbo.Carga", new[] { "ArmadorId" });
            DropTable("dbo.Parceiro");
            DropTable("dbo.Despachante");
            DropTable("dbo.StatusCarga");
            DropTable("dbo.Navio");
            DropTable("dbo.Mercadoria");
            DropTable("dbo.Importador");
            DropTable("dbo.Motorista");
            DropTable("dbo.Eventos");
            DropTable("dbo.HistoricoCarga");
            DropTable("dbo.Exportador");
            DropTable("dbo.Especie");
            DropTable("dbo.Carga");
        }
    }
}
