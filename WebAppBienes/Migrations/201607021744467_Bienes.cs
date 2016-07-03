namespace WebAppBienes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Bienes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BienesModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FolioReal = c.String(),
                        AreaTerreno = c.Double(nullable: false),
                        Ubicacion = c.String(),
                        Precio = c.Double(nullable: false),
                        Financiamiento = c.String(),
                        FrenteTerreno = c.String(),
                        FondoTerreno = c.String(),
                        TopografiaTerreno = c.String(),
                        UsoSuelo = c.String(),
                        Descripcion = c.String(),
                        AreaConstrucción = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BienesModels");
        }
    }
}
