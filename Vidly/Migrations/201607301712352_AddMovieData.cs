namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMovieData : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (GenreType) VALUES ('Action')");
            Sql("INSERT INTO Genres (GenreType) VALUES ('Horror')");
            Sql("INSERT INTO Genres (GenreType) VALUES ('Comedy')");
            Sql("INSERT INTO Genres (GenreType) VALUES ('Romance')");
        }
        
        public override void Down()
        {
        }
    }
}
