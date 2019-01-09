namespace SuperheroesProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Superheroes1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Superheroes", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Superheroes", "Image", c => c.String());
        }
    }
}
