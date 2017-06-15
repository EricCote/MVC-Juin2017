namespace Stationnement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjoutPays : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Inscriptions", "Pays", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Inscriptions", "Pays");
        }
    }
}
