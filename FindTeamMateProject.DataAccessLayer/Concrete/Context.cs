using FindTeamMateProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindTeamMateProject.DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-ISO96UVH\\SQLEXPRESS;Database=FindTeamMateProjectDB;integrated security=True;");//DataSource='de kullanılabilir.


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<SenderReceiverPerson>(entity =>
            {
                entity.HasKey(n => n.SenderReceiverPersonID);

                entity.HasOne(n => n.Sender)
                    .WithMany(u => u.SenderReceiverPeopleForSender)
                    .HasForeignKey(n => n.SenderID)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(n => n.Receiver)
                    .WithMany(u => u.SenderReceiverPeopleForReceiver)
                    .HasForeignKey(n => n.ReceiverID)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);

                


            });
            modelBuilder.Entity<SenderReceiverMessage>(entity =>
            {
                entity.HasKey(n => n.SenderReceiverMessageID);

                entity.HasOne(n => n.SenderMessage)
                    .WithMany(u => u.SenderReceiverPeopleForSenderMessage)
                    .HasForeignKey(n => n.SenderMessageID)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(n => n.ReceiverMessage)
                    .WithMany(u => u.SenderReceiverPeopleForReceiverMessage)
                    .HasForeignKey(n => n.ReceiverMessageID)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);




            });


        }
        public DbSet<SenderReceiverPerson> SenderReceiverPeople { get; set; }
        public DbSet<SenderReceiverMessage> SenderReceiverMessages{ get; set; }
        public DbSet<Message> Messages { get; set; }



    }
}
