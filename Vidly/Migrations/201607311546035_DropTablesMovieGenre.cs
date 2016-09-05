namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropTablesMovieGenre : DbMigration
    {
        public override void Up()
        {
            
        }
        
        public override void Down()
        {
            Sql("DROP TABLE Movies");
            Sql("DROP TABLE Genres");
        }
    }
}
