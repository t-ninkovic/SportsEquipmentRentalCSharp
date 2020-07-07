namespace SportsEquipmentRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMoreManufacturers : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Manufacturers (Name) VALUES ('Haibike')");
            Sql("INSERT INTO Manufacturers (Name) VALUES ('Nordica')");
            Sql("INSERT INTO Manufacturers (Name) VALUES ('Salomon')");
            Sql("DELETE FROM Manufacturers WHERE Id = 3");
            Sql("DELETE FROM Manufacturers WHERE Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
