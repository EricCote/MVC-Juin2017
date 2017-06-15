namespace Stationnement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StringLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Inscriptions", "Nom", c => c.String(maxLength: 50));
            AlterColumn("dbo.Inscriptions", "Courriel", c => c.String(maxLength: 75));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Inscriptions", "Courriel", c => c.String());
            AlterColumn("dbo.Inscriptions", "Nom", c => c.String());
        }
    }
}
