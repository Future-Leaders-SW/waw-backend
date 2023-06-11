using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;
using WAW.API.ITProfessionals.Domain.Models;
using WAW.API.ITProfessionals.Domain.Services;
using WAW.API.ITProfessionals.Resources;
using WAW.API.Auth.Authorization.Attributes;
using WAW.API.Shared.Extensions;

namespace WAW.API.ITProfessionals.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Create, read, update and delete ITProfessionals")]
public class ITProfessionalController : ControllerBase{

  private readonly IITProfessionalService service;
  private readonly IMapper mapper;

  public ITProfessionalController(IITProfessionalService service, IMapper mapper) {
    this.service = service;
    this.mapper = mapper;
  }

  [HttpGet]
  [ProducesResponseType(typeof(IEnumerable<ITProfessionalResource>), 200)]
  [SwaggerResponse(200, "All the stored iTProfessionals were retrieved successfully.", typeof(IEnumerable<ITProfessionalResource>))]
  public async Task<IEnumerable<ITProfessionalResource>> GetAll() {
    var iTProfessionals = await service.ListAll();
    return mapper.Map<IEnumerable<ITProfessional>, IEnumerable<ITProfessionalResource>>(iTProfessionals);
  }

  [HttpPost]
  [ProducesResponseType(typeof(ITProfessionalResource), 200)]
  [ProducesResponseType(typeof(List<string>), 400)]
  [ProducesResponseType(500)]
  [SwaggerResponse(200, "The iTProfessional was created successfully", typeof(ITProfessionalResource))]
  [SwaggerResponse(400, "The iTProfessional data is invalid")]
  public async Task<IActionResult> Post([FromBody] ITProfessionalRequest resource) {
    if (!ModelState.IsValid)
      return BadRequest(ModelState.GetErrorMessages());

    var iTProfessional = mapper.Map<ITProfessionalRequest, ITProfessional>(resource);
    var result = await service.Create(iTProfessional);
    return result.ToResponse<ITProfessionalResource>(this, mapper);
  }

  [HttpPut("{id:int}")]
  [ProducesResponseType(typeof(ITProfessionalResource), 200)]
  [ProducesResponseType(typeof(List<string>), 400)]
  [ProducesResponseType(500)]
  [SwaggerResponse(200, "The iTProfessional was updated successfully", typeof(ITProfessionalResource))]
  [SwaggerResponse(400, "The iTProfessional data is invalid")]
  public async Task<IActionResult> Put(
    [FromRoute][SwaggerParameter("ITProfessional identifier", Required = true)] int id,
    [FromBody] ITProfessionalRequest resource
  ) {
    if (!ModelState.IsValid)
      return BadRequest(ModelState.GetErrorMessages());

    var iTProfessional = mapper.Map<ITProfessionalRequest, ITProfessional>(resource);
    var result = await service.Update(id, iTProfessional);
    return result.ToResponse<ITProfessionalResource>(this, mapper);
  }

  [HttpDelete("{id:int}")]
  [ProducesResponseType(typeof(NoContentResult), 204)]
  [ProducesResponseType(typeof(List<string>), 400)]
  [ProducesResponseType(500)]
  [SwaggerResponse(204, "The iTProfessional was deleted successfully", typeof(NoContentResult))]
  [SwaggerResponse(400, "The selected iTProfessional to delete does not exist")]
  public async Task<IActionResult> DeleteAsync(
    [FromRoute][SwaggerParameter("ITProfessional identifier", Required = true)] int id
  ) {
    await service.Delete(id);
    return NoContent();
  }

}
