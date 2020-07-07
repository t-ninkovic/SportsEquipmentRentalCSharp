namespace SportsEquipmentRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateManufacturers : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Manufacturers (Name) VALUES ('E-Prime')");
            Sql("INSERT INTO Manufacturers (Name) VALUES ('Scott')");
        }
        
        public override void Down()
        {
        }
    }
}
