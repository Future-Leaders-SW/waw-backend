using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WAW.API.Auth.Authorization.Attributes;
using WAW.API.Cvs.Domain.Models;
using WAW.API.Cvs.Domain.Services;
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

  [HttpPost]
  [ProducesResponseType(typeof(CvResource), 200)]
  [ProducesResponseType(typeof(List<string>), 400)]
  [ProducesResponseType(500)]
  [SwaggerResponse(200, "The cv was created successfully", typeof(CvResource))]
  [SwaggerResponse(400, "The cv data is invalid")]
  public async Task<IActionResult> Post(IFormFile? file)
  {
    if (file == null || file.Length == 0) return BadRequest("No file uploaded");

    // Convert the file to a byte array
    using var memoryStream = new MemoryStream();
    await file.CopyToAsync(memoryStream);

    // Create a new Cv
    var cv = new Cv
    {
      Title = file.FileName,
      Data = memoryStream.ToArray()
    };

    // Use your CvService to create the new Cv
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
