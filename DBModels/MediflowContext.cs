using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Mediflow.DBModels
{
    public partial class MediflowContext : DbContext
    {
        public MediflowContext()
        {
        }

        public MediflowContext(DbContextOptions<MediflowContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ARegister> ARegister { get; set; }
        public virtual DbSet<BookMarkProductsChemist> BookMarkProductsChemist { get; set; }
        public virtual DbSet<CRegister> CRegister { get; set; }
        public virtual DbSet<NotifyChemist> NotifyChemist { get; set; }
        public virtual DbSet<OrderCartDetails> OrderCartDetails { get; set; }
        public virtual DbSet<OrderDeliveryDetails> OrderDeliveryDetails { get; set; }
        public virtual DbSet<OrderMaster> OrderMaster { get; set; }
        public virtual DbSet<OrderTransaction> OrderTransaction { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<RateOrder> RateOrder { get; set; }
        public virtual DbSet<ReturnItem> ReturnItem { get; set; }
        public virtual DbSet<ReturnMaster> ReturnMaster { get; set; }
        public virtual DbSet<StockMaster> StockMaster { get; set; }
        public virtual DbSet<SPCartDetails> SPCartDetails { get; set; }

        public virtual DbSet<FetchOrders> FetchOrders { get; set; }
        public virtual DbSet<OrderItemsDetails> OrderItemsDetails { get; set; }

        public virtual DbSet<SpGetInstantReturn> SpGetInstantReturn { get; set; }
        public virtual DbSet<SpReturnInvoice> SpReturnInvoice { get; set; }
        public virtual DbSet<SPGetReturn> SPGetReturn { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=NEGAN\\SQLEXPRESS;Initial Catalog=Mediflow;User ID=sa;Password=admin@123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ARegister>(entity =>
            {
                entity.ToTable("a_register");

                entity.Property(e => e.AdminName)
                    .HasColumnName("admin_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AdminPwd)
                    .HasColumnName("admin_pwd")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BookMarkProductsChemist>(entity =>
            {
                entity.HasKey(e => e.BookmarkId)
                    .HasName("PK__BookMark__6869B5C8B55749E3");

                entity.ToTable("BookMark_Products_Chemist");

                entity.Property(e => e.BookmarkId).HasColumnName("Bookmark_Id");

                entity.Property(e => e.BookedItemId).HasColumnName("BookedItem_Id");

                entity.Property(e => e.ChemistId).HasColumnName("Chemist_Id");
            });

            modelBuilder.Entity<CRegister>(entity =>
            {
                entity.ToTable("c_register");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DocumentImg).HasColumnName("documentImg");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fname)
                    .HasColumnName("fname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.GstNo)
                    .HasColumnName("gstNo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsCredit).HasColumnName("isCredit");

                entity.Property(e => e.Lname)
                    .HasColumnName("lname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Mobile)
                    .HasColumnName("mobile")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Rdlno)
                    .HasColumnName("rdlno")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ShopName)
                    .HasColumnName("shopName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Zcode)
                    .HasColumnName("zcode")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<NotifyChemist>(entity =>
            {
                entity.HasKey(e => e.NotifyCid);

                entity.ToTable("Notify_Chemist");

                entity.Property(e => e.NotifyCid).HasColumnName("Notify_CId");

                entity.Property(e => e.ChemistId).HasColumnName("Chemist_Id");

                entity.Property(e => e.NotifyIsRead).HasColumnName("Notify_isRead");

                entity.Property(e => e.NotifyMsg)
                    .HasColumnName("Notify_Msg")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.NotifyType)
                    .HasColumnName("Notify_Type")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateTime)
                    .HasColumnName("Update_Time")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<OrderCartDetails>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__tmp_ms_x__F1E4607BD3C11644");

                entity.Property(e => e.OrderId).HasColumnName("Order_Id");

                entity.Property(e => e.ChemistId).HasColumnName("Chemist_Id");

                entity.Property(e => e.ItemId).HasColumnName("Item_Id");

                entity.Property(e => e.ItemQty).HasColumnName("Item_Qty");
            });

            modelBuilder.Entity<OrderDeliveryDetails>(entity =>
            {
                entity.HasKey(e => e.DeliveryId)
                    .HasName("PK__tmp_ms_x__AA55A03949B9DA8A");

                entity.Property(e => e.DeliveryId).HasColumnName("Delivery_Id");

                entity.Property(e => e.ChemistId).HasColumnName("Chemist_Id");

                entity.Property(e => e.EmailChemist)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FinalOrderId).HasColumnName("FinalOrder_Id");

                entity.Property(e => e.ShopAddress)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ShopName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telephone)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OrderMaster>(entity =>
            {
                entity.HasKey(e => e.FinalOrderId);

                entity.Property(e => e.FinalOrderId).HasColumnName("FinalOrder_Id");

                entity.Property(e => e.ChemistId).HasColumnName("Chemist_Id");

                entity.Property(e => e.DeliveryDate)
                    .HasColumnName("deliveryDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeliveryStatusUpdate)
                    .HasColumnName("deliveryStatusUpdate")
                    .HasColumnType("date");

                entity.Property(e => e.DeliveryType)
                    .HasColumnName("deliveryType")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Discount).HasColumnName("discount");

                entity.Property(e => e.FinalPayable).HasColumnName("finalPayable");

                entity.Property(e => e.GstCharges).HasColumnName("gstCharges");

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsCredit).HasColumnName("isCredit");

                entity.Property(e => e.OrderDate)
                    .HasColumnName("orderDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.OrderStatus)
                    .HasColumnName("orderStatus")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ValuePrice).HasColumnName("valuePrice");
            });

            modelBuilder.Entity<OrderTransaction>(entity =>
            {
                entity.HasKey(e => e.OrderDetailId)
                    .HasName("PK__tmp_ms_x__53D880807F65241A");

                entity.Property(e => e.OrderDetailId).HasColumnName("OrderDetail_Id");

                entity.Property(e => e.ChemistId).HasColumnName("Chemist_Id");

                entity.Property(e => e.FinalOrderId).HasColumnName("FinalOrder_Id");

                entity.Property(e => e.ItemQty).HasColumnName("Item_Qty");

                entity.Property(e => e.ObatchNo)
                    .HasColumnName("OBatch_No")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OexpiryDt)
                    .HasColumnName("OExpiry_Dt")
                    .HasColumnType("date");

                entity.Property(e => e.OitemId).HasColumnName("OItem_Id");

                entity.Property(e => e.OitemReturnStatus).HasColumnName("OItemReturn_Status");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.ItemId)
                    .HasName("PK__tmp_ms_x__3FB50874A9148767");

                entity.Property(e => e.ItemId).HasColumnName("Item_Id");

                entity.Property(e => e.Content).IsUnicode(false);

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.GstPercent).HasColumnName("gstPercent");

                entity.Property(e => e.ItemName)
                    .HasColumnName("Item_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MarginPercent).HasColumnName("marginPercent");

                entity.Property(e => e.MarketByName)
                    .HasColumnName("Market_by_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MedicineType)
                    .HasColumnName("Medicine_Type")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MfgByName)
                    .HasColumnName("Mfg_by_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductCategory)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Unit)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Volume)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RateOrder>(entity =>
            {
                entity.HasKey(e => e.RatingId)
                    .HasName("PK__RateOrde__BE48C84529730309");

                entity.Property(e => e.RatingId).HasColumnName("Rating_Id");

                entity.Property(e => e.RCid).HasColumnName("R_Cid");

                entity.Property(e => e.RForderId).HasColumnName("R_FOrder_Id");

                entity.Property(e => e.RMsg)
                    .HasColumnName("R_Msg")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RType)
                    .HasColumnName("R_type")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ReturnItem>(entity =>
            {
                entity.HasKey(e => e.ReturnId)
                    .HasName("PK__tmp_ms_x__0F4F4C36046B0158");

                entity.Property(e => e.ReturnId).HasColumnName("Return_Id");

                entity.Property(e => e.RIstypeExpiry).HasColumnName("R_istypeExpiry");

                entity.Property(e => e.RbatchNo)
                    .HasColumnName("Rbatch_no")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RchemistId).HasColumnName("RChemist_id");

                entity.Property(e => e.RfinalOrderId).HasColumnName("RFinalOrder_Id");

                entity.Property(e => e.RinitiateDate)
                    .HasColumnName("Rinitiate_date")
                    .HasColumnType("date");

                entity.Property(e => e.RitemExpiry)
                    .HasColumnName("Ritem_expiry")
                    .HasColumnType("date");

                entity.Property(e => e.RitemId).HasColumnName("Ritem_id");

                entity.Property(e => e.RitemQty).HasColumnName("Ritem_qty");

                entity.Property(e => e.RmId).HasColumnName("RM_Id");

                entity.Property(e => e.RpaymentType)
                    .HasColumnName("Rpayment_type")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ReturnMaster>(entity =>
            {
                entity.HasKey(e => e.RmasterId)
                    .HasName("PK__tmp_ms_x__3C9A6498E6F5AFB9");

                entity.Property(e => e.RmasterId).HasColumnName("RMaster_Id");

                entity.Property(e => e.RmCid).HasColumnName("RM_Cid");

                entity.Property(e => e.RmDate)
                    .HasColumnName("RM_date")
                    .HasColumnType("date");

                entity.Property(e => e.RmFinalOrderId).HasColumnName("RM_finalOrder_Id");

                entity.Property(e => e.RmFinalPayable).HasColumnName("RM_finalPayable");

                entity.Property(e => e.RmGstCharge).HasColumnName("RM_gstCharge");

                entity.Property(e => e.RmIsNewRecord).HasColumnName("RM_isNewRecord");

                entity.Property(e => e.RmIstypeExpiry).HasColumnName("RM_istypeExpiry");

                entity.Property(e => e.RmValuePrice).HasColumnName("RM_valuePrice");
            });

            modelBuilder.Entity<StockMaster>(entity =>
            {
                entity.HasKey(e => e.StockId)
                    .HasName("PK__tmp_ms_x__EFA64E980ABCEEF7");

                entity.Property(e => e.StockId).HasColumnName("Stock_Id");

                entity.Property(e => e.AddedDt)
                    .HasColumnName("Added_Dt")
                    .HasColumnType("date");

                entity.Property(e => e.BatchNo)
                    .HasColumnName("Batch_No")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ExpiryDt)
                    .HasColumnName("Expiry_Dt")
                    .HasColumnType("date");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.SitemId).HasColumnName("SItem_Id");

                entity.Property(e => e.StockQty).HasColumnName("Stock_Qty");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
