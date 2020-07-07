namespace SportsEquipmentRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteSecondTry : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM Equipments WHERE InStock=2;");
        }
        
        public override void Down()
        {
        }
    }
}
