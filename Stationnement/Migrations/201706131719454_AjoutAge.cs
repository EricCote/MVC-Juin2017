namespace Stationnement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjoutAge : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Inscriptions", "Age", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Inscriptions", "Age");
        }
    }
}
