namespace Stationnement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenommerAgeVersAnnees : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.Inscriptions", "Age", "Annees");

        }
        
        public override void Down()
        {
            RenameColumn("dbo.Inscriptions", "Annees", "Age");
        }
    }
}
