using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MIcroinvestIO.Micro;

public partial class MultiContext : DbContext
{
    public MultiContext()
    {
    }

    public MultiContext(DbContextOptions<MultiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ApplicationLog> ApplicationLogs { get; set; }

    public virtual DbSet<CashBook> CashBooks { get; set; }

    public virtual DbSet<Configuration> Configurations { get; set; }

    public virtual DbSet<CurrenciesHistory> CurrenciesHistories { get; set; }

    public virtual DbSet<Currency> Currencies { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<Ecrreceipt> Ecrreceipts { get; set; }

    public virtual DbSet<FitnessAddIn> FitnessAddIns { get; set; }

    public virtual DbSet<FitnessCard> FitnessCards { get; set; }

    public virtual DbSet<FitnessDailyReport> FitnessDailyReports { get; set; }

    public virtual DbSet<FitnessDuration> FitnessDurations { get; set; }

    public virtual DbSet<FitnessEventLog> FitnessEventLogs { get; set; }

    public virtual DbSet<FitnessInstructorIn> FitnessInstructorIns { get; set; }

    public virtual DbSet<FitnessPhoto> FitnessPhotos { get; set; }

    public virtual DbSet<FitnessPlan> FitnessPlans { get; set; }

    public virtual DbSet<FitnessPlanTiming> FitnessPlanTimings { get; set; }

    public virtual DbSet<FitnessService> FitnessServices { get; set; }

    public virtual DbSet<FitnessStaff> FitnessStaffs { get; set; }

    public virtual DbSet<FitnessSystem> FitnessSystems { get; set; }

    public virtual DbSet<FitnessTiming> FitnessTimings { get; set; }

    public virtual DbSet<FitnessVisit> FitnessVisits { get; set; }

    public virtual DbSet<FitnessVisitAccaunt> FitnessVisitAccaunts { get; set; }

    public virtual DbSet<FitnessVisitCard> FitnessVisitCards { get; set; }

    public virtual DbSet<Good> Goods { get; set; }

    public virtual DbSet<GoodsGroup> GoodsGroups { get; set; }

    public virtual DbSet<InternalLog> InternalLogs { get; set; }

    public virtual DbSet<Lot> Lots { get; set; }

    public virtual DbSet<Network> Networks { get; set; }

    public virtual DbSet<NextAcct> NextAccts { get; set; }

    public virtual DbSet<Object> Objects { get; set; }

    public virtual DbSet<ObjectsGroup> ObjectsGroups { get; set; }

    public virtual DbSet<Operation> Operations { get; set; }

    public virtual DbSet<OperationType> OperationTypes { get; set; }

    public virtual DbSet<Partner> Partners { get; set; }

    public virtual DbSet<PartnersGroup> PartnersGroups { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<PaymentType> PaymentTypes { get; set; }

    public virtual DbSet<PriceRule> PriceRules { get; set; }

    public virtual DbSet<Registration> Registrations { get; set; }

    public virtual DbSet<Store> Stores { get; set; }

    public virtual DbSet<System> Systems { get; set; }

    public virtual DbSet<Transformation> Transformations { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UsersGroup> UsersGroups { get; set; }

    public virtual DbSet<UsersSecurity> UsersSecurities { get; set; }

    public virtual DbSet<Vatgroup> Vatgroups { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ApplicationLog>(entity =>
        {
            entity.ToTable("ApplicationLog");

            entity.HasIndex(e => e.UserId, "IX_ApplicationLog");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Message).HasMaxLength(255);
            entity.Property(e => e.MessageSource).HasMaxLength(50);
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.UserRealtime).HasColumnType("datetime");
        });

        modelBuilder.Entity<CashBook>(entity =>
        {
            entity.ToTable("CashBook");

            entity.HasIndex(e => new { e.UserId, e.ObjectId }, "IX_CashBook");

            entity.HasIndex(e => e.Date, "IX_CashBook_Date");

            entity.HasIndex(e => e.OperType, "IX_CashBook_Opertype");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Date).HasColumnType("smalldatetime");
            entity.Property(e => e.Desc).HasMaxLength(255);
            entity.Property(e => e.ObjectId).HasColumnName("ObjectID");
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.UserRealtime).HasColumnType("datetime");
        });

        modelBuilder.Entity<Configuration>(entity =>
        {
            entity.ToTable("Configuration");

            entity.HasIndex(e => new { e.Key, e.UserId }, "IX_Configuration");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Key).HasMaxLength(50);
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Value).HasMaxLength(50);
        });

        modelBuilder.Entity<CurrenciesHistory>(entity =>
        {
            entity.ToTable("CurrenciesHistory");

            entity.HasIndex(e => new { e.CurrencyId, e.UserId }, "IX_CurrenciesHistory");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CurrencyId).HasColumnName("CurrencyID");
            entity.Property(e => e.Date).HasColumnType("smalldatetime");
            entity.Property(e => e.UserId).HasColumnName("UserID");
        });

        modelBuilder.Entity<Currency>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Currency1)
                .HasMaxLength(3)
                .HasColumnName("Currency");
            entity.Property(e => e.Description).HasMaxLength(255);
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasIndex(e => e.Acct, "IX_Documents_Acct");

            entity.HasIndex(e => e.InvoiceDate, "IX_Documents_InvoiceDate");

            entity.HasIndex(e => e.InvoiceNumber, "IX_Documents_InvoiceNumber");

            entity.HasIndex(e => e.OperType, "IX_Documents_Opertype");

            entity.HasIndex(e => e.Recipient, "IX_Documents_Recepient");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Egn)
                .HasMaxLength(50)
                .HasColumnName("EGN");
            entity.Property(e => e.ExternalInvoiceDate).HasColumnType("smalldatetime");
            entity.Property(e => e.ExternalInvoiceNumber).HasMaxLength(255);
            entity.Property(e => e.InvoiceDate).HasColumnType("smalldatetime");
            entity.Property(e => e.InvoiceNumber).HasMaxLength(255);
            entity.Property(e => e.Place).HasMaxLength(255);
            entity.Property(e => e.Provider).HasMaxLength(255);
            entity.Property(e => e.Reason).HasMaxLength(255);
            entity.Property(e => e.Recipient).HasMaxLength(255);
            entity.Property(e => e.TaxDate).HasColumnType("smalldatetime");
        });

        modelBuilder.Entity<Ecrreceipt>(entity =>
        {
            entity.ToTable("ECRReceipts");

            entity.HasIndex(e => e.Ecrid, "IX_ECRReceipts_ECRID");

            entity.HasIndex(e => e.OperType, "IX_ECRReceipts_Opertype");

            entity.HasIndex(e => e.ReceiptId, "IX_ECRReceipts_ReceiptID");

            entity.HasIndex(e => e.ReceiptType, "IX_ECRReceipts_ReceiptType");

            entity.HasIndex(e => e.UserId, "IX_ECRReceipts_UserID");

            entity.HasIndex(e => e.Acct, "IX_ECRReceipts_acct");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Ecrid)
                .HasMaxLength(255)
                .HasColumnName("ECRID");
            entity.Property(e => e.ReceiptDate).HasColumnType("datetime");
            entity.Property(e => e.ReceiptId).HasColumnName("ReceiptID");
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.UserRealTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<FitnessAddIn>(entity =>
        {
            entity.Property(e => e.FitnessAddInId).HasColumnName("FitnessAddInID");
            entity.Property(e => e.ActiveUserId)
                .HasDefaultValue(1)
                .HasColumnName("ActiveUserID");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            entity.Property(e => e.VisitCardsId)
                .HasDefaultValue(1)
                .HasColumnName("VisitCardsID");

            entity.HasOne(d => d.VisitCards).WithMany(p => p.FitnessAddIns)
                .HasForeignKey(d => d.VisitCardsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FitnessAddIns_VisitCardsID");
        });

        modelBuilder.Entity<FitnessCard>(entity =>
        {
            entity.Property(e => e.FitnessCardId).HasColumnName("FitnessCardID");
            entity.Property(e => e.CurrentPosition).HasDefaultValue(2);
            entity.Property(e => e.EnterTime).HasColumnType("datetime");
            entity.Property(e => e.FitnessPlanId).HasColumnName("FitnessPlanID");
            entity.Property(e => e.HumanName).HasMaxLength(50);
            entity.Property(e => e.InternalNumber).HasMaxLength(50);
            entity.Property(e => e.UserId).HasColumnName("UserID");
        });

        modelBuilder.Entity<FitnessDailyReport>(entity =>
        {
            entity.ToTable("FitnessDailyReport");

            entity.Property(e => e.FitnessDailyReportId).HasColumnName("FitnessDailyReportID");
            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.StartTime).HasColumnType("datetime");
            entity.Property(e => e.Total).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.UserRealTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<FitnessDuration>(entity =>
        {
            entity.HasKey(e => e.FitnessDurationId).HasName("PK_FitnessDuration");

            entity.Property(e => e.FitnessDurationId).HasColumnName("FitnessDurationID");
        });

        modelBuilder.Entity<FitnessEventLog>(entity =>
        {
            entity.HasKey(e => e.FitnessEventId);

            entity.ToTable("FitnessEventLog");

            entity.Property(e => e.FitnessEventId).HasColumnName("FitnessEventID");
            entity.Property(e => e.DateTime).HasColumnType("datetime");
            entity.Property(e => e.FitnessCardId).HasColumnName("FitnessCardID");
            entity.Property(e => e.FitnessVisitCardId).HasColumnName("FitnessVisitCardID");
            entity.Property(e => e.ObjectId).HasColumnName("ObjectID");

            entity.HasOne(d => d.FitnessCard).WithMany(p => p.FitnessEventLogs)
                .HasForeignKey(d => d.FitnessCardId)
                .HasConstraintName("FK_FitnessEventLog_FitnessCards");
        });

        modelBuilder.Entity<FitnessInstructorIn>(entity =>
        {
            entity.HasKey(e => e.FitnessInstructorInsId);

            entity.Property(e => e.FitnessInstructorInsId).HasColumnName("FitnessInstructorInsID");
            entity.Property(e => e.ActiveUserId).HasColumnName("ActiveUserID");
            entity.Property(e => e.InstructorId).HasColumnName("InstructorID");
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            entity.Property(e => e.VisitCardsId).HasColumnName("VisitCardsID");

            entity.HasOne(d => d.VisitCards).WithMany(p => p.FitnessInstructorIns)
                .HasForeignKey(d => d.VisitCardsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FitnessInstructorIns_VisitCardsID");
        });

        modelBuilder.Entity<FitnessPhoto>(entity =>
        {
            entity.Property(e => e.FitnessPhotoId).HasColumnName("FitnessPhotoID");
            entity.Property(e => e.ImageData).HasColumnType("image");
            entity.Property(e => e.PartnerId).HasColumnName("PartnerID");
        });

        modelBuilder.Entity<FitnessPlan>(entity =>
        {
            entity.Property(e => e.FitnessPlanId).HasColumnName("FitnessPlanID");
            entity.Property(e => e.PlanName)
                .HasMaxLength(50)
                .HasDefaultValue("");
        });

        modelBuilder.Entity<FitnessPlanTiming>(entity =>
        {
            entity.Property(e => e.FitnessPlanTimingId).HasColumnName("FitnessPlanTimingID");
            entity.Property(e => e.FitnessPlanId).HasColumnName("FitnessPlanID");
            entity.Property(e => e.FitnessTimingId).HasColumnName("FitnessTimingID");

            entity.HasOne(d => d.FitnessPlan).WithMany(p => p.FitnessPlanTimings)
                .HasForeignKey(d => d.FitnessPlanId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FitnessPlanTimings_FitnessPlans");
        });

        modelBuilder.Entity<FitnessService>(entity =>
        {
            entity.Property(e => e.FitnessServiceId).HasColumnName("FitnessServiceID");
            entity.Property(e => e.DailyTrainsAllowed).HasDefaultValue(-1);
            entity.Property(e => e.FitnessDurationId).HasColumnName("FitnessDurationID");
            entity.Property(e => e.FitnessPlanId).HasColumnName("FitnessPlanID");
            entity.Property(e => e.GoodId).HasColumnName("GoodID");

            entity.HasOne(d => d.FitnessDuration).WithMany(p => p.FitnessServices)
                .HasForeignKey(d => d.FitnessDurationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FitnessServices_FitnessDurations");

            entity.HasOne(d => d.FitnessPlan).WithMany(p => p.FitnessServices)
                .HasForeignKey(d => d.FitnessPlanId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FitnessServices_FitnessPlans");
        });

        modelBuilder.Entity<FitnessStaff>(entity =>
        {
            entity.ToTable("FitnessStaff");

            entity.Property(e => e.FitnessStaffId).HasColumnName("FitnessStaffID");
            entity.Property(e => e.CardId).HasColumnName("CardID");
            entity.Property(e => e.UserId)
                .HasDefaultValue(1)
                .HasColumnName("UserID");

            entity.HasOne(d => d.Card).WithMany(p => p.FitnessStaffs)
                .HasForeignKey(d => d.CardId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FitnessStaff_FitnessCards");
        });

        modelBuilder.Entity<FitnessSystem>(entity =>
        {
            entity.HasKey(e => e.Version);

            entity.ToTable("FitnessSystem");

            entity.Property(e => e.Version).HasMaxLength(20);
            entity.Property(e => e.LastUpdate).HasColumnType("smalldatetime");
        });

        modelBuilder.Entity<FitnessTiming>(entity =>
        {
            entity.Property(e => e.FitnessTimingId).HasColumnName("FitnessTimingID");
            entity.Property(e => e.TimeFrom).HasColumnType("datetime");
            entity.Property(e => e.TimeTo).HasColumnType("datetime");
        });

        modelBuilder.Entity<FitnessVisit>(entity =>
        {
            entity.Property(e => e.FitnessVisitId).HasColumnName("FitnessVisitID");
            entity.Property(e => e.ActiveUserId)
                .HasDefaultValue(1)
                .HasColumnName("ActiveUserID");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.FitnessServiceId).HasColumnName("FitnessServiceID");
            entity.Property(e => e.PartnerId).HasColumnName("PartnerID");
            entity.Property(e => e.ServiceCount).HasDefaultValue(1);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.UserRealTime).HasColumnType("datetime");

            entity.HasOne(d => d.FitnessService).WithMany(p => p.FitnessVisits)
                .HasForeignKey(d => d.FitnessServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FitnessVisits_FitnessServices");
        });

        modelBuilder.Entity<FitnessVisitAccaunt>(entity =>
        {
            entity.ToTable("FitnessVisitAccaunt");

            entity.Property(e => e.FitnessVisitAccauntId).HasColumnName("FitnessVisitAccauntID");
            entity.Property(e => e.FitnessVisitId).HasColumnName("FitnessVisitID");
            entity.Property(e => e.OperId).HasColumnName("OperID");

            entity.HasOne(d => d.FitnessVisit).WithMany(p => p.FitnessVisitAccaunts)
                .HasForeignKey(d => d.FitnessVisitId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FitnessVisitAccaunt_FitnessVisits");
        });

        modelBuilder.Entity<FitnessVisitCard>(entity =>
        {
            entity.HasKey(e => e.FitnessVisitCardsId).HasName("PK_FitnessServiceCards");

            entity.Property(e => e.FitnessVisitCardsId).HasColumnName("FitnessVisitCardsID");
            entity.Property(e => e.CurrentVisitCardReduction).HasDefaultValue(1);
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.FitnessCardId).HasColumnName("FitnessCardID");
            entity.Property(e => e.FitnessVisitId).HasColumnName("FitnessVisitID");
            entity.Property(e => e.OwnerName).HasMaxLength(50);
            entity.Property(e => e.StartDate).HasColumnType("datetime");

            entity.HasOne(d => d.FitnessCard).WithMany(p => p.FitnessVisitCards)
                .HasForeignKey(d => d.FitnessCardId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FitnessServiceCards_FitnessCards");
        });

        modelBuilder.Entity<Good>(entity =>
        {
            entity.HasIndex(e => e.BarCode1, "IX_Goods_Barcode1");

            entity.HasIndex(e => e.BarCode2, "IX_Goods_Barcode2");

            entity.HasIndex(e => e.BarCode3, "IX_Goods_Barcode3");

            entity.HasIndex(e => e.Catalog1, "IX_Goods_Catalog1");

            entity.HasIndex(e => e.Catalog2, "IX_Goods_Catalog2");

            entity.HasIndex(e => e.Catalog3, "IX_Goods_Catalog3");

            entity.HasIndex(e => e.Code, "IX_Goods_Code");

            entity.HasIndex(e => new { e.Id, e.TaxGroup }, "IX_Goods_Light_printing_goods");

            entity.HasIndex(e => e.Name, "IX_Goods_Name");

            entity.HasIndex(e => new { e.Name2, e.GroupId }, "IX_Goods_Name2_GroupID");

            entity.HasIndex(e => new { e.PriceIn, e.PriceOut1, e.PriceOut2 }, "IX_Goods_Prices");

            entity.HasIndex(e => new { e.Id, e.Deleted, e.Code, e.GroupId, e.TaxGroup, e.IsVeryUsed }, "IX_Goods_ReloadLight");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BarCode1).HasMaxLength(255);
            entity.Property(e => e.BarCode2).HasMaxLength(255);
            entity.Property(e => e.BarCode3).HasMaxLength(255);
            entity.Property(e => e.Catalog1).HasMaxLength(255);
            entity.Property(e => e.Catalog2).HasMaxLength(255);
            entity.Property(e => e.Catalog3).HasMaxLength(255);
            entity.Property(e => e.Code).HasMaxLength(255);
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.GroupId).HasColumnName("GroupID");
            entity.Property(e => e.Measure1).HasMaxLength(255);
            entity.Property(e => e.Measure2).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Name2).HasMaxLength(255);
        });

        modelBuilder.Entity<GoodsGroup>(entity =>
        {
            entity.HasIndex(e => e.Code, "IX_GoodsGroups");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Code).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<InternalLog>(entity =>
        {
            entity.ToTable("InternalLog");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Message).HasMaxLength(3000);
        });

        modelBuilder.Entity<Lot>(entity =>
        {
            entity.HasIndex(e => new { e.SerialNo, e.EndDate }, "IX_Lots");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.EndDate).HasColumnType("smalldatetime");
            entity.Property(e => e.Location).HasMaxLength(255);
            entity.Property(e => e.ProductionDate).HasColumnType("smalldatetime");
            entity.Property(e => e.SerialNo).HasMaxLength(255);
        });

        modelBuilder.Entity<Network>(entity =>
        {
            entity.HasKey(e => e.Num);

            entity.ToTable("Network");

            entity.Property(e => e.Num).ValueGeneratedNever();
        });

        modelBuilder.Entity<NextAcct>(entity =>
        {
            entity.HasKey(e => e.NextAcct1);

            entity.ToTable("NextAcct");

            entity.Property(e => e.NextAcct1)
                .HasMaxLength(50)
                .HasColumnName("NextAcct");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
        });

        modelBuilder.Entity<Object>(entity =>
        {
            entity.HasIndex(e => new { e.Code, e.GroupId }, "IX_Objects");

            entity.HasIndex(e => e.Name, "IX_Objects_Name");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Code).HasMaxLength(255);
            entity.Property(e => e.GroupId).HasColumnName("GroupID");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Name2).HasMaxLength(255);
        });

        modelBuilder.Entity<ObjectsGroup>(entity =>
        {
            entity.HasIndex(e => e.Code, "IX_ObjectsGroups");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Code).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Operation>(entity =>
        {
            entity.HasIndex(e => new { e.Acct, e.OperType, e.Id, e.GoodId, e.PartnerId, e.PriceOut, e.Discount, e.Vatout }, "IX_Goods_Light_printing_oper");

            entity.HasIndex(e => e.Date, "IX_Operations_Date");

            entity.HasIndex(e => new { e.ObjectId, e.OperType }, "IX_Operations_Get_Next_Acct");

            entity.HasIndex(e => e.GoodId, "IX_Operations_GoodID");

            entity.HasIndex(e => new { e.GoodId, e.PartnerId, e.OperType }, "IX_Operations_LastSalePrice");

            entity.HasIndex(e => e.Lot, "IX_Operations_Lot");

            entity.HasIndex(e => e.LotId, "IX_Operations_LotID");

            entity.HasIndex(e => e.ObjectId, "IX_Operations_ObjectID");

            entity.HasIndex(e => new { e.OperatorId, e.CurrencyId, e.SrcDocId, e.UserId }, "IX_Operations_OperatorID_SrcDocID_UserID_CurrencyID");

            entity.HasIndex(e => e.OperType, "IX_Operations_Opertype");

            entity.HasIndex(e => e.PartnerId, "IX_Operations_PartnerID");

            entity.HasIndex(e => new { e.Date, e.Id, e.GoodId, e.PartnerId, e.OperType }, "IX_Operations_Partner_Price_Get").IsDescending(true, true, false, false, false);

            entity.HasIndex(e => new { e.ObjectId, e.OperatorId, e.OperType, e.UserRealTime }, "Light_Load_Operations_by_UserRealtime");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CurrencyId).HasColumnName("CurrencyID");
            entity.Property(e => e.Date).HasColumnType("smalldatetime");
            entity.Property(e => e.GoodId).HasColumnName("GoodID");
            entity.Property(e => e.Lot).HasMaxLength(50);
            entity.Property(e => e.LotId).HasColumnName("LotID");
            entity.Property(e => e.Note).HasMaxLength(255);
            entity.Property(e => e.ObjectId).HasColumnName("ObjectID");
            entity.Property(e => e.OperatorId).HasColumnName("OperatorID");
            entity.Property(e => e.PartnerId).HasColumnName("PartnerID");
            entity.Property(e => e.SrcDocId).HasColumnName("SrcDocID");
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.UserRealTime).HasColumnType("datetime");
            entity.Property(e => e.Vatin).HasColumnName("VATIn");
            entity.Property(e => e.Vatout).HasColumnName("VATOut");
        });

        modelBuilder.Entity<OperationType>(entity =>
        {
            entity.ToTable("OperationType");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Ar)
                .HasMaxLength(255)
                .HasColumnName("AR");
            entity.Property(e => e.Bg)
                .HasMaxLength(255)
                .HasColumnName("BG");
            entity.Property(e => e.De)
                .HasMaxLength(255)
                .HasColumnName("DE");
            entity.Property(e => e.El)
                .HasMaxLength(255)
                .HasColumnName("EL");
            entity.Property(e => e.En)
                .HasMaxLength(255)
                .HasColumnName("EN");
            entity.Property(e => e.Es)
                .HasMaxLength(255)
                .HasColumnName("ES");
            entity.Property(e => e.Fi)
                .HasMaxLength(255)
                .HasColumnName("FI");
            entity.Property(e => e.Gr)
                .HasMaxLength(255)
                .HasColumnName("GR");
            entity.Property(e => e.Hy)
                .HasMaxLength(255)
                .HasColumnName("HY");
            entity.Property(e => e.Ka)
                .HasMaxLength(255)
                .HasColumnName("KA");
            entity.Property(e => e.Lv)
                .HasMaxLength(255)
                .HasColumnName("LV");
            entity.Property(e => e.Pl)
                .HasMaxLength(255)
                .HasColumnName("PL");
            entity.Property(e => e.Ro)
                .HasMaxLength(255)
                .HasColumnName("RO");
            entity.Property(e => e.Ru)
                .HasMaxLength(255)
                .HasColumnName("RU");
            entity.Property(e => e.Sq)
                .HasMaxLength(255)
                .HasColumnName("SQ");
            entity.Property(e => e.Sr)
                .HasMaxLength(255)
                .HasColumnName("SR");
            entity.Property(e => e.Tk)
                .HasMaxLength(255)
                .HasColumnName("TK");
            entity.Property(e => e.Tr)
                .HasMaxLength(255)
                .HasColumnName("TR");
            entity.Property(e => e.Uk)
                .HasMaxLength(255)
                .HasColumnName("UK");
            entity.Property(e => e.Zu)
                .HasMaxLength(255)
                .HasColumnName("ZU");
        });

        modelBuilder.Entity<Partner>(entity =>
        {
            entity.HasIndex(e => e.Address, "IX_Partners_Address");

            entity.HasIndex(e => e.BankAcct, "IX_Partners_BankAcct");

            entity.HasIndex(e => e.BankCode, "IX_Partners_BankCode");

            entity.HasIndex(e => e.Bulstat, "IX_Partners_Bulstat");

            entity.HasIndex(e => e.CardNumber, "IX_Partners_CardNo");

            entity.HasIndex(e => e.City, "IX_Partners_City");

            entity.HasIndex(e => e.Code, "IX_Partners_Code");

            entity.HasIndex(e => e.Company, "IX_Partners_Company");

            entity.HasIndex(e => e.Company2, "IX_Partners_Company2");

            entity.HasIndex(e => new { e.UserId, e.GroupId }, "IX_Partners_GroupID_UserID");

            entity.HasIndex(e => e.Mol, "IX_Partners_MOL");

            entity.HasIndex(e => e.Phone, "IX_Partners_Phone");

            entity.HasIndex(e => e.Address2, "IX_Partners_PrintAddress");

            entity.HasIndex(e => e.City2, "IX_Partners_PrintCity");

            entity.HasIndex(e => e.Mol2, "IX_Partners_PrintMOL");

            entity.HasIndex(e => e.Phone2, "IX_Partners_PrintPhone");

            entity.HasIndex(e => e.TaxNo, "IX_Partners_Taxno");

            entity.HasIndex(e => e.IsVeryUsed, "Light_Load_Restaurant_partners");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Address2).HasMaxLength(255);
            entity.Property(e => e.BankAcct).HasMaxLength(255);
            entity.Property(e => e.BankCode).HasMaxLength(255);
            entity.Property(e => e.BankName).HasMaxLength(255);
            entity.Property(e => e.BankVatacct)
                .HasMaxLength(255)
                .HasColumnName("BankVATAcct");
            entity.Property(e => e.BankVatcode)
                .HasMaxLength(255)
                .HasColumnName("BankVATCode");
            entity.Property(e => e.BankVatname)
                .HasMaxLength(255)
                .HasColumnName("BankVATName");
            entity.Property(e => e.Bulstat).HasMaxLength(255);
            entity.Property(e => e.CardNumber).HasMaxLength(255);
            entity.Property(e => e.City).HasMaxLength(255);
            entity.Property(e => e.City2).HasMaxLength(255);
            entity.Property(e => e.Code).HasMaxLength(255);
            entity.Property(e => e.Company).HasMaxLength(255);
            entity.Property(e => e.Company2).HasMaxLength(255);
            entity.Property(e => e.EMail)
                .HasMaxLength(255)
                .HasColumnName("eMail");
            entity.Property(e => e.Fax).HasMaxLength(255);
            entity.Property(e => e.GroupId).HasColumnName("GroupID");
            entity.Property(e => e.Mol)
                .HasMaxLength(255)
                .HasColumnName("MOL");
            entity.Property(e => e.Mol2)
                .HasMaxLength(255)
                .HasColumnName("MOL2");
            entity.Property(e => e.Note1).HasMaxLength(255);
            entity.Property(e => e.Note2).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(255);
            entity.Property(e => e.Phone2).HasMaxLength(255);
            entity.Property(e => e.TaxNo).HasMaxLength(255);
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.UserRealTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<PartnersGroup>(entity =>
        {
            entity.HasIndex(e => e.Code, "IX_PartnersGroups");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Code).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasIndex(e => new { e.PartnerId, e.OperType, e.EndDate }, "IX_LighttPriceRules");

            entity.HasIndex(e => new { e.OperType, e.PartnerId, e.ObjectId }, "IX_Payments_Combined");

            entity.HasIndex(e => e.Date, "IX_Payments_Date");

            entity.HasIndex(e => e.EndDate, "IX_Payments_EndDate");

            entity.HasIndex(e => new { e.Acct, e.OperType, e.Mode }, "IX_Payments_LightLoad_Payments");

            entity.HasIndex(e => new { e.ObjectId, e.UserId, e.Mode }, "IX_Payments_Objectid_UserID_Mode");

            entity.HasIndex(e => e.OperType, "IX_Payments_Opertype");

            entity.HasIndex(e => e.PartnerId, "IX_Payments_PartnerID");

            entity.HasIndex(e => new { e.OperType, e.Mode, e.UserId, e.ObjectId, e.UserRealTime }, "Light_Load_Payments_by_Partners_by_UserRealTime");

            entity.HasIndex(e => new { e.OperType, e.Mode, e.ObjectId, e.UserRealTime }, "Light_Load_Payments_by_Users_UserRealTime");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Date).HasColumnType("smalldatetime");
            entity.Property(e => e.EndDate).HasColumnType("smalldatetime");
            entity.Property(e => e.ObjectId).HasColumnName("ObjectID");
            entity.Property(e => e.PartnerId).HasColumnName("PartnerID");
            entity.Property(e => e.TransactionNumber).HasMaxLength(255);
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.UserRealTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<PaymentType>(entity =>
        {
            entity.HasIndex(e => e.PaymentMethod, "IX_PaymentTypes");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<PriceRule>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Formula).HasMaxLength(1000);
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Registration>(entity =>
        {
            entity.ToTable("Registration");

            entity.HasIndex(e => new { e.Code, e.Company, e.Mol, e.TaxNo, e.Bulstat, e.BankCode, e.UserId }, "IX_Registration");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.BankAcct).HasMaxLength(255);
            entity.Property(e => e.BankCode).HasMaxLength(255);
            entity.Property(e => e.BankName).HasMaxLength(255);
            entity.Property(e => e.BankVatacct)
                .HasMaxLength(255)
                .HasColumnName("BankVATAcct");
            entity.Property(e => e.Bulstat).HasMaxLength(255);
            entity.Property(e => e.City).HasMaxLength(255);
            entity.Property(e => e.Code).HasMaxLength(255);
            entity.Property(e => e.Company).HasMaxLength(255);
            entity.Property(e => e.EMail)
                .HasMaxLength(255)
                .HasColumnName("eMail");
            entity.Property(e => e.Fax).HasMaxLength(255);
            entity.Property(e => e.Mol)
                .HasMaxLength(255)
                .HasColumnName("MOL");
            entity.Property(e => e.Note1).HasMaxLength(255);
            entity.Property(e => e.Note2).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(255);
            entity.Property(e => e.TaxNo).HasMaxLength(255);
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.UserRealTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<Store>(entity =>
        {
            entity.ToTable("Store");

            entity.HasIndex(e => new { e.ObjectId, e.GoodId }, "IX_STORE_LIGHTGOODSLOAD");

            entity.HasIndex(e => e.ObjectId, "IX_Store_Goodid");

            entity.HasIndex(e => e.Lot, "IX_Store_Lot");

            entity.HasIndex(e => e.LotId, "IX_Store_LotID");

            entity.HasIndex(e => e.ObjectId, "IX_Store_ObjectID");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.GoodId).HasColumnName("GoodID");
            entity.Property(e => e.Lot).HasMaxLength(250);
            entity.Property(e => e.LotId).HasColumnName("LotID");
            entity.Property(e => e.ObjectId).HasColumnName("ObjectID");
        });

        modelBuilder.Entity<System>(entity =>
        {
            entity.HasKey(e => e.Version);

            entity.ToTable("System");

            entity.Property(e => e.Version).HasMaxLength(20);
            entity.Property(e => e.LastBackup).HasColumnType("smalldatetime");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
        });

        modelBuilder.Entity<Transformation>(entity =>
        {
            entity.HasIndex(e => new { e.RootOperType, e.RootAcct, e.FromOperType, e.FromAcct, e.ToOperType, e.ToAcct, e.UserId }, "IX_Transformations");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.UserRealTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(e => new { e.Code, e.GroupId }, "IX_Users");

            entity.HasIndex(e => e.Name, "IX_Users_Name");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CardNumber).HasMaxLength(255);
            entity.Property(e => e.Code).HasMaxLength(255);
            entity.Property(e => e.GroupId).HasColumnName("GroupID");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Name2).HasMaxLength(255);
            entity.Property(e => e.Password).HasMaxLength(50);
        });

        modelBuilder.Entity<UsersGroup>(entity =>
        {
            entity.HasIndex(e => e.Code, "IX_UsersGroups");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Code).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<UsersSecurity>(entity =>
        {
            entity.ToTable("UsersSecurity");

            entity.HasIndex(e => new { e.UserId, e.ControlName }, "IX_UsersSecurity");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ControlName).HasMaxLength(100);
            entity.Property(e => e.UserId).HasColumnName("UserID");
        });

        modelBuilder.Entity<Vatgroup>(entity =>
        {
            entity.ToTable("VATGroups");

            entity.HasIndex(e => new { e.Code, e.Name }, "IX_VATGroups");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Code).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Vatvalue).HasColumnName("VATValue");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
