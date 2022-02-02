namespace Code_First_Jashim.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _105 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookCategories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BooksID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Author = c.String(nullable: false),
                        Description = c.String(nullable: false, maxLength: 15),
                        AddedTime = c.DateTime(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        Availability = c.Boolean(),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.BooksID)
                .ForeignKey("dbo.BookCategories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.BookIssues",
                c => new
                    {
                        IssueID = c.Int(nullable: false, identity: true),
                        IssuedTime = c.DateTime(nullable: false),
                        Members_MemberID = c.Int(),
                        Books_BooksID = c.Int(),
                        Liberian_BooksID = c.Int(),
                        Books_BooksID1 = c.Int(),
                        Liberians_LiberianID = c.Int(),
                    })
                .PrimaryKey(t => t.IssueID)
                .ForeignKey("dbo.Members", t => t.Members_MemberID)
                .ForeignKey("dbo.Books", t => t.Books_BooksID)
                .ForeignKey("dbo.Books", t => t.Liberian_BooksID)
                .ForeignKey("dbo.Books", t => t.Books_BooksID1)
                .ForeignKey("dbo.Liberians", t => t.Liberians_LiberianID)
                .Index(t => t.Members_MemberID)
                .Index(t => t.Books_BooksID)
                .Index(t => t.Liberian_BooksID)
                .Index(t => t.Books_BooksID1)
                .Index(t => t.Liberians_LiberianID);
            
            CreateTable(
                "dbo.BookIssueLogs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IssuedTime = c.DateTime(nullable: false),
                        ReturnTime = c.DateTime(nullable: false),
                        MemberID = c.Int(),
                        IssueID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BookIssues", t => t.IssueID, cascadeDelete: true)
                .ForeignKey("dbo.Members", t => t.MemberID)
                .Index(t => t.MemberID)
                .Index(t => t.IssueID);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        MemberID = c.Int(nullable: false, identity: true),
                        MemberName = c.String(),
                        MemberStatus = c.String(),
                    })
                .PrimaryKey(t => t.MemberID);
            
            CreateTable(
                "dbo.FineRecords",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FineAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MemberID = c.Int(nullable: false),
                        StudentID = c.Int(nullable: false),
                        TeacherID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Members", t => t.MemberID, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherID, cascadeDelete: true)
                .Index(t => t.MemberID)
                .Index(t => t.StudentID)
                .Index(t => t.TeacherID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentID = c.Int(nullable: false, identity: true),
                        StudentName = c.String(),
                        Gender = c.String(),
                        Email = c.String(),
                        GroupID = c.Int(nullable: false),
                        Members_MemberID = c.Int(),
                    })
                .PrimaryKey(t => t.StudentID)
                .ForeignKey("dbo.StudentGroups", t => t.GroupID, cascadeDelete: true)
                .ForeignKey("dbo.Members", t => t.Members_MemberID)
                .Index(t => t.GroupID)
                .Index(t => t.Members_MemberID);
            
            CreateTable(
                "dbo.StudentGroups",
                c => new
                    {
                        GroupID = c.Int(nullable: false, identity: true),
                        GroupName = c.String(),
                    })
                .PrimaryKey(t => t.GroupID);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TeacherID = c.Int(nullable: false, identity: true),
                        TeacherName = c.String(),
                        Gender = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        Members_MemberID = c.Int(),
                    })
                .PrimaryKey(t => t.TeacherID)
                .ForeignKey("dbo.Members", t => t.Members_MemberID)
                .Index(t => t.Members_MemberID);
            
            CreateTable(
                "dbo.Liberians",
                c => new
                    {
                        LiberianID = c.Int(nullable: false, identity: true),
                        LiberianName = c.String(),
                        Age = c.Int(nullable: false),
                        Email = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.LiberianID);
            
            CreateTable(
                "dbo.ReservedBooks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AddedTime = c.DateTime(nullable: false),
                        NumberOfBooks = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BookCategories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.IdentityRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRoles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.IdentityRoles", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateStoredProcedure(
                "dbo.Liberians_Insert",
                p => new
                    {
                        LiberianName = p.String(),
                        Age = p.Int(),
                        Email = p.String(),
                        Address = p.String(),
                    },
                body:
                    @"INSERT [dbo].[Liberians]([LiberianName], [Age], [Email], [Address])
                      VALUES (@LiberianName, @Age, @Email, @Address)
                      
                      DECLARE @LiberianID int
                      SELECT @LiberianID = [LiberianID]
                      FROM [dbo].[Liberians]
                      WHERE @@ROWCOUNT > 0 AND [LiberianID] = scope_identity()
                      
                      SELECT t0.[LiberianID]
                      FROM [dbo].[Liberians] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[LiberianID] = @LiberianID"
            );
            
            CreateStoredProcedure(
                "dbo.Liberians_Update",
                p => new
                    {
                        LiberianID = p.Int(),
                        LiberianName = p.String(),
                        Age = p.Int(),
                        Email = p.String(),
                        Address = p.String(),
                    },
                body:
                    @"UPDATE [dbo].[Liberians]
                      SET [LiberianName] = @LiberianName, [Age] = @Age, [Email] = @Email, [Address] = @Address
                      WHERE ([LiberianID] = @LiberianID)"
            );
            
            CreateStoredProcedure(
                "dbo.Liberians_Delete",
                p => new
                    {
                        LiberianID = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Liberians]
                      WHERE ([LiberianID] = @LiberianID)"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.Liberians_Delete");
            DropStoredProcedure("dbo.Liberians_Update");
            DropStoredProcedure("dbo.Liberians_Insert");
            DropForeignKey("dbo.IdentityUserRoles", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserLogins", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserClaims", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserRoles", "IdentityRole_Id", "dbo.IdentityRoles");
            DropForeignKey("dbo.ReservedBooks", "CategoryID", "dbo.BookCategories");
            DropForeignKey("dbo.BookIssues", "Liberians_LiberianID", "dbo.Liberians");
            DropForeignKey("dbo.BookIssues", "Books_BooksID1", "dbo.Books");
            DropForeignKey("dbo.BookIssues", "Liberian_BooksID", "dbo.Books");
            DropForeignKey("dbo.BookIssues", "Books_BooksID", "dbo.Books");
            DropForeignKey("dbo.Teachers", "Members_MemberID", "dbo.Members");
            DropForeignKey("dbo.Students", "Members_MemberID", "dbo.Members");
            DropForeignKey("dbo.FineRecords", "TeacherID", "dbo.Teachers");
            DropForeignKey("dbo.Students", "GroupID", "dbo.StudentGroups");
            DropForeignKey("dbo.FineRecords", "StudentID", "dbo.Students");
            DropForeignKey("dbo.FineRecords", "MemberID", "dbo.Members");
            DropForeignKey("dbo.BookIssueLogs", "MemberID", "dbo.Members");
            DropForeignKey("dbo.BookIssues", "Members_MemberID", "dbo.Members");
            DropForeignKey("dbo.BookIssueLogs", "IssueID", "dbo.BookIssues");
            DropForeignKey("dbo.Books", "CategoryID", "dbo.BookCategories");
            DropIndex("dbo.IdentityUserLogins", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaims", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "IdentityRole_Id" });
            DropIndex("dbo.ReservedBooks", new[] { "CategoryID" });
            DropIndex("dbo.Teachers", new[] { "Members_MemberID" });
            DropIndex("dbo.Students", new[] { "Members_MemberID" });
            DropIndex("dbo.Students", new[] { "GroupID" });
            DropIndex("dbo.FineRecords", new[] { "TeacherID" });
            DropIndex("dbo.FineRecords", new[] { "StudentID" });
            DropIndex("dbo.FineRecords", new[] { "MemberID" });
            DropIndex("dbo.BookIssueLogs", new[] { "IssueID" });
            DropIndex("dbo.BookIssueLogs", new[] { "MemberID" });
            DropIndex("dbo.BookIssues", new[] { "Liberians_LiberianID" });
            DropIndex("dbo.BookIssues", new[] { "Books_BooksID1" });
            DropIndex("dbo.BookIssues", new[] { "Liberian_BooksID" });
            DropIndex("dbo.BookIssues", new[] { "Books_BooksID" });
            DropIndex("dbo.BookIssues", new[] { "Members_MemberID" });
            DropIndex("dbo.Books", new[] { "CategoryID" });
            DropTable("dbo.IdentityUserLogins");
            DropTable("dbo.IdentityUserClaims");
            DropTable("dbo.ApplicationUsers");
            DropTable("dbo.IdentityUserRoles");
            DropTable("dbo.IdentityRoles");
            DropTable("dbo.ReservedBooks");
            DropTable("dbo.Liberians");
            DropTable("dbo.Teachers");
            DropTable("dbo.StudentGroups");
            DropTable("dbo.Students");
            DropTable("dbo.FineRecords");
            DropTable("dbo.Members");
            DropTable("dbo.BookIssueLogs");
            DropTable("dbo.BookIssues");
            DropTable("dbo.Books");
            DropTable("dbo.BookCategories");
        }
    }
}
