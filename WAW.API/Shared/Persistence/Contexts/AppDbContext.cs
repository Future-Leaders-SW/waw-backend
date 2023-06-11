using Microsoft.EntityFrameworkCore;
using WAW.API.Auth.Domain.Models;
using WAW.API.Companies.Domain.Models;
using WAW.API.Job.Domain.Models;
using WAW.API.Cvs.Domain.Models;
using WAW.API.ITProfessionals.Domain.Models;
using WAW.API.JobPostScores.Domain.Models;
using WAW.API.Recruiters.Domain.Models;
using WAW.API.Shared.Domain.Model;
using WAW.API.Shared.Extensions;
using WAW.API.Subscriptions.Domain.Models;

namespace WAW.API.Shared.Persistence.Contexts;

public class AppDbContext : DbContext {
  private DbSet<Offer>? offers;
  private DbSet<User>? users;
  private DbSet<Company>? companies;
  private DbSet<Cv>? cvs;
  private DbSet<Subscription>? subscriptions;
  private DbSet<PlanSubscription>? planSubscriptions;
  private DbSet<Ubigeo>? ubigeos;
  private DbSet<ITProfessional>? iTProfessionals;
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

  public DbSet<Cv> Cvs {
    get => GetContext(cvs);
    set => cvs = value;
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

  public DbSet<ITProfessional> ITProfessionals {
    get => GetContext(iTProfessionals);
    set => iTProfessionals = value;
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

    var cvEntity = builder.Entity<Cv>();
    cvEntity.ToTable("Cvs");
    cvEntity.HasKey(p => p.Id);
    cvEntity.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
    cvEntity.Property(p => p.Title).IsRequired().HasMaxLength(256);
    cvEntity.Property(p => p.Data).IsRequired();

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
    //userEntity.HasOne(p => p.Cv).WithOne(p=>p.User).HasForeignKey<Cv>(p => p.UserId).OnDelete(DeleteBehavior.Cascade);
    userEntity.HasOne(p => p.Ubigeo).WithMany();

    var companyEntity = builder.Entity<Company>();
    companyEntity.ToTable("Companies");
    companyEntity.HasKey(p => p.Id);
    companyEntity.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
    companyEntity.Property(p => p.Name).IsRequired().HasMaxLength(100);

    var subscriptionEntity = builder.Entity<Subscription>();
    subscriptionEntity.ToTable("Subscriptions");
    subscriptionEntity.HasKey(p => p.Id);
    subscriptionEntity.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
    subscriptionEntity.Property(p => p.NamePlan).IsRequired().HasMaxLength(100);
    subscriptionEntity.Property(p=> p.Description).IsRequired().HasMaxLength(100);
    subscriptionEntity.Property(p => p.Duration).IsRequired();
    subscriptionEntity.Property(P=> P.Cost).IsRequired();
    subscriptionEntity.Property(P => P.Items).IsRequired();

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

    var itProfessionalEntity = builder.Entity<ITProfessional>();
    itProfessionalEntity.ToTable("ITProfessionals");
    itProfessionalEntity.HasKey(p => p.Id);
    itProfessionalEntity.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
    itProfessionalEntity.Property(p => p.UserId).IsRequired();
    itProfessionalEntity.Property(p => p.CvId).IsRequired();
    itProfessionalEntity.HasOne(p => p.User).WithOne().HasForeignKey<ITProfessional>(p => p.UserId).OnDelete(DeleteBehavior.Cascade);
    itProfessionalEntity.HasOne(p => p.Cv).WithOne().HasForeignKey<ITProfessional>(p => p.CvId).OnDelete(DeleteBehavior.Cascade);


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
    jobPotScoreEntity.Property(p=>p.ITProfessionalId).IsRequired();
    jobPotScoreEntity.HasOne(p => p.JobOffer).WithOne().HasForeignKey<JobPostScore>(p => p.JobOfferId).OnDelete(DeleteBehavior.Cascade);
    jobPotScoreEntity.HasOne(p => p.ITProfessional).WithOne().HasForeignKey<JobPostScore>(p => p.ITProfessionalId).OnDelete(DeleteBehavior.Cascade);


    builder.UseSnakeCase();
  }

  private static T GetContext<T>(T? ctx) {
    if (ctx == null) throw new NullReferenceException();
    return ctx;
  }
}
