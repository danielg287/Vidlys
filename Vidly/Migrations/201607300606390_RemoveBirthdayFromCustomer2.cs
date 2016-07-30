namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveBirthdayFromCustomer2 : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET Birthday = null WHERE Id = 2 ");
        }
        
        public override void Down()
        {
        }
    }
}
