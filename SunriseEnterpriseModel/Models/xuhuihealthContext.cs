using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SunriseEnterpriseCommon;

namespace SunriseEnterpriseModel.Models
{
    public partial class xuhuihealthContext : DbContext
    {
        public xuhuihealthContext()
        {
        }

        public xuhuihealthContext(DbContextOptions<xuhuihealthContext> options)
            : base(options)
        {
        }


        public static xuhuihealthContext GetXuhuihealthContext
        {
            get
            {
                return new xuhuihealthContext();

            }
        }

        public virtual DbSet<About> About { get; set; }
        public virtual DbSet<Ad> Ad { get; set; }
        public virtual DbSet<Admininfo> Admininfo { get; set; }
        public virtual DbSet<Areas> Areas { get; set; }
        public virtual DbSet<Article> Article { get; set; }
        public virtual DbSet<Bascompany> Bascompany { get; set; }
        public virtual DbSet<China> China { get; set; }
        public virtual DbSet<Collaborateinfo> Collaborateinfo { get; set; }
        public virtual DbSet<Config> Config { get; set; }
        public virtual DbSet<Job> Job { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Productinfo> Productinfo { get; set; }
        public virtual DbSet<Productpic> Productpic { get; set; }
        public virtual DbSet<Producttypeinfo> Producttypeinfo { get; set; }
        public virtual DbSet<Programme> Programme { get; set; }
        public virtual DbSet<Zhanhuisignin> Zhanhuisignin { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                var Sqlstr = Appsettings.app("Sql", "str");
                var SqlType= Appsettings.app("Sql", "sqlType").ObjToInt();
                //// 主数据库  1=>sqlserver 2=>Oracle 3=>Mysql 4=>sqlite
                if (SqlType==1)
                {
                    optionsBuilder.UseSqlServer(Sqlstr);
                }
                if (SqlType == 2)
                {
                    optionsBuilder.UseOracle(Sqlstr);
                }
                if (SqlType == 3)
                {
                    optionsBuilder.UseMySql(Sqlstr);
                }
                if (SqlType == 4)
                {
                    optionsBuilder.UseSqlite(Sqlstr);
                }

               // optionsBuilder.UseMySql("server=192.168.1.242;port=3306;database=xuhuihealth;uid=root;pwd=root", x => x.ServerVersion("10.1.9-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<About>(entity =>
            {
                entity.ToTable("about");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)")
                    .HasComment("关于我们页面数据");

                entity.Property(e => e.AddTime)
                    .HasColumnType("datetime")
                    .HasComment("添加时间");

                entity.Property(e => e.Content)
                    .HasColumnType("text")
                    .HasComment("正文")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ImgUrl)
                    .HasColumnType("varchar(1000)")
                    .HasComment("图片")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Mcontent)
                    .HasColumnName("MContent")
                    .HasColumnType("text")
                    .HasComment("手机端内容")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Sort)
                    .HasColumnType("int(11)")
                    .HasComment("排序");

                entity.Property(e => e.Subheading)
                    .HasColumnType("varchar(255)")
                    .HasComment("副标题")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Title)
                    .HasColumnType("varchar(255)")
                    .HasComment("标题")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Type)
                    .HasColumnType("int(11)")
                    .HasComment("分组");
            });

            modelBuilder.Entity<Ad>(entity =>
            {
                entity.ToTable("ad");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.Comid).HasColumnType("int(11)");

                entity.Property(e => e.Display)
                    .HasColumnType("varchar(255)")
                    .HasComment("是否前台显示")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.LinkUrl)
                    .HasColumnType("varchar(255)")
                    .HasComment("链接指向地址")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PicUrl)
                    .HasColumnType("varchar(255)")
                    .HasComment("图片地址")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PosId)
                    .HasColumnName("PosID")
                    .HasColumnType("int(11)")
                    .HasComment("位置，对应枚举");

                entity.Property(e => e.Remark)
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Title)
                    .HasColumnType("varchar(255)")
                    .HasComment("标题，可选")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Admininfo>(entity =>
            {
                entity.ToTable("admininfo");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AdminName)
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Comid)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Password)
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Remark)
                    .HasColumnType("longtext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Role)
                    .HasColumnType("longtext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Areas>(entity =>
            {
                entity.ToTable("areas");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CityId)
                    .HasColumnName("CityID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProvinceId)
                    .HasColumnName("ProvinceID")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Article>(entity =>
            {
                entity.ToTable("article");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.Comid).HasColumnType("int(11)");

                entity.Property(e => e.Content)
                    .HasColumnType("longtext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Title)
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Type).HasColumnType("int(11)");

                entity.Property(e => e.ViewNum).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Bascompany>(entity =>
            {
                entity.ToTable("bascompany");

                entity.Property(e => e.Id).HasColumnType("int(4)");

                entity.Property(e => e.Address)
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ComInfo)
                    .HasColumnType("varchar(2000)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ComMemo)
                    .HasColumnType("varchar(2000)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ComName)
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<China>(entity =>
            {
                entity.ToTable("china");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CityId)
                    .IsRequired()
                    .HasColumnName("CityID")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProvinceId)
                    .IsRequired()
                    .HasColumnName("ProvinceID")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Collaborateinfo>(entity =>
            {
                entity.ToTable("collaborateinfo");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AddTime)
                    .HasColumnType("datetime")
                    .HasComment("添加时间");

                entity.Property(e => e.CollaborateName)
                    .HasColumnType("varchar(255)")
                    .HasComment("合作方名字")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Display)
                    .HasColumnType("varchar(255)")
                    .HasComment("是否显示")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.GoliveTime)
                    .HasColumnName("goliveTime")
                    .HasColumnType("varchar(255)")
                    .HasComment("上线时间")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.HomePageDisplay)
                    .HasColumnType("varchar(255)")
                    .HasComment("是否首页显示  (如果display不显示的，首页也不显示)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.PicUrl)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.ProductTypeId)
                    .HasColumnName("productTypeID")
                    .HasColumnType("int(11)")
                    .HasComment("产品类别ID");

                entity.Property(e => e.Quantity)
                    .HasColumnType("varchar(11)")
                    .HasComment("数量(手机端显示）")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.SearcText)
                    .HasColumnType("text")
                    .HasComment("索引内容")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.SelfHelpFunc)
                    .HasColumnType("varchar(255)")
                    .HasComment("自助功能(手机端显示)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.ShowTime)
                    .HasColumnType("datetime")
                    .HasComment("显示时间");
            });

            modelBuilder.Entity<Config>(entity =>
            {
                entity.ToTable("config");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Comid).HasColumnType("int(11)");

                entity.Property(e => e.ConfigId)
                    .HasColumnName("ConfigID")
                    .HasColumnType("int(255)");

                entity.Property(e => e.ConfigName)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ConfigValue)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Remark)
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.ToTable("job");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.Comid)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Content1)
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Content2)
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Content3)
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Display)
                    .HasColumnType("varchar(255)")
                    .HasComment("是否前台显示")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Title)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.ToTable("news");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.CategoryId)
                    .HasColumnName("CategoryID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ComeFrom)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Comid)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Content)
                    .HasColumnType("longtext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ContentIndex)
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Describes)
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Display)
                    .HasColumnType("varchar(255)")
                    .HasComment("是否前台显示")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.MobileContent)
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.MobileDes)
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.MobileRange)
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PicIndex)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProModel)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProRange)
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProSize)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ShowTime).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Type).HasColumnType("int(11)");

                entity.Property(e => e.ViewNum).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Productinfo>(entity =>
            {
                entity.ToTable("productinfo");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Addtime)
                    .HasColumnType("datetime")
                    .HasComment("添加时间");

                entity.Property(e => e.CoversPicInPhone)
                    .HasColumnType("varchar(255)")
                    .HasComment("手机端封面图片")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Display)
                    .HasColumnType("varchar(255)")
                    .HasComment("显示")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.HomePageDisplay)
                    .HasColumnType("varchar(255)")
                    .HasComment("首页是否显示 1:显示")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.ProductContent)
                    .HasColumnName("productContent")
                    .HasColumnType("longtext")
                    .HasComment("产品描述")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.ProductContentInPhone)
                    .HasColumnName("productContentInPhone")
                    .HasColumnType("longtext")
                    .HasComment("产品描述(手机端)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.ProductDes)
                    .HasColumnName("productDes")
                    .HasColumnType("longtext")
                    .HasComment("产品规格")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.ProductDesInPhone)
                    .HasColumnName("productDesInPhone")
                    .HasColumnType("longtext")
                    .HasComment("产品规格(手机端)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.ProductModel)
                    .HasColumnName("productModel")
                    .HasColumnType("varchar(255)")
                    .HasComment("产品型号")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.ProductName)
                    .HasColumnName("productName")
                    .HasColumnType("varchar(255)")
                    .HasComment("产品名字")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.ProductRange)
                    .HasColumnName("productRange")
                    .HasColumnType("longtext")
                    .HasComment("适用范围")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.ProductRangeInPhone)
                    .HasColumnName("productRangeInPhone")
                    .HasColumnType("longtext")
                    .HasComment("适用范围(手机端)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.ProductSize)
                    .HasColumnName("productSize")
                    .HasColumnType("varchar(255)")
                    .HasComment("产品尺寸")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.ProductTypeId)
                    .HasColumnName("productTypeID")
                    .HasColumnType("varchar(255)")
                    .HasComment("产品类别")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Productkind)
                    .HasColumnName("productkind")
                    .HasColumnType("varchar(255)")
                    .HasComment("设备类型(柜式/立式)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Productpic)
                    .HasColumnName("productpic")
                    .HasColumnType("varchar(255)")
                    .HasComment("图片URL")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.SearchText)
                    .HasColumnName("searchText")
                    .HasColumnType("varchar(255)")
                    .HasComment("查询内容")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.ShowTime)
                    .HasColumnType("datetime")
                    .HasComment("显示时间");

                entity.Property(e => e.ViewNum)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("点击次数");
            });

            modelBuilder.Entity<Productpic>(entity =>
            {
                entity.ToTable("productpic");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Pic)
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("'0'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProId)
                    .HasColumnName("ProID")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ShowIndex)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<Producttypeinfo>(entity =>
            {
                entity.ToTable("producttypeinfo");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AbbrName)
                    .HasColumnName("abbrName")
                    .HasColumnType("varchar(255)")
                    .HasComment("缩写分类名")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.AddTime)
                    .HasColumnType("datetime")
                    .HasComment("添加时间");

                entity.Property(e => e.Content)
                    .HasColumnType("text")
                    .HasComment("产品简介")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("varchar(255)")
                    .HasComment("meta描述")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Display)
                    .HasColumnType("varchar(255)")
                    .HasComment("前台是否显示")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Keywords)
                    .HasColumnName("keywords")
                    .HasColumnType("varchar(255)")
                    .HasComment("meta关键字")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.ShowTime)
                    .HasColumnType("datetime")
                    .HasComment("显示时间");

                entity.Property(e => e.SortId)
                    .HasColumnName("SortID")
                    .HasColumnType("int(255)")
                    .HasComment("顺序");

                entity.Property(e => e.TypeName)
                    .HasColumnType("varchar(255)")
                    .HasComment("产品分类名")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<Programme>(entity =>
            {
                entity.ToTable("programme");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)")
                    .HasComment("ID解决方案表");

                entity.Property(e => e.AddTime)
                    .HasColumnType("datetime")
                    .HasComment("添加时间");

                entity.Property(e => e.Content)
                    .HasColumnType("text")
                    .HasComment("内容")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ContentImgUrl)
                    .HasColumnType("varchar(1000)")
                    .HasComment("内容页图片")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DetailContent)
                    .HasColumnType("longtext")
                    .HasComment("详情内容")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Display)
                    .HasColumnType("varchar(255)")
                    .HasComment("是否首页显示")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ImgUrl)
                    .HasColumnType("varchar(1000)")
                    .HasComment("图片地址")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PosId)
                    .HasColumnName("PosID")
                    .HasColumnType("int(11)")
                    .HasComment("分类");

                entity.Property(e => e.SortId)
                    .HasColumnName("SortID")
                    .HasColumnType("int(11)")
                    .HasComment("排序");

                entity.Property(e => e.Subheading)
                    .HasColumnType("varchar(255)")
                    .HasComment("副标题")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Title)
                    .HasColumnType("varchar(255)")
                    .HasComment("标题")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Url)
                    .HasColumnType("varchar(1000)")
                    .HasComment("链接")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Zhanhuisignin>(entity =>
            {
                entity.ToTable("zhanhuisignin");

                entity.HasComment("展会签到");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.CorpName)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ExhibitionType)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Mobile)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.OpenId)
                    .HasColumnName("OpenID")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UserName)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
