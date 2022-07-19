﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.ApplicationContext;

namespace OpenSourceEntitys.Migrations
{
    [DbContext(typeof(EntitySourceContext))]
    [Migration("20220702123502_Migrations_20")]
    partial class Migrations_20
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys.AddresSent", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("DateCreate")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("MessageId")
                        .HasColumnType("int");

                    b.Property<string>("RecipientId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("id");

                    b.HasIndex("MessageId")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("addresSents");
                });

            modelBuilder.Entity("OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys.Country", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys.Document", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("DateCreate")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("DateDeleted")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("DocumentTypeId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(1)
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Text")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("id");

                    b.HasIndex("DocumentTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys.DocumentType", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("NameType")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("id");

                    b.ToTable("DocumentTypes");
                });

            modelBuilder.Entity("OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys.Domains", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("id");

                    b.ToTable("Domains");
                });

            modelBuilder.Entity("OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys.Groups", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys.GroupsIntermediate", b =>
                {
                    b.Property<int>("GroupsId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DateCreate")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GroupsId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("GroupsIntermediate");
                });

            modelBuilder.Entity("OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys.Logging", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("DateCreate")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("LoggingInformationId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("id");

                    b.HasIndex("LoggingInformationId");

                    b.HasIndex("UserId");

                    b.ToTable("Loggings");
                });

            modelBuilder.Entity("OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys.LoggingInformation", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("LoggingInformations");
                });

            modelBuilder.Entity("OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys.Message", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("DateCreate")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<bool>("IsHidden")
                        .HasMaxLength(1)
                        .HasColumnType("bit");

                    b.Property<bool>("IsRead")
                        .HasMaxLength(1)
                        .HasColumnType("bit");

                    b.Property<string>("MessageText")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<int>("ThemeId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("ThemeId")
                        .IsUnique();

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys.MessageSettings", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("MessageDonorIsHidden")
                        .HasColumnType("bit");

                    b.Property<int>("MessageId")
                        .HasColumnType("int");

                    b.Property<bool>("MessageRecipientIsHidden")
                        .HasColumnType("bit");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserRecipientId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("MessageId")
                        .IsUnique();

                    b.ToTable("MessageSettings");
                });

            modelBuilder.Entity("OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys.Participant", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("DateAge")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DateChanges")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("PolId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("id");

                    b.HasIndex("PolId");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("Participants");
                });

            modelBuilder.Entity("OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys.Pol", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Pols");
                });

            modelBuilder.Entity("OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys.Theme", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("id");

                    b.ToTable("Themes");
                });

            modelBuilder.Entity("OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ConsentProvisionPersonalData")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(1)
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("DateChanges")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("DateCreate")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("DateLastEntry")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("DomainId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("DomainId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys.AddresSent", b =>
                {
                    b.HasOne("OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys.Message", "Message")
                        .WithOne("AddresSent")
                        .HasForeignKey("OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys.AddresSent", "MessageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys.User", "User")
                        .WithMany("AddresSents")
                        .HasForeignKey("UserId");

                    b.Navigation("Message");

                    b.Navigation("User");
                });

            modelBuilder.Entity("OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys.Document", b =>
                {
                    b.HasOne("OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys.DocumentType", "DocumentType")
                        .WithMany("Document")
                        .HasForeignKey("DocumentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys.User", "User")
                        .WithMany("Documents")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("DocumentType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys.GroupsIntermediate", b =>
                {
                    b.HasOne("OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys.Groups", "Groups")
                        .WithMany("GroupsIntermediates")
                        .HasForeignKey("GroupsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys.User", "User")
                        .WithMany("GroupsIntermediates")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Groups");

                    b.Navigation("User");
                });

            modelBuilder.Entity("OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys.Logging", b =>
                {
                    b.HasOne("OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys.LoggingInformation", "loggingInformation")
                        .WithMany("loggings")
                        .HasForeignKey("LoggingInformationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys.User", "User")
                        .WithMany("Loggings")
                        .HasForeignKey("UserId");

                    b.Navigation("loggingInformation");

                    b.Navigation("User");
                });

            modelBuilder.Entity("OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys.Message", b =>
                {
                    b.HasOne("OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys.Theme", "Theme")
                        .WithOne("Message")
                        .HasForeignKey("OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys.Message", "ThemeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Theme");
                });

            modelBuilder.Entity("OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys.MessageSettings", b =>
                {
                    b.HasOne("OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys.Message", "Message")
                        .WithOne("MessageSettings")
                        .HasForeignKey("OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys.MessageSettings", "MessageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Message");
                });

            modelBuilder.Entity("OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys.Participant", b =>
                {
                    b.HasOne("OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys.Pol", "Pol")
                        .WithMany("Profile")
                        .HasForeignKey("PolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys.User", "User")
                        .WithOne("Profile")
                        .HasForeignKey("OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys.Participant", "UserId");

                    b.Navigation("Pol");

                    b.Navigation("User");
                });

            modelBuilder.Entity("OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys.User", b =>
                {
                    b.HasOne("OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys.Country", "Country")
                        .WithMany("Users")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys.Domains", "Domain")
                        .WithMany("Users")
                        .HasForeignKey("DomainId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");

                    b.Navigation("Domain");
                });

            modelBuilder.Entity("OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys.Country", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys.DocumentType", b =>
                {
                    b.Navigation("Document");
                });

            modelBuilder.Entity("OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys.Domains", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys.Groups", b =>
                {
                    b.Navigation("GroupsIntermediates");
                });

            modelBuilder.Entity("OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys.LoggingInformation", b =>
                {
                    b.Navigation("loggings");
                });

            modelBuilder.Entity("OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys.Message", b =>
                {
                    b.Navigation("AddresSent");

                    b.Navigation("MessageSettings");
                });

            modelBuilder.Entity("OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys.Pol", b =>
                {
                    b.Navigation("Profile");
                });

            modelBuilder.Entity("OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys.Theme", b =>
                {
                    b.Navigation("Message");
                });

            modelBuilder.Entity("OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys.User", b =>
                {
                    b.Navigation("AddresSents");

                    b.Navigation("Documents");

                    b.Navigation("GroupsIntermediates");

                    b.Navigation("Loggings");

                    b.Navigation("Profile");
                });
#pragma warning restore 612, 618
        }
    }
}
