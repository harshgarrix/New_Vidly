namespace New_Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingForeignKeyForGenreTypes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "GenreTypesId", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "GenreTypesId");
        }
    }
}
