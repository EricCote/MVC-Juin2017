namespace Stationnement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Inscriptions",
                c => new
                    {
                        InscriptionID = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Courriel = c.String(),
                    })
                .PrimaryKey(t => t.InscriptionID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Inscriptions");
        }
    }
}
