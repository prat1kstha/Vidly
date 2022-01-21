namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedRoles : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'0ac04149-faa7-4b1e-875e-c7a960ddfd6e', N'admin@vidly.com', 0, N'AN5M9V0qBIiLbE6MnsFbMDKQqxGsSiUPy8NBnMBwlCXFDG2YuhhQdRgEmD9HuE4f9g==', N'faeddea0-8fa1-4928-b4ce-038231a38983', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ab589f19-3590-4550-9d43-2a50a0cc8374', N'guest@vidly.com', 0, N'AP36U/A2SeQy7Eo2A0hQL8lsiIXIfCJ8IhQEF6clxJ4nkWnX1umD7GeT3Hm/I92xFA==', N'0c3bc8bd-6777-418c-8d59-8d47289a5236', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

                INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'20c31be2-c16e-4cf9-bec7-337157ea9819', N'CanManageMovies')

                INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'0ac04149-faa7-4b1e-875e-c7a960ddfd6e', N'20c31be2-c16e-4cf9-bec7-337157ea9819')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
