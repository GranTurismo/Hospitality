using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HospitalityShared.Models;

public partial class IkaMedContext : DbContext
{
    public IkaMedContext()
    {
    }

    public IkaMedContext(DbContextOptions<IkaMedContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AdditionalService> AdditionalServices { get; set; }

    public virtual DbSet<Chat> Chats { get; set; }

    public virtual DbSet<ChatImage> ChatImages { get; set; }

    public virtual DbSet<ChatMessage> ChatMessages { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<CompanyImage> CompanyImages { get; set; }

    public virtual DbSet<Config> Configs { get; set; }

    public virtual DbSet<Favourite> Favourites { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Procedure> Procedures { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<ReviewImage> ReviewImages { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserPhoto> UserPhotos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=vps-4e996808.vps.ovh.net;port=3306;user=root;password=SNXnkPvTj9uj@;database=IkaMed;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdditionalService>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.CompanyId, "AdditionalServices_Company_Id_fk");

            entity.Property(e => e.ServiceNameEn).HasMaxLength(255);
            entity.Property(e => e.ServiceNameKa).HasMaxLength(255);
            entity.Property(e => e.ServiceNameRu).HasMaxLength(255);
            entity.Property(e => e.ServiceNameTr).HasMaxLength(255);

            entity.HasOne(d => d.Company).WithMany(p => p.AdditionalServices)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("AdditionalServices_Company_Id_fk");
        });

        modelBuilder.Entity<Chat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Chat");

            entity.HasIndex(e => e.CompanyId, "Chat_Company_Id_fk");

            entity.HasIndex(e => e.UserId, "Chat_User_Id_fk");

            entity.Property(e => e.StartDate).HasColumnType("datetime");

            entity.HasOne(d => d.Company).WithMany(p => p.Chats)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Chat_Company_Id_fk");

            entity.HasOne(d => d.User).WithMany(p => p.Chats)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Chat_User_Id_fk");
        });

        modelBuilder.Entity<ChatImage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.MessageId, "ChatImages_ChatMessages_Id_fk");

            entity.HasIndex(e => e.ChatId, "ChatImages_Chat_Id_fk");

            entity.HasOne(d => d.Chat).WithMany(p => p.ChatImages)
                .HasForeignKey(d => d.ChatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ChatImages_Chat_Id_fk");

            entity.HasOne(d => d.Message).WithMany(p => p.ChatImages)
                .HasForeignKey(d => d.MessageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ChatImages_ChatMessages_Id_fk");
        });

        modelBuilder.Entity<ChatMessage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.ChatId, "ChatMessages_Chat_Id_fk");

            entity.Property(e => e.Message).HasMaxLength(4000);
            entity.Property(e => e.MessageDate).HasColumnType("datetime");

            entity.HasOne(d => d.Chat).WithMany(p => p.ChatMessages)
                .HasForeignKey(d => d.ChatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ChatMessages_Chat_Id_fk");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Company");

            entity.Property(e => e.CompanyRegistrationId).HasMaxLength(40);
            entity.Property(e => e.Description).HasMaxLength(1024);
            entity.Property(e => e.Mail).HasMaxLength(64);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.RegisterDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<CompanyImage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.CompanyId, "CompanyImages_Company_Id_fk");

            entity.Property(e => e.Description).HasMaxLength(255);

            entity.HasOne(d => d.Company).WithMany(p => p.CompanyImages)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("CompanyImages_Company_Id_fk");
        });

        modelBuilder.Entity<Config>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Config");

            entity.Property(e => e.Name).HasMaxLength(28);
            entity.Property(e => e.StringValue).HasMaxLength(256);
        });

        modelBuilder.Entity<Favourite>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.CompanyId, "Favourites_Company_Id_fk");

            entity.HasIndex(e => e.UserId, "Favourites_User_Id_fk");

            entity.HasOne(d => d.Company).WithMany(p => p.Favourites)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Favourites_Company_Id_fk");

            entity.HasOne(d => d.User).WithMany(p => p.Favourites)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Favourites_User_Id_fk");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Order");

            entity.HasIndex(e => e.CompanyId, "Order_Company_Id_fk");

            entity.HasIndex(e => e.ProcedureId, "Order_Procedure_Id_fk");

            entity.HasIndex(e => e.UserId, "Order_User_Id_fk");

            entity.HasOne(d => d.Company).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Order_Company_Id_fk");

            entity.HasOne(d => d.Procedure).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ProcedureId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Order_Procedure_Id_fk");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Order_User_Id_fk");
        });

        modelBuilder.Entity<Procedure>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Procedure");

            entity.HasIndex(e => e.CompanyId, "Procedure_Company_Id_fk");

            entity.Property(e => e.NameEn).HasMaxLength(1024);
            entity.Property(e => e.NameKa).HasMaxLength(1024);
            entity.Property(e => e.NameRu).HasMaxLength(1024);
            entity.Property(e => e.NameTr).HasMaxLength(1024);

            entity.HasOne(d => d.Company).WithMany(p => p.Procedures)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Procedure_Company_Id_fk");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Review");

            entity.HasIndex(e => e.CompanyId, "Review_Company_Id_fk");

            entity.HasIndex(e => e.UserId, "Review_User_Id_fk");

            entity.Property(e => e.ReviewMessage).HasMaxLength(8000);

            entity.HasOne(d => d.Company).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Review_Company_Id_fk");

            entity.HasOne(d => d.User).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Review_User_Id_fk");
        });

        modelBuilder.Entity<ReviewImage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.ReviewId, "ReviewImages_Review_Id_fk");

            entity.HasOne(d => d.Review).WithMany(p => p.ReviewImages)
                .HasForeignKey(d => d.ReviewId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ReviewImages_Review_Id_fk");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("User");

            entity.Property(e => e.Mail).HasMaxLength(64);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.PersonalId).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(25);
            entity.Property(e => e.RegisterDate).HasColumnType("datetime");
            entity.Property(e => e.Surname).HasMaxLength(255);
        });

        modelBuilder.Entity<UserPhoto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.UserId, "UserPhotos_User_Id_fk");

            entity.HasOne(d => d.User).WithMany(p => p.UserPhotos)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("UserPhotos_User_Id_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
