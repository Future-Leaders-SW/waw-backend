using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;
using WAW.API.JobPostScores.Domain.Models;
using WAW.API.JobPostScores.Domain.Services;
using WAW.API.JobPostScores.Resources;
using WAW.API.Auth.Authorization.Attributes;
using WAW.API.Shared.Extensions;

namespace WAW.API.JobPostScores.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Create, read, update and delete JobPostScores")]
public class JobPostScoreController : ControllerBase{

  private readonly IJobPostScoreService service;
  private readonly IMapper mapper;

  public JobPostScoreController(IJobPostScoreService service, IMapper mapper) {
    this.service = service;
    this.mapper = mapper;
  }

  [HttpGet]
  [ProducesResponseType(typeof(IEnumerable<JobPostScoreResource>), 200)]
  [SwaggerResponse(200, "All the stored jobPostScores were retrieved successfully.", typeof(IEnumerable<JobPostScoreResource>))]
  public async Task<IEnumerable<JobPostScoreResource>> GetAll() {
    var jobPostScores = await service.ListAll();
    return mapper.Map<IEnumerable<JobPostScore>, IEnumerable<JobPostScoreResource>>(jobPostScores);
  }

  [HttpPost]
  [ProducesResponseType(typeof(JobPostScoreResource), 200)]
  [ProducesResponseType(typeof(List<string>), 400)]
  [ProducesResponseType(500)]
  [SwaggerResponse(200, "The jobPostScore was created successfully", typeof(JobPostScoreResource))]
  [SwaggerResponse(400, "The jobPostScore data is invalid")]
  public async Task<IActionResult> Post([FromBody] JobPostScoreRequest resource) {
    if (!ModelState.IsValid)
      return BadRequest(ModelState.GetErrorMessages());

    var jobPostScore = mapper.Map<JobPostScoreRequest, JobPostScore>(resource);
    var result = await service.Create(jobPostScore);
    return result.ToResponse<JobPostScoreResource>(this, mapper);
  }

  [HttpPut("{id:int}")]
  [ProducesResponseType(typeof(JobPostScoreResource), 200)]
  [ProducesResponseType(typeof(List<string>), 400)]
  [ProducesResponseType(500)]
  [SwaggerResponse(200, "The jobPostScore was updated successfully", typeof(JobPostScoreResource))]
  [SwaggerResponse(400, "The jobPostScore data is invalid")]
  public async Task<IActionResult> Put(
    [FromRoute][SwaggerParameter("JobPostScore identifier", Required = true)] int id,
    [FromBody] JobPostScoreRequest resource
  ) {
    if (!ModelState.IsValid)
      return BadRequest(ModelState.GetErrorMessages());

    var jobPostScore = mapper.Map<JobPostScoreRequest, JobPostScore>(resource);
    var result = await service.Update(id, jobPostScore);
    return result.ToResponse<JobPostScoreResource>(this, mapper);
  }

  [HttpDelete("{id:int}")]
  [ProducesResponseType(typeof(NoContentResult), 204)]
  [ProducesResponseType(typeof(List<string>), 400)]
  [ProducesResponseType(500)]
  [SwaggerResponse(204, "The jobPostScore was deleted successfully", typeof(NoContentResult))]
  [SwaggerResponse(400, "The selected jobPostScore to delete does not exist")]
  public async Task<IActionResult> DeleteAsync(
    [FromRoute][SwaggerParameter("JobPostScore identifier", Required = true)] int id
  ) {
    await service.Delete(id);
    return NoContent();
  }

}
