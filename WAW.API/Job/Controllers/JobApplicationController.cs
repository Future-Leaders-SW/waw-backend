using System.Net.Mime;
using AutoMapper; 
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WAW.API.Auth.Authorization.Attributes;
using WAW.API.Job.Domain.Models;
using WAW.API.Job.Domain.Services;
using WAW.API.Job.Resources;
using WAW.API.Shared.Extensions;

namespace WAW.API.Job.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Create, read, update and delete Job Applications")]
public class JobApplicationController : ControllerBase {
  private readonly IJobApplicationService service;
  private readonly IMapper mapper;

  public JobApplicationController(IJobApplicationService service, IMapper mapper) {
    this.service = service;
    this.mapper = mapper;
  }

  [HttpGet]
  [ProducesResponseType(typeof(IEnumerable<JobApplicationResource>), 200)]
  [SwaggerResponse(200, "All the stored job applications were retrieved successfully.", typeof(IEnumerable<JobApplicationResource>))]
  public async Task<IEnumerable<JobApplicationResource>> GetAll() {
    var jobApplications = await service.ListAll();
    return mapper.Map<IEnumerable<JobApplication>, IEnumerable<JobApplicationResource>>(jobApplications);
  }


  [HttpGet("/{userId}/offers")]
  [ProducesResponseType(typeof(IEnumerable<OfferResource>), 200)]
  [SwaggerResponse(200, "All the offers associated with the user were retrieved successfully.", typeof(IEnumerable<OfferResource>))]
  public async Task<IActionResult> GetOffersByUserId(long userId) {
    
    var offers = await service.GetOffersByUserId(userId);
    var offerResources = mapper.Map<IEnumerable<Offer>, IEnumerable<OfferResource>>(offers);
    return Ok(offerResources);

  }


  [HttpPost]
  [ProducesResponseType(typeof(JobApplicationResource), 200)]
  [ProducesResponseType(typeof(List<string>), 400)]
  [ProducesResponseType(500)]
  [SwaggerResponse(200, "The job application was created successfully", typeof(JobApplicationResource))]
  [SwaggerResponse(400, "The job application data is invalid")]
  public async Task<IActionResult> Post([FromBody] JobApplicationRequest resource) {
    if (!ModelState.IsValid)
      return BadRequest(ModelState.GetErrorMessages());

    var jobApplication = mapper.Map<JobApplicationRequest, JobApplication>(resource);
    var result = await service.Create(jobApplication);
    return result.ToResponse<JobApplicationResource>(this, mapper);
  }
}
