namespace SportsEquipmentRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateEquipment : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Equipments (Manufacturer_Id, Kind, Description) VALUES (1, 'Electric bike', 'White, 9 gears')");
            Sql("INSERT INTO Equipments (Manufacturer_Id, Kind, Description) VALUES (2, 'Trekking bike', 'Model: SUB CROSS 40')");
        }
        
        public override void Down()
        {
        }
    }
}
