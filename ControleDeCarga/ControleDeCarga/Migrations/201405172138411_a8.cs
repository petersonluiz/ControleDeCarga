namespace ControleDeCarga.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a8 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PortoSeco", "Cidade");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PortoSeco", "Cidade", c => c.String());
        }
    }
}
