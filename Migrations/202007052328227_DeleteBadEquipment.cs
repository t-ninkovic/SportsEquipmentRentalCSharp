namespace SportsEquipmentRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteBadEquipment : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM Equipments WHERE Id=1");
        }
        
        public override void Down()
        {
        }
    }
}
