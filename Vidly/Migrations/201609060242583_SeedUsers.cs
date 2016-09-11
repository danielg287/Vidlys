namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'0b9aaa69-48cb-4d48-971a-75cd6a4a7fce', N'admin@vidly.com', 0, N'ADG8SfMN/gK06uEu2Pabrj9uLxY3ISvh7XGf3t4ozqGjRHEtPEGyRppA1YmpPjOSlQ==', N'f39997ca-192c-4ad6-85e8-c9e4225e8937', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'6e1df546-5fed-476d-95e1-78f0c8ae39fe', N'guest@vidley.com', 0, N'AM9rHjL3gNVha22bV4fcDfiQovS//A+AUTeb2mmBSvw1qDotEe0Zmx7+24kFF1S6fA==', N'19083bfb-d87a-428a-bfcd-19753b513de8', NULL, 0, 0, NULL, 1, 0, N'guest@vidley.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'651b11e7-9eb6-4d41-9914-c75061839088', N'CanChangeMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'0b9aaa69-48cb-4d48-971a-75cd6a4a7fce', N'651b11e7-9eb6-4d41-9914-c75061839088')

");
        }
        
        public override void Down()
        {
        }
    }
}
