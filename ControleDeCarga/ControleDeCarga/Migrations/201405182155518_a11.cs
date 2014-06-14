namespace ControleDeCarga.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a11 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Carga", name: "StatusCarga_Id", newName: "StatusCargaId");
            DropColumn("dbo.Carga", "StatusId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Carga", "StatusId", c => c.Int());
            RenameColumn(table: "dbo.Carga", name: "StatusCargaId", newName: "StatusCarga_Id");
        }
    }
}
