namespace New_Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangingGenreTypeIdToByte : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "GenreTypes_Id", "dbo.GenreTypes");
            DropIndex("dbo.Movies", new[] { "GenreTypes_Id" });
            DropColumn("dbo.Movies", "GenreTypesId");
            RenameColumn(table: "dbo.Movies", name: "GenreTypes_Id", newName: "GenreTypesId");
            DropPrimaryKey("dbo.GenreTypes");
            AlterColumn("dbo.Movies", "GenreTypesId", c => c.Byte(nullable: false));
            AlterColumn("dbo.GenreTypes", "Id", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.GenreTypes", "Id");
            CreateIndex("dbo.Movies", "GenreTypesId");
            AddForeignKey("dbo.Movies", "GenreTypesId", "dbo.GenreTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GenreTypesId", "dbo.GenreTypes");
            DropIndex("dbo.Movies", new[] { "GenreTypesId" });
            DropPrimaryKey("dbo.GenreTypes");
            AlterColumn("dbo.GenreTypes", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Movies", "GenreTypesId", c => c.Int());
            AddPrimaryKey("dbo.GenreTypes", "Id");
            RenameColumn(table: "dbo.Movies", name: "GenreTypesId", newName: "GenreTypes_Id");
            AddColumn("dbo.Movies", "GenreTypesId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Movies", "GenreTypes_Id");
            AddForeignKey("dbo.Movies", "GenreTypes_Id", "dbo.GenreTypes", "Id");
        }
    }
}
