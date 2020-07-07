namespace SportsEquipmentRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletingFirstCustomers : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM Customers WHERE Id=1;");
            Sql("DELETE FROM Customers WHERE Id=2;");
        }
        
        public override void Down()
        {
        }
    }
}
