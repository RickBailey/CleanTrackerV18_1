using System;
using System.Collections.Generic;
using System.Linq;
using CleanTrackerV18.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CleanTrackerV18.Models.CleanTracker
{
    public partial class CleanTrackerEntites : DbContext
    {
        public CleanTrackerEntites()
        {
        }

        public CleanTrackerEntites(DbContextOptions<CleanTrackerEntites> options)
            : base(options)
        {
        }

        public virtual DbSet<Services> Services { get; set; }
        public virtual DbSet<Units> Units { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<WorkOrders> WorkOrders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("data source=LAPTOP-B8420T5F\\SQLEXPRESS;Initial Catalog=OCPTRACKERII;Integrated Security=SSPI;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Services>(entity =>
            {
                entity.HasKey(e => e.ServiceId)
                    .HasName("PK__Services__C51BB0EAE8DE1087");

                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.Property(e => e.ServiceIsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.ServiceLastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ServiceLastModifiedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('RGB')");

                entity.Property(e => e.ServiceType)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Units>(entity =>
            {
                entity.HasKey(e => e.UnitId)
                    .HasName("PK__Units__44F5EC95F01EB584");

                entity.Property(e => e.UnitId).HasColumnName("UnitID");

                entity.Property(e => e.UnitIsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UnitLastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UnitLastModifiedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UnitName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UnitNeighborhood)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UnitStatus)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('READY')");

                entity.Property(e => e.UnitType)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false);
            });


            /*{

                

                var teams = Users.ToList();

                List<SelectListItem> items = new List<SelectListItem>();

                foreach (var User in Users)
                {
                    var item = new SelectListItem
                    {
                        Value = User.UserId.ToString(),
                        Text = User.UserLastName
                    };

                    items.Add(item);
                }

                MultiSelectList UsersList = new MultiSelectList(items.OrderBy(i => i.Text), "Value", "Text");

                EditWorkOrderVM model = new EditWorkOrderVM { Users = UsersList };

                 
            }*/

        
            

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Users__1788CCAC27A33977");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.UserEmailAddress)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserFirstName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserIsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UserLastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserLastModifiedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('RGB')");

                entity.Property(e => e.UserLastName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserPhoneNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserType)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WorkOrders>(entity =>
            {
                entity.HasKey(e => e.WorkOrderId)
                    .HasName("PK__WorkOrde__AE75517549D85BC4");

                entity.Property(e => e.WorkOrderId).HasColumnName("WorkOrderID");

                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.Property(e => e.UnitId).HasColumnName("UnitID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.WorkOrderAssign)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('NOT ASSIGNED')");


                entity.Property(e => e.WorkOrderCompletionStatus)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('DIRTY')");

                entity.Property(e => e.WorkOrderIsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.WorkOrderLastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.WorkOrderLastModifiedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('RGB')");

                entity.Property(e => e.WorkOrderName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.WorkOrderNumber).HasDefaultValueSql("((0))");

                entity.Property(e => e.WorkOrderServiceType)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('GC')");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.WorkOrders)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("FK__WorkOrder__Servi__71D1E811");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.WorkOrders)
                    .HasForeignKey(d => d.UnitId)
                    .HasConstraintName("FK__WorkOrder__UnitI__70DDC3D8");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.WorkOrders)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__WorkOrder__UserI__6FE99F9F");
            });

        {
            modelBuilder.Entity<WorkOrderUser>()
                .HasKey(wu => new { wu.WorkOrderId, wu.UserId });
            modelBuilder.Entity<WorkOrderUser>()
                .HasOne(wu => wu.WorkOrder)
                .WithMany(w => w.WorkOrderUsers)
                .HasForeignKey(wu => wu.WorkOrderId);
            modelBuilder.Entity<WorkOrderUser>()
                .HasOne(wu => wu.Users)
                .WithMany(u => u.WorkOrderUsers)
                .HasForeignKey(wu => wu.UserId);
        }

        OnModelCreatingPartial(modelBuilder);
        }

        private void Map(Func<object, object> p)
        {
            throw new NotImplementedException();
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
