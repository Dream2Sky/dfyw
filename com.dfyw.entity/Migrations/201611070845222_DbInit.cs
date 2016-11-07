namespace com.dfyw.entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbInit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FollowRecords",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        InforId = c.Guid(nullable: false),
                        FollowId = c.Guid(nullable: false),
                        FollowValue = c.String(nullable: false, maxLength: 50, unicode: false, storeType: "nvarchar"),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Follows",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FollowItem = c.String(nullable: false, unicode: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Information",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        InserTime = c.String(maxLength: 30, unicode: false, storeType: "nvarchar"),
                        MemberId = c.Guid(nullable: false),
                        CustomerName = c.String(maxLength: 20, unicode: false, storeType: "nvarchar"),
                        Sex = c.String(maxLength: 4, unicode: false, storeType: "nvarchar"),
                        Age = c.String(maxLength: 3, unicode: false, storeType: "nvarchar"),
                        IsMarry = c.String(maxLength: 4, unicode: false, storeType: "nvarchar"),
                        Children = c.String(maxLength: 4, unicode: false, storeType: "nvarchar"),
                        Phone = c.String(maxLength: 20, unicode: false, storeType: "nvarchar"),
                        QQ = c.String(maxLength: 20, unicode: false, storeType: "nvarchar"),
                        WebCat = c.String(maxLength: 30, unicode: false, storeType: "nvarchar"),
                        Email = c.String(maxLength: 50, unicode: false, storeType: "nvarchar"),
                        Address = c.String(maxLength: 255, unicode: false, storeType: "nvarchar"),
                        Industry = c.String(maxLength: 30, unicode: false, storeType: "nvarchar"),
                        Occupation = c.String(maxLength: 30, unicode: false, storeType: "nvarchar"),
                        Income = c.String(maxLength: 20, unicode: false, storeType: "nvarchar"),
                        Hobby = c.String(maxLength: 30, unicode: false, storeType: "nvarchar"),
                        HasCar = c.String(maxLength: 4, unicode: false, storeType: "nvarchar"),
                        HasHouse = c.String(maxLength: 4, unicode: false, storeType: "nvarchar"),
                        Note1 = c.String(maxLength: 255, unicode: false, storeType: "nvarchar"),
                        Note2 = c.String(maxLength: 255, unicode: false, storeType: "nvarchar"),
                        Note3 = c.String(maxLength: 255, unicode: false, storeType: "nvarchar"),
                        Approval = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Account = c.String(nullable: false, maxLength: 24, unicode: false, storeType: "nvarchar"),
                        Password = c.String(nullable: false, maxLength: 50, unicode: false, storeType: "nvarchar"),
                        Role = c.Int(nullable: false),
                        ParentId = c.Guid(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Members");
            DropTable("dbo.Information");
            DropTable("dbo.Follows");
            DropTable("dbo.FollowRecords");
        }
    }
}
