using WAW.API.JobPostScores.Domain.Models;
using WAW.API.Shared.Domain.Model;

namespace WAW.API.Job.Domain.Models;

public class Offer : BaseModel {
  public string Title { get; set; } = string.Empty;
  public string? Image { get; set; }
  public string Description { get; set; } = string.Empty;
  public decimal MinSalary { get; set; }
  public decimal MaxSalary { get; set; }
  public bool Status { get; set; }
  public IList<JobApplication> JobApplications { get; set; } = new List<JobApplication>();
  public IList<JobPostScore> JobPostScores { get; set; } = new List<JobPostScore>();



}
