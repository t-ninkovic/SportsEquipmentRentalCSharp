namespace SportsEquipmentRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'5946b3f7-649e-4d43-b7ad-234b0180729a', N'admin@mail.com', 0, N'AOwOoZtn7/bXdO/Dg33EDKQvH1x73ih9xxXAsOpDDMyX649FNgF8D4qhdyQGyQrRLw==', N'3f999ec8-3c8a-46ca-b05d-c5540437a3ac', NULL, 0, 0, NULL, 1, 0, N'admin@mail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'852cba02-a1aa-4189-8f55-9686160ddbf4', N'guest@mail.com', 0, N'ANuw+F9ORytMp56+MNMGiovJYD4q/OqJLoKQ9xb1FZWy9FycIgk1MiiWka31amrsIw==', N'64a0b796-a67a-430e-8903-233d636972bf', NULL, 0, 0, NULL, 1, 0, N'guest@mail.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'45a2b2ef-1eab-4276-b145-202a2b3b4263', N'AdminRole')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'5946b3f7-649e-4d43-b7ad-234b0180729a', N'45a2b2ef-1eab-4276-b145-202a2b3b4263')

");
        }
        
        public override void Down()
        {
        }
    }
}
