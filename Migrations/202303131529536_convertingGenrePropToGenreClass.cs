namespace New_Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class convertingGenrePropToGenreClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GenreTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movies", "GenreTypes_Id", c => c.Int());
            CreateIndex("dbo.Movies", "GenreTypes_Id");
            AddForeignKey("dbo.Movies", "GenreTypes_Id", "dbo.GenreTypes", "Id");
            DropColumn("dbo.Movies", "Genre");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Genre", c => c.String());
            DropForeignKey("dbo.Movies", "GenreTypes_Id", "dbo.GenreTypes");
            DropIndex("dbo.Movies", new[] { "GenreTypes_Id" });
            DropColumn("dbo.Movies", "GenreTypes_Id");
            DropTable("dbo.GenreTypes");
        }
    }
}
