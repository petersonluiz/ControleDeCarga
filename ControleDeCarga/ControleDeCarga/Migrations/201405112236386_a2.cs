namespace ControleDeCarga.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Tipoveiculos", newName: "TipoVeiculo");
            RenameTable(name: "dbo.veiculos", newName: "Veiculo");
            CreateTable(
                "dbo.Armador",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        PessoaContato = c.String(),
                        Telefone = c.String(),
                        Email = c.String(),
                        CriadoPorUserId = c.String(),
                        CriadoEm = c.DateTime(),
                        ModificadoPorUserId = c.String(),
                        ModificadoEm = c.DateTime(),
                        CriadoPor_Id = c.String(maxLength: 128),
                        ModificadoPor_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CriadoPor_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ModificadoPor_Id)
                .Index(t => t.CriadoPor_Id)
                .Index(t => t.ModificadoPor_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Armador", "ModificadoPor_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Armador", "CriadoPor_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Armador", new[] { "ModificadoPor_Id" });
            DropIndex("dbo.Armador", new[] { "CriadoPor_Id" });
            DropTable("dbo.Armador");
            RenameTable(name: "dbo.Veiculo", newName: "veiculos");
            RenameTable(name: "dbo.TipoVeiculo", newName: "Tipoveiculos");
        }
    }
}
