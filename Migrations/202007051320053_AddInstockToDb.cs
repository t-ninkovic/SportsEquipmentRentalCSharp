namespace SportsEquipmentRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInstockToDb : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Equipments SET InStock = 3 WHERE Id = 1");
            Sql("UPDATE Equipments SET InStock = 2 WHERE Id = 2");
        }
        
        public override void Down()
        {
        }
    }
}
