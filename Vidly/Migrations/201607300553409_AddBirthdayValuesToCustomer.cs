namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBirthdayValuesToCustomer : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET Birthday = 06/22/1989 WHERE Id = 1");
            Sql("UPDATE Customers SET Birthday = 07/20/1989 WHERE Id = 2");
        }
        
        public override void Down()
        {
        }
    }
}
