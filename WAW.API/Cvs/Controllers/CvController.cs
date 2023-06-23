using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WAW.API.Auth.Authorization.Attributes;
using WAW.API.Cvs.Domain.Models;
using WAW.API.Cvs.Domain.Services;
using WAW.API.Cvs.Domain.Services.Communication;
using WAW.API.Cvs.Resources;
using WAW.API.Shared.Extensions;

namespace WAW.API.Cvs.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Create, read, update and delete Cvs")]
public class CvController : ControllerBase {
  private readonly ICvService service;
  private readonly IMapper mapper;

  public CvController(ICvService service, IMapper mapper) {
    this.service = service;
    this.mapper = mapper;
  }

  [HttpGet]
  [ProducesResponseType(typeof(IEnumerable<CvResource>), 200)]
  [SwaggerResponse(200, "All the stored Cvs were retrieved successfully.", typeof(IEnumerable<CvResource>))]
  public async Task<IEnumerable<CvResource>> GetAll() {
    var cvs = await service.ListAll();
    return mapper.Map<IEnumerable<Cv>, IEnumerable<CvResource>>(cvs);
  }

  [HttpGet("{id}")]
  [ProducesResponseType(typeof(CvResource), 200)]
  [SwaggerResponse(200, "The Cv was retrieved successfully", typeof(CvResource))]
  [SwaggerResponse(404, "The Cv was not found")]
  public async Task<IActionResult> Get(long id)
  {
    var cv = await service.GetById(id);
    return cv.ToResponse<CvResource>(this, mapper);
  }

  [HttpGet("{id}/file")]
  [SwaggerResponse(200, "The Cv file was retrieved successfully", typeof(FileContentResult))]
  [SwaggerResponse(404, "The Cv file was not found")]
  public async Task<IActionResult> GetFile(long id)
  {
    var cvResponse = await service.GetById(id);
    var cv = cvResponse.GetResource();
    if (cv == null || cv.Data == null)
    {
      return NotFound("The Cv file was not found");
    }
    return File(cv.Data, "application/pdf", cv.Title);
  }

  [HttpPost]
  [ProducesResponseType(typeof(CvResource), 200)]
  [ProducesResponseType(typeof(List<string>), 400)]
  [ProducesResponseType(500)]
  [SwaggerResponse(200, "The cv was created successfully", typeof(CvResource))]
  [SwaggerResponse(400, "The cv data is invalid")]
  public async Task<IActionResult> Post([FromForm]CvCreateModel cvCreateModel)
  {
    if (!ModelState.IsValid) return BadRequest(ModelState.GetErrorMessages());
    using var memoryStream = new MemoryStream();
    await cvCreateModel.Data.CopyToAsync(memoryStream);

    if(memoryStream.Length == 0) return BadRequest("Uploaded file is empty");

    var cv = new Cv
    {
      Title = cvCreateModel.Title,
      Data = memoryStream.ToArray(),
      Extract = cvCreateModel.Extract,
    };

    var result = await service.Create(cv);
    return result.ToResponse<CvResource>(this, mapper);
  }

  [HttpPut("{id:int}")]
  [ProducesResponseType(typeof(CvResource), 200)]
  [ProducesResponseType(typeof(List<string>), 400)]
  [ProducesResponseType(500)]
  [SwaggerResponse(200, "The cv was updated successfully", typeof(CvResource))]
  [SwaggerResponse(400, "The cv data is invalid")]
  public async Task<IActionResult> Put(
    [FromRoute] [SwaggerParameter("Cvs identifier", Required = true)] int id,
    [FromBody] CvRequest resource
  ) {
    if (!ModelState.IsValid) return BadRequest(ModelState.GetErrorMessages());

    var cv = mapper.Map<CvRequest, Cv>(resource);
    var result = await service.Update(id, cv);
    return result.ToResponse<CvResource>(this, mapper);
  }

  [HttpDelete("{id:int}")]
  [ProducesResponseType(typeof(NoContentResult), 204)]
  [ProducesResponseType(typeof(List<string>), 400)]
  [ProducesResponseType(500)]
  [SwaggerResponse(204, "The cv was deleted successfully", typeof(NoContentResult))]
  [SwaggerResponse(400, "The selected cv to delete does not exist")]
  public async Task<IActionResult> DeleteAsync(
    [FromRoute] [SwaggerParameter("Cvs identifier", Required = true)] int id
  ) {
    await service.Delete(id);
    return NoContent();
  }
}
