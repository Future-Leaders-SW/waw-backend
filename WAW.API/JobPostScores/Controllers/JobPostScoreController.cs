using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;
using WAW.API.JobPostScores.Domain.Models;
using WAW.API.JobPostScores.Domain.Services;
using WAW.API.JobPostScores.Resources;
using WAW.API.Auth.Authorization.Attributes;
using WAW.API.Auth.Domain.Services;
using WAW.API.Cvs.Domain.Services;
using WAW.API.Job.Domain.Models;
using WAW.API.Shared.Extensions;
using WAW.API.Job.Domain.Services;
using WAW.API.Job.Resources;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace WAW.API.JobPostScores.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Create, read, update and delete JobPostScores")]
public class JobPostScoreController : ControllerBase{

  private readonly IJobPostScoreService service;
  private readonly IMapper mapper;
  private readonly IOfferService offerService;
  private readonly IUserService userService;
  private readonly ICvService cvService;


  public JobPostScoreController(IJobPostScoreService service, IOfferService offerService, IMapper mapper, IUserService userService, ICvService cvService) {
    this.service = service;
    this.mapper = mapper;
    this.offerService = offerService;
    this.userService = userService;
    this.cvService = cvService;
  }

  [HttpGet]
  [ProducesResponseType(typeof(IEnumerable<JobPostScoreResource>), 200)]
  [SwaggerResponse(200, "All the stored jobPostScores were retrieved successfully.", typeof(IEnumerable<JobPostScoreResource>))]
  public async Task<IEnumerable<JobPostScoreResource>> GetAll() {
    var jobPostScores = await service.ListAll();
    return mapper.Map<IEnumerable<JobPostScore>, IEnumerable<JobPostScoreResource>>(jobPostScores);
  }
  
  [HttpGet("/{userId}")]
  [ProducesResponseType(typeof(IEnumerable<JobPostScoreResource>), 200)]
  [SwaggerResponse(200, "All the stored jobPostScores were retrieved successfully.", typeof(IEnumerable<JobPostScoreResource>))]
  public async Task<IEnumerable<JobPostScoreResource>> GetAllByUserId(long userId) {
    var jobPostScores = await service.ListAllByUserId(userId);
    return mapper.Map<IEnumerable<JobPostScore>, IEnumerable<JobPostScoreResource>>(jobPostScores);
  }
  
  [HttpPost("/{userId}/scoreoffers")]
  [ProducesResponseType(typeof(IEnumerable<JobPostScoreResource>), 200)]
  [SwaggerResponse(200, "All the stored jobPostScores were retrieved successfully.", typeof(IEnumerable<JobPostScoreResource>))]
  public async Task<IEnumerable<JobPostScoreResource>> GetAllScores(long userId) {
    var cvid = await userService.GetCvIdByUserId(userId);
    var extract = await cvService.GetExtractByCvId(cvid);
    var offers = await offerService.ListAll();
    var jobPostScores = await service.ListAllByUserId(userId);
    
    if (!jobPostScores.Any())
    {
      using (var httpClient = new HttpClient())
      {
        var apiUrl = "https://nlp-api-fv-6zcqyqd5qa-uc.a.run.app/nlpservice/";
            
        foreach (var offer in offers)
        {
          var offerDescription = offer.Description;

           
          var jsonPayload = JsonConvert.SerializeObject(new
          {
            perfil_profesional = extract,
            oferta_laboral = offerDescription
          });
          
            
          var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
          var response = await httpClient.PostAsync(apiUrl, content);
         
           
          var responseJson = await response.Content.ReadAsStringAsync();
          
          var responseObj = JsonConvert.DeserializeObject<dynamic>(responseJson);
          
          double score = responseObj.score;

           
          var jobPostScore = new JobPostScoreRequest();
          jobPostScore.UserId = userId;
          jobPostScore.OfferId = offer.Id;
          jobPostScore.Score = score;
                
          await service.Create(mapper.Map<JobPostScoreRequest, JobPostScore>(jobPostScore));
        }
        jobPostScores = await service.ListAllByUserId(userId);
      }
    }
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
