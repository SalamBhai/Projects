﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TheLogoPhilia.ApplicationDbContext;

namespace The_LogoPhilia.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220317234627_newMigrat")]
    partial class newMigrat
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.8");

            modelBuilder.Entity("TheLogoPhilia.Entities.AdministratorMessage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateSent")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("MessageContent")
                        .HasColumnType("text");

                    b.Property<string>("MessageSubject")
                        .HasColumnType("text");

                    b.Property<int>("MessageType")
                        .HasColumnType("int");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("AdministratorMessages");
                });

            modelBuilder.Entity("TheLogoPhilia.Entities.ApplicationAdministrator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AdministratorCode")
                        .HasColumnType("text");

                    b.Property<string>("AdministratorEmail")
                        .HasColumnType("text");

                    b.Property<string>("AdministratorImage")
                        .HasColumnType("text");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("ApplicationAdministrators");
                });

            modelBuilder.Entity("TheLogoPhilia.Entities.ApplicationUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("ApplicationUserImage")
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .HasColumnType("text");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<string>("UserEmail")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("ApplicationUsers");
                });

            modelBuilder.Entity("TheLogoPhilia.Entities.ApplicationUserComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ApplicationUserId")
                        .HasColumnType("int");

                    b.Property<string>("CommentContent")
                        .HasColumnType("text");

                    b.Property<DateTime>("CommentDate")
                        .HasColumnType("datetime");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("PostId");

                    b.ToTable("ApplicationUserComments");
                });

            modelBuilder.Entity("TheLogoPhilia.Entities.ApplicationUserPost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ApplicationUserId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DatePosted")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<string>("PostContent")
                        .HasColumnType("text");

                    b.Property<string>("VideoFile")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("ApplicationUserPosts");
                });

            modelBuilder.Entity("TheLogoPhilia.Entities.JoinerTables.ApplicationUserAdminMessage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AdministratorMessageId")
                        .HasColumnType("int");

                    b.Property<int>("ApplicationUserId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AdministratorMessageId");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("ApplicationUserAdminMessages");
                });

            modelBuilder.Entity("TheLogoPhilia.Entities.JoinerTables.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("TheLogoPhilia.Entities.LanguageOfOrigin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<string>("HistoryAboutIt")
                        .HasColumnType("text");

                    b.Property<string>("InformationOfWordsFromIt")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LanguageOfOriginName")
                        .HasColumnType("text");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("LanguageOfOrigins");
                });

            modelBuilder.Entity("TheLogoPhilia.Entities.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("MessageContent")
                        .HasColumnType("text");

                    b.Property<string>("MessageSubject")
                        .HasColumnType("text");

                    b.Property<int>("MessageType")
                        .HasColumnType("int");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("TheLogoPhilia.Entities.Notes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ApplicationUserId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("TheLogoPhilia.Entities.PostLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ApplicationUserPostId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<string>("PostUrl")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserPostId")
                        .IsUnique();

                    b.ToTable("PostLogs");
                });

            modelBuilder.Entity("TheLogoPhilia.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<string>("RoleName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("TheLogoPhilia.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TheLogoPhilia.Entities.Word", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AmericanEnglishAlternateSpelling")
                        .HasColumnType("text");

                    b.Property<string>("BritishEnglishAlternateSpelling")
                        .HasColumnType("text");

                    b.Property<string>("BritishOrAmerican")
                        .HasColumnType("text");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("LanguageOfOriginId")
                        .HasColumnType("int");

                    b.Property<string>("Meaning")
                        .HasColumnType("text");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<string>("PartOfSpeech")
                        .HasColumnType("text");

                    b.Property<string>("TheWord")
                        .HasColumnType("text");

                    b.Property<string>("WordAudio")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("LanguageOfOriginId");

                    b.ToTable("Words");
                });

            modelBuilder.Entity("TheLogoPhilia.Entities.ApplicationAdministrator", b =>
                {
                    b.HasOne("TheLogoPhilia.Entities.User", "User")
                        .WithOne("ApplicationAdministrator")
                        .HasForeignKey("TheLogoPhilia.Entities.ApplicationAdministrator", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TheLogoPhilia.Entities.ApplicationUser", b =>
                {
                    b.HasOne("TheLogoPhilia.Entities.User", "User")
                        .WithOne("ApplicationUser")
                        .HasForeignKey("TheLogoPhilia.Entities.ApplicationUser", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TheLogoPhilia.Entities.ApplicationUserComment", b =>
                {
                    b.HasOne("TheLogoPhilia.Entities.ApplicationUser", "ApplicationUser")
                        .WithMany("ApplicationUserComments")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TheLogoPhilia.Entities.ApplicationUserPost", "Post")
                        .WithMany("ApplicationUserComments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("TheLogoPhilia.Entities.ApplicationUserPost", b =>
                {
                    b.HasOne("TheLogoPhilia.Entities.ApplicationUser", "ApplicationUser")
                        .WithMany("ApplicationUserPosts")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("TheLogoPhilia.Entities.JoinerTables.ApplicationUserAdminMessage", b =>
                {
                    b.HasOne("TheLogoPhilia.Entities.AdministratorMessage", "AdministratorMessage")
                        .WithMany("ApplicationUserAdminMessages")
                        .HasForeignKey("AdministratorMessageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TheLogoPhilia.Entities.ApplicationUser", "ApplicationUser")
                        .WithMany("ApplicationUserAdminMessages")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AdministratorMessage");

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("TheLogoPhilia.Entities.JoinerTables.UserRole", b =>
                {
                    b.HasOne("TheLogoPhilia.Entities.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TheLogoPhilia.Entities.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TheLogoPhilia.Entities.Notes", b =>
                {
                    b.HasOne("TheLogoPhilia.Entities.ApplicationUser", "ApplicationUser")
                        .WithMany("ApplicationUserNotes")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("TheLogoPhilia.Entities.PostLog", b =>
                {
                    b.HasOne("TheLogoPhilia.Entities.ApplicationUserPost", "ApplicationUserPost")
                        .WithOne("PostLog")
                        .HasForeignKey("TheLogoPhilia.Entities.PostLog", "ApplicationUserPostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUserPost");
                });

            modelBuilder.Entity("TheLogoPhilia.Entities.Word", b =>
                {
                    b.HasOne("TheLogoPhilia.Entities.LanguageOfOrigin", "LanguageOfOrigin")
                        .WithMany("Words")
                        .HasForeignKey("LanguageOfOriginId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LanguageOfOrigin");
                });

            modelBuilder.Entity("TheLogoPhilia.Entities.AdministratorMessage", b =>
                {
                    b.Navigation("ApplicationUserAdminMessages");
                });

            modelBuilder.Entity("TheLogoPhilia.Entities.ApplicationUser", b =>
                {
                    b.Navigation("ApplicationUserAdminMessages");

                    b.Navigation("ApplicationUserComments");

                    b.Navigation("ApplicationUserNotes");

                    b.Navigation("ApplicationUserPosts");
                });

            modelBuilder.Entity("TheLogoPhilia.Entities.ApplicationUserPost", b =>
                {
                    b.Navigation("ApplicationUserComments");

                    b.Navigation("PostLog");
                });

            modelBuilder.Entity("TheLogoPhilia.Entities.LanguageOfOrigin", b =>
                {
                    b.Navigation("Words");
                });

            modelBuilder.Entity("TheLogoPhilia.Entities.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("TheLogoPhilia.Entities.User", b =>
                {
                    b.Navigation("ApplicationAdministrator");

                    b.Navigation("ApplicationUser");

                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
