namespace New_Vidly.Migrations
{
    using Newtonsoft.Json.Linq;
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatingMovieDetails : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Name, ReleaseDate, DateAdded, NumberInStock, GenreTypesId) VALUES ('Hangover', '26/06/2009', '22/02/2023', 10, 2)");
            Sql("INSERT INTO Movies (Name, ReleaseDate, DateAdded, NumberInStock, GenreTypesId) VALUES ('Die Hard', '22/07/1988', '22/02/2023', 20, 1)");
            Sql("INSERT INTO Movies (Name, ReleaseDate, DateAdded, NumberInStock, GenreTypesId) VALUES ('The Terminator', '26/10/1984', '22/02/2023', 3, 1)");
            Sql("INSERT INTO Movies (Name, ReleaseDate, DateAdded, NumberInStock, GenreTypesId) VALUES ('Toy Story', '22/11/1995', '22/02/2023', 11, 3)");
            Sql("INSERT INTO Movies (Name, ReleaseDate, DateAdded, NumberInStock, GenreTypesId) VALUES ('Titanic', '19/12/1997', '22/02/2023', 99, 4)");
        }
        public override void Down()
        {
        }
    }
}
