﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WAW.API.Shared.Persistence.Contexts;

#nullable disable

namespace WAW.API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230603203654_PlanSubscription")]
    partial class PlanSubscription
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ChatRoomUser", b =>
                {
                    b.Property<long>("ChatRoomsId")
                        .HasColumnType("bigint")
                        .HasColumnName("chat_rooms_id");

                    b.Property<long>("ParticipantsId")
                        .HasColumnType("bigint")
                        .HasColumnName("participants_id");

                    b.HasKey("ChatRoomsId", "ParticipantsId")
                        .HasName("p_k_chat_room_user");

                    b.HasIndex("ParticipantsId")
                        .HasDatabaseName("i_x_chat_room_user_participants_id");

                    b.ToTable("chat_room_user");
                });

            modelBuilder.Entity("WAW.API.Auth.Domain.Models.ExternalImage", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<string>("Alt")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("alt");

                    b.Property<string>("Href")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("varchar(2000)")
                        .HasColumnName("href");

                    b.HasKey("Id")
                        .HasName("p_k_images");

                    b.ToTable("images", (string)null);
                });

            modelBuilder.Entity("WAW.API.Auth.Domain.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<string>("About")
                        .HasColumnType("longtext")
                        .HasColumnName("about");

                    b.Property<string>("Biography")
                        .HasColumnType("longtext")
                        .HasColumnName("biography");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("birthdate");

                    b.Property<long?>("CoverId")
                        .HasColumnType("bigint")
                        .HasColumnName("cover_id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(254)
                        .HasColumnType("varchar(254)")
                        .HasColumnName("email");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("full_name");

                    b.Property<string>("Location")
                        .HasColumnType("longtext")
                        .HasColumnName("location");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)")
                        .HasColumnName("password");

                    b.Property<long?>("PictureId")
                        .HasColumnType("bigint")
                        .HasColumnName("picture_id");

                    b.Property<string>("PreferredName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("preferred_name");

                    b.Property<int>("ProfileViews")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0)
                        .HasColumnName("profile_views");

                    b.HasKey("Id")
                        .HasName("p_k_users");

                    b.HasIndex("CoverId")
                        .IsUnique()
                        .HasDatabaseName("i_x_users_cover_id");

                    b.HasIndex("PictureId")
                        .IsUnique()
                        .HasDatabaseName("i_x_users_picture_id");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("WAW.API.Auth.Domain.Models.UserEducation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)")
                        .HasColumnName("description");

                    b.Property<int>("EndYear")
                        .HasColumnType("int")
                        .HasColumnName("end_year");

                    b.Property<long?>("ImageId")
                        .HasColumnType("bigint")
                        .HasColumnName("image_id");

                    b.Property<int>("StartYear")
                        .HasColumnType("int")
                        .HasColumnName("start_year");

                    b.Property<string>("University")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("university");

                    b.Property<long?>("UserId")
                        .IsRequired()
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("p_k_user_education");

                    b.HasIndex("ImageId")
                        .IsUnique()
                        .HasDatabaseName("i_x_user_education_image_id");

                    b.HasIndex("UserId")
                        .HasDatabaseName("i_x_user_education_user_id");

                    b.ToTable("user_education", (string)null);
                });

            modelBuilder.Entity("WAW.API.Auth.Domain.Models.UserExperience", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<long?>("CompanyId")
                        .HasColumnType("bigint")
                        .HasColumnName("company_id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("varchar(5000)")
                        .HasColumnName("description");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("end_date");

                    b.Property<long?>("ImageId")
                        .HasColumnType("bigint")
                        .HasColumnName("image_id");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("location");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("start_date");

                    b.Property<string>("TimeDiff")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("time_diff");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("title");

                    b.Property<long?>("UserId")
                        .IsRequired()
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("p_k_user_experience");

                    b.HasIndex("CompanyId")
                        .IsUnique()
                        .HasDatabaseName("i_x_user_experience_company_id");

                    b.HasIndex("ImageId")
                        .IsUnique()
                        .HasDatabaseName("i_x_user_experience_image_id");

                    b.HasIndex("UserId")
                        .HasDatabaseName("i_x_user_experience_user_id");

                    b.ToTable("user_experience", (string)null);
                });

            modelBuilder.Entity("WAW.API.Auth.Domain.Models.UserProject", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date");

                    b.Property<long?>("ImageId")
                        .HasColumnType("bigint")
                        .HasColumnName("image_id");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)")
                        .HasColumnName("summary");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("title");

                    b.Property<long?>("UserId")
                        .IsRequired()
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("p_k_user_project");

                    b.HasIndex("ImageId")
                        .IsUnique()
                        .HasDatabaseName("i_x_user_project_image_id");

                    b.HasIndex("UserId")
                        .HasDatabaseName("i_x_user_project_user_id");

                    b.ToTable("user_project", (string)null);
                });

            modelBuilder.Entity("WAW.API.Chat.Domain.Models.ChatRoom", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("creation_date");

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("last_update_date");

                    b.HasKey("Id")
                        .HasName("p_k_chat_room");

                    b.ToTable("chat_room", (string)null);
                });

            modelBuilder.Entity("WAW.API.Chat.Domain.Models.Message", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<long>("ChatRoomId")
                        .HasColumnType("bigint")
                        .HasColumnName("chat_room_id");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("varchar(512)")
                        .HasColumnName("content");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date");

                    b.Property<long>("SenderId")
                        .HasColumnType("bigint")
                        .HasColumnName("sender_id");

                    b.HasKey("Id")
                        .HasName("p_k_message");

                    b.HasIndex("ChatRoomId")
                        .HasDatabaseName("i_x_message_chat_room_id");

                    b.HasIndex("SenderId")
                        .HasDatabaseName("i_x_message_sender_id");

                    b.ToTable("message", (string)null);
                });

            modelBuilder.Entity("WAW.API.Employers.Domain.Models.Company", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<string>("Address")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("address");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("p_k_companies");

                    b.ToTable("companies", (string)null);
                });

            modelBuilder.Entity("WAW.API.Job.Domain.Models.Offer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("description");

                    b.Property<string>("Image")
                        .HasMaxLength(2048)
                        .HasColumnType("varchar(2048)")
                        .HasColumnName("image");

                    b.Property<string>("SalaryRange")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("salary_range");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("status");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("p_k_offers");

                    b.ToTable("offers", (string)null);
                });

            modelBuilder.Entity("WAW.API.Subscriptions.Domain.Models.PlanSubscription", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.Property<long>("SubscriptionId")
                        .HasColumnType("bigint")
                        .HasColumnName("subscription_id");

                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("end_date");

                    b.Property<float>("PayedAmount")
                        .HasColumnType("float")
                        .HasColumnName("payed_amount");

                    b.Property<DateTime>("PayedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("payed_date");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("start_date");

                    b.HasKey("UserId", "SubscriptionId", "Id")
                        .HasName("p_k_plan_subscriptions");

                    b.HasIndex("SubscriptionId")
                        .HasDatabaseName("i_x_plan_subscriptions_subscription_id");

                    b.ToTable("plan_subscriptions", (string)null);
                });

            modelBuilder.Entity("WAW.API.Subscriptions.Domain.Models.Subscription", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<float>("Cost")
                        .HasColumnType("float")
                        .HasColumnName("cost");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("description");

                    b.Property<int>("Duration")
                        .HasColumnType("int")
                        .HasColumnName("duration");

                    b.Property<string>("NamePlan")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("name_plan");

                    b.HasKey("Id")
                        .HasName("p_k_subscriptions");

                    b.ToTable("subscriptions", (string)null);
                });

            modelBuilder.Entity("ChatRoomUser", b =>
                {
                    b.HasOne("WAW.API.Chat.Domain.Models.ChatRoom", null)
                        .WithMany()
                        .HasForeignKey("ChatRoomsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("f_k_chat_room_user__chat_room_chat_rooms_id");

                    b.HasOne("WAW.API.Auth.Domain.Models.User", null)
                        .WithMany()
                        .HasForeignKey("ParticipantsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("f_k_chat_room_user__users_participants_id");
                });

            modelBuilder.Entity("WAW.API.Auth.Domain.Models.User", b =>
                {
                    b.HasOne("WAW.API.Auth.Domain.Models.ExternalImage", "Cover")
                        .WithOne()
                        .HasForeignKey("WAW.API.Auth.Domain.Models.User", "CoverId")
                        .HasConstraintName("f_k_users_images_cover_id");

                    b.HasOne("WAW.API.Auth.Domain.Models.ExternalImage", "Picture")
                        .WithOne()
                        .HasForeignKey("WAW.API.Auth.Domain.Models.User", "PictureId")
                        .HasConstraintName("f_k_users_images_picture_id");

                    b.Navigation("Cover");

                    b.Navigation("Picture");
                });

            modelBuilder.Entity("WAW.API.Auth.Domain.Models.UserEducation", b =>
                {
                    b.HasOne("WAW.API.Auth.Domain.Models.ExternalImage", "Image")
                        .WithOne()
                        .HasForeignKey("WAW.API.Auth.Domain.Models.UserEducation", "ImageId")
                        .HasConstraintName("f_k_user_education_images_image_id");

                    b.HasOne("WAW.API.Auth.Domain.Models.User", "User")
                        .WithMany("Education")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("f_k_user_education_users_user_id");

                    b.Navigation("Image");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WAW.API.Auth.Domain.Models.UserExperience", b =>
                {
                    b.HasOne("WAW.API.Employers.Domain.Models.Company", "Company")
                        .WithOne()
                        .HasForeignKey("WAW.API.Auth.Domain.Models.UserExperience", "CompanyId")
                        .HasConstraintName("f_k_user_experience__companies_company_id");

                    b.HasOne("WAW.API.Auth.Domain.Models.ExternalImage", "Image")
                        .WithOne()
                        .HasForeignKey("WAW.API.Auth.Domain.Models.UserExperience", "ImageId")
                        .HasConstraintName("f_k_user_experience_images_image_id");

                    b.HasOne("WAW.API.Auth.Domain.Models.User", "User")
                        .WithMany("Experience")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("f_k_user_experience_users_user_id");

                    b.Navigation("Company");

                    b.Navigation("Image");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WAW.API.Auth.Domain.Models.UserProject", b =>
                {
                    b.HasOne("WAW.API.Auth.Domain.Models.ExternalImage", "Image")
                        .WithOne()
                        .HasForeignKey("WAW.API.Auth.Domain.Models.UserProject", "ImageId")
                        .HasConstraintName("f_k_user_project_images_image_id");

                    b.HasOne("WAW.API.Auth.Domain.Models.User", "User")
                        .WithMany("Projects")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("f_k_user_project_users_user_id");

                    b.Navigation("Image");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WAW.API.Chat.Domain.Models.Message", b =>
                {
                    b.HasOne("WAW.API.Chat.Domain.Models.ChatRoom", "ChatRoom")
                        .WithMany("Messages")
                        .HasForeignKey("ChatRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("f_k_message_chat_room_chat_room_id");

                    b.HasOne("WAW.API.Auth.Domain.Models.User", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("f_k_message_users_sender_id");

                    b.Navigation("ChatRoom");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("WAW.API.Subscriptions.Domain.Models.PlanSubscription", b =>
                {
                    b.HasOne("WAW.API.Subscriptions.Domain.Models.Subscription", "Subscription")
                        .WithMany("PlanSubscriptions")
                        .HasForeignKey("SubscriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("f_k_plan_subscriptions__subscriptions_subscription_id");

                    b.HasOne("WAW.API.Auth.Domain.Models.User", "User")
                        .WithMany("PlanSubscriptions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("f_k_plan_subscriptions_users_user_id");

                    b.Navigation("Subscription");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WAW.API.Auth.Domain.Models.User", b =>
                {
                    b.Navigation("Education");

                    b.Navigation("Experience");

                    b.Navigation("PlanSubscriptions");

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("WAW.API.Chat.Domain.Models.ChatRoom", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("WAW.API.Subscriptions.Domain.Models.Subscription", b =>
                {
                    b.Navigation("PlanSubscriptions");
                });
#pragma warning restore 612, 618
        }
    }
}
