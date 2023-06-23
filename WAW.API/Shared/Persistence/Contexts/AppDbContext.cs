using Microsoft.EntityFrameworkCore;
using WAW.API.Auth.Domain.Models;
using WAW.API.Job.Domain.Models;
using WAW.API.Chat.Domain.Models;
using WAW.API.Cvs.Domain.Models;
using WAW.API.Shared.Extensions;
using WAW.API.Subscriptions.Domain.Models;
using WAW.API.Companies.Domain.Models;
using WAW.API.ItProfessionals.Domain.Models;
using WAW.API.JobPostScores.Domain.Models;
using WAW.API.Recruiters.Domain.Models;
using WAW.API.Shared.Domain.Model;

namespace WAW.API.Shared.Persistence.Contexts;

public class AppDbContext : DbContext {
  private DbSet<Offer>? offers;
  private DbSet<User>? users;
  private DbSet<Company>? companies;
  private DbSet<ChatRoom>? chatRooms;
  private DbSet<Cv>? cvs;
  private DbSet<Message>? messages;
  private DbSet<ExternalImage>? images;
  private DbSet<UserEducation>? userEducation;
  private DbSet<UserExperience>? userExperience;
  private DbSet<UserProject>? userProject;
  private DbSet<Subscription>? subscriptions;
  private DbSet<PlanSubscription>? planSubscriptions;
  private DbSet<Ubigeo>? ubigeos;
  private DbSet<ItProfessional>? itProfessional;
  private DbSet<Recruiter>? recruiters;
  private DbSet<JobPostScore>? jobPostScores;

  public DbSet<Offer> Offers {
    get => GetContext(offers);
    set => offers = value;
  }

  public DbSet<User> Users {
    get => GetContext(users);
    set => users = value;
  }

  public DbSet<Company> Companies {
    get => GetContext(companies);
    set => companies = value;
  }

  public DbSet<ChatRoom> ChatRooms {
    get => GetContext(chatRooms);
    set => chatRooms = value;
  }

  public DbSet<Cv> Cvs {
    get => GetContext(cvs);
    set => cvs = value;
  }

  public DbSet<Message> Messages {
    get => GetContext(messages);
    set => messages = value;
  }

  public DbSet<ExternalImage> Images {
    get => GetContext(images);
    set => images = value;
  }

  public DbSet<UserEducation> UserEducation {
    get => GetContext(userEducation);
    set => userEducation = value;
  }

  public DbSet<UserExperience> UserExperience {
    get => GetContext(userExperience);
    set => userExperience = value;
  }

  public DbSet<UserProject> UserProject {
    get => GetContext(userProject);
    set => userProject = value;
  }

  public DbSet<Subscription> Subscriptions {
    get => GetContext(subscriptions);
    set => subscriptions = value;
  }
  public DbSet<PlanSubscription> PlanSubscriptions {
    get => GetContext(planSubscriptions);
    set => planSubscriptions = value;
  }

  public DbSet<Ubigeo> Ubigeos {
    get => GetContext(ubigeos);
    set => ubigeos = value;
  }

  public DbSet<ItProfessional> ItProfessionals {
    get => GetContext(itProfessional);
    set => itProfessional = value;
  }

  public DbSet<Recruiter> Recruiters {
    get => GetContext(recruiters);
    set => recruiters = value;
  }

  public DbSet<JobPostScore> JobPostScores {
    get => GetContext(jobPostScores);
    set => jobPostScores = value;
  }

  public AppDbContext(DbContextOptions options) : base(options) {}

  protected override void OnModelCreating(ModelBuilder builder) {
    base.OnModelCreating(builder);

    var chatRoomEntity = builder.Entity<ChatRoom>();
    chatRoomEntity.ToTable("ChatRoom");
    chatRoomEntity.HasKey(p => p.Id);
    chatRoomEntity.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
    chatRoomEntity.Property(p => p.CreationDate).IsRequired();
    chatRoomEntity.Property(p => p.LastUpdateDate).IsRequired();
    chatRoomEntity.HasMany(p => p.Messages).WithOne(p => p.ChatRoom).HasForeignKey(p => p.ChatRoomId);
    chatRoomEntity.HasMany(p => p.Messages).WithOne(p => p.ChatRoom).HasForeignKey(p => p.ChatRoomId);

    var cvEntity = builder.Entity<Cv>();
    cvEntity.ToTable("Cvs");
    cvEntity.HasKey(p => p.Id);
    cvEntity.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
    cvEntity.Property(p => p.Title).IsRequired().HasMaxLength(256);
    cvEntity.Property(p => p.Data).IsRequired();

    var messageEntity = builder.Entity<Message>();
    messageEntity.ToTable("Message");
    messageEntity.HasKey(p => p.Id);
    messageEntity.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
    messageEntity.Property(p => p.Content).IsRequired().HasMaxLength(512);
    messageEntity.Property(p => p.Date).IsRequired();

    var offerEntity = builder.Entity<Offer>();
    offerEntity.ToTable("Offers");
    offerEntity.HasKey(p => p.Id);
    offerEntity.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
    offerEntity.Property(p => p.Title).IsRequired().HasMaxLength(256);
    offerEntity.Property(p => p.Image).HasMaxLength(2048);
    offerEntity.Property(p => p.Description).IsRequired();
    offerEntity.Property(p => p.Status).IsRequired();
    offerEntity.Property(p => p.MinSalary).IsRequired();
    offerEntity.Property(p => p.MaxSalary).IsRequired();

    var userEntity = builder.Entity<User>();
    userEntity.ToTable("Users");
    userEntity.HasKey(p => p.Id);
    userEntity.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
    userEntity.Property(p => p.FullName).IsRequired().HasMaxLength(256);
    userEntity.Property(p => p.PreferredName).IsRequired().HasMaxLength(256);
    userEntity.Property(p => p.Email).IsRequired().HasMaxLength(254);
    userEntity.Property(p => p.ProfileViews).HasDefaultValue(0);
    userEntity.Property(p => p.Birthdate).IsRequired();
    userEntity.Property(p => p.Password).IsRequired().HasMaxLength(60);
    userEntity.Property(p => p.UserType).IsRequired();
    userEntity.HasMany(p => p.ChatRooms).WithMany(p => p.Participants);
    userEntity.HasMany(p => p.Education).WithOne(p => p.User).HasForeignKey(p => p.UserId).IsRequired();
    userEntity.HasMany(p => p.Experience).WithOne(p => p.User).HasForeignKey(p => p.UserId).IsRequired();
    userEntity.HasMany(p => p.Projects).WithOne(p => p.User).HasForeignKey(p => p.UserId).IsRequired();
    userEntity.HasOne(p => p.Cover).WithOne().HasForeignKey<User>(p => p.CoverId);
    userEntity.HasOne(p => p.Picture).WithOne().HasForeignKey<User>(p => p.PictureId);
    userEntity.HasOne(p => p.Ubigeo).WithOne().HasForeignKey<User>(p => p.UbigeoId);
    


    var educationEntity = builder.Entity<UserEducation>();
    educationEntity.ToTable("UserEducation");
    educationEntity.HasKey(p => p.Id);
    educationEntity.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
    educationEntity.Property(p => p.University).IsRequired().HasMaxLength(200);
    educationEntity.Property(p => p.Description).IsRequired().HasMaxLength(500);
    educationEntity.Property(p => p.StartYear).IsRequired();
    educationEntity.Property(p => p.EndYear).IsRequired();
    educationEntity.HasOne(p => p.Image).WithOne().HasForeignKey<UserEducation>(p => p.ImageId);

    var experienceEntity = builder.Entity<UserExperience>();
    experienceEntity.ToTable("UserExperience");
    experienceEntity.HasKey(p => p.Id);
    experienceEntity.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
    experienceEntity.Property(p => p.Title).IsRequired().HasMaxLength(256);
    experienceEntity.Property(p => p.Location).IsRequired().HasMaxLength(100);
    experienceEntity.Property(p => p.StartDate).IsRequired();
    experienceEntity.Property(p => p.EndDate).IsRequired();
    experienceEntity.Property(p => p.TimeDiff).IsRequired().HasMaxLength(100);
    experienceEntity.Property(p => p.Description).IsRequired().HasMaxLength(5000);
    experienceEntity.HasOne(p => p.Image).WithOne().HasForeignKey<UserExperience>(p => p.ImageId);
    experienceEntity.HasOne(p => p.Company).WithOne().HasForeignKey<UserExperience>(p => p.CompanyId);

    var projectsEntity = builder.Entity<UserProject>();
    projectsEntity.ToTable("UserProject");
    projectsEntity.HasKey(p => p.Id);
    projectsEntity.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
    projectsEntity.Property(p => p.Title).IsRequired().HasMaxLength(100);
    projectsEntity.Property(p => p.Summary).IsRequired().HasMaxLength(500);
    projectsEntity.Property(p => p.Date).IsRequired();
    projectsEntity.HasOne(p => p.Image).WithOne().HasForeignKey<UserProject>(p => p.ImageId);

    var imageEntity = builder.Entity<ExternalImage>();
    imageEntity.ToTable("Images");
    imageEntity.HasKey(p => p.Id);
    imageEntity.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
    imageEntity.Property(p => p.Href).IsRequired().HasMaxLength(2000);
    imageEntity.Property(p => p.Alt).HasMaxLength(100);

    var companyEntity = builder.Entity<Company>();
    companyEntity.ToTable("Companies");
    companyEntity.HasKey(p => p.Id);
    companyEntity.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
    companyEntity.Property(p => p.Name).IsRequired().HasMaxLength(100);
    companyEntity.Property(p => p.Address).HasMaxLength(256);
    companyEntity.Property(p => p.Email).IsRequired().HasMaxLength(256);

    var subscriptionEntity = builder.Entity<Subscription>();
    subscriptionEntity.ToTable("Subscriptions");
    subscriptionEntity.HasKey(p => p.Id);
    subscriptionEntity.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
    subscriptionEntity.Property(p => p.NamePlan).IsRequired().HasMaxLength(100);
    subscriptionEntity.Property(p=> p.Description).IsRequired().HasMaxLength(100);
    subscriptionEntity.Property(p => p.Duration).IsRequired();
    subscriptionEntity.Property(P=> P.Cost).IsRequired();
    subscriptionEntity.Property(P => P.Items).IsRequired();
    subscriptionEntity.Property(P => P.SubscriptionType).IsRequired();

    var planSubscriptionEntity = builder.Entity<PlanSubscription>();
    planSubscriptionEntity.ToTable("PlanSubscriptions");
    planSubscriptionEntity.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
    planSubscriptionEntity.Property(p => p.StartDate).IsRequired();
    planSubscriptionEntity.Property(p => p.EndDate).IsRequired();
    planSubscriptionEntity.Property(p => p.PayedAmount).IsRequired();
    planSubscriptionEntity.Property(p => p.PayedDate).IsRequired();

    builder.Entity<PlanSubscription>()
    .HasKey(bc => new { bc.UserId, bc.SubscriptionId, bc.Id });

    builder.Entity<PlanSubscription>()
    .HasOne(bc => bc.User)
    .WithMany(b => b.PlanSubscriptions)
    .HasForeignKey(bc => bc.UserId);

    builder.Entity<PlanSubscription>()
    .HasOne(bc => bc.Subscription)
    .WithMany(c => c.PlanSubscriptions)
    .HasForeignKey(bc => bc.SubscriptionId);



    var ubigeoEntity = builder.Entity<Ubigeo>();
    ubigeoEntity.ToTable("Ubigeos");
    ubigeoEntity.HasKey(p => p.Id);
    ubigeoEntity.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
    ubigeoEntity.Property(p => p.Departamento).IsRequired().HasMaxLength(50);
    ubigeoEntity.Property(p => p.Provincia).IsRequired().HasMaxLength(50);
    ubigeoEntity.Property(p => p.Distrito).IsRequired().HasMaxLength(50);

    var itProfessionalEntity = builder.Entity<ItProfessional>();
    itProfessionalEntity.ToTable("ItProfessionals");
    itProfessionalEntity.HasKey(p => p.Id);
    itProfessionalEntity.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
    itProfessionalEntity.Property(p => p.UserId).IsRequired();
    itProfessionalEntity.Property(p => p.CvId).IsRequired();
    itProfessionalEntity.HasOne(p => p.User).WithOne().HasForeignKey<ItProfessional>(p => p.UserId).OnDelete(DeleteBehavior.Cascade);
    itProfessionalEntity.HasOne(p => p.Cv).WithOne().HasForeignKey<ItProfessional>(p => p.CvId).OnDelete(DeleteBehavior.Cascade);


    var recruiterEntity = builder.Entity<Recruiter>();
    recruiterEntity.ToTable("Recruiters");
    recruiterEntity.HasKey(p => p.Id);
    recruiterEntity.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
    recruiterEntity.Property(p=>p.UserId).IsRequired();
    recruiterEntity.Property(p=>p.CompanyId).IsRequired();
    recruiterEntity.HasOne(p => p.User).WithOne().HasForeignKey<Recruiter>(p => p.UserId).OnDelete(DeleteBehavior.Cascade);
    recruiterEntity.HasOne(p => p.Company).WithOne().HasForeignKey<Recruiter>(p => p.CompanyId).OnDelete(DeleteBehavior.Cascade);

    var jobPotScoreEntity = builder.Entity<JobPostScore>();
    jobPotScoreEntity.ToTable("JobPostScores");
    jobPotScoreEntity.HasKey(p => p.Id);
    jobPotScoreEntity.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
    jobPotScoreEntity.Property(p=>p.JobOfferId).IsRequired();
    jobPotScoreEntity.Property(p=>p.ItProfessionalId).IsRequired();
    jobPotScoreEntity.HasOne(p => p.JobOffer).WithOne().HasForeignKey<JobPostScore>(p => p.JobOfferId).OnDelete(DeleteBehavior.Cascade);
    jobPotScoreEntity.HasOne(p => p.ItProfessional).WithOne().HasForeignKey<JobPostScore>(p => p.ItProfessionalId).OnDelete(DeleteBehavior.Cascade);



    builder.UseSnakeCase();
  }

  private static T GetContext<T>(T? ctx) {
    if (ctx == null) throw new NullReferenceException();
    return ctx;
  }
}
