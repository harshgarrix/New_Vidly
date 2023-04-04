namespace New_Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'15032087-dffb-4288-a15c-eb446a834937', N'guest@vidly.com', 0, N'ABhJFL2xoW4t0/a46dhH7vF+MrvEXcc5xrR3gREbYHfJ822eyQA7lU+fJgc4tS65+A==', N'4581f6a8-acb8-451c-ad57-dfcb5b93b1d8', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'521c8ff3-7acb-4a91-9b13-175572282ae9', N'admin@vidly.com', 0, N'APR3elHzs0vNZZtRblda7qL0CreOeWSxyfix9PnAw8evHqx5iDBPWiHu3oXjN5Qfzw==', N'd08d668c-76c8-4628-9e49-9bc37e85011c', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'58a79178-18d8-4388-9420-eee0cc0fabf0', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'521c8ff3-7acb-4a91-9b13-175572282ae9', N'58a79178-18d8-4388-9420-eee0cc0fabf0')

");
        }
        
        public override void Down()
        {
        }
    }
}
