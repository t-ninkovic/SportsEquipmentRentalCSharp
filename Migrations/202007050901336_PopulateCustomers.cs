namespace SportsEquipmentRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCustomers : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Customers (Name, Address, PhoneNumber) VALUES ('Tijana Ninkovic', '6 rue de Vassieux en Vercors', '07070707')");
            Sql("INSERT INTO Customers (Name, Address, PhoneNumber) VALUES ('John Doe', '3 Avenue Jules Valles', '06060606')");
        }
        
        public override void Down()
        {
        }
    }
}
