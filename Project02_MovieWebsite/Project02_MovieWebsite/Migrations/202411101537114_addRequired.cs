namespace Project02_MovieWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Genres", "Name", c => c.String(nullable: true));
            AlterColumn("dbo.Movies", "Title", c => c.String(nullable: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Title", c => c.String());
            AlterColumn("dbo.Genres", "Name", c => c.String());
        }
    }
}
