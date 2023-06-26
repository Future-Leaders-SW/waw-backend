using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;
using WAW.API.ItProfessionals.Domain.Models;
using WAW.API.ItProfessionals.Domain.Services;
using WAW.API.ItProfessionals.Resources;
using WAW.API.Auth.Authorization.Attributes;
using WAW.API.Shared.Extensions;

namespace WAW.API.ItProfessionals.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Create, read, update and delete ItProfessionals")]
public class ItProfessionalController : ControllerBase{

  private readonly IItProfessionalService service;
  private readonly IMapper mapper;

  public ItProfessionalController(IItProfessionalService service, IMapper mapper) {
    this.service = service;
    this.mapper = mapper;
  }
  [ApiExplorerSettings(IgnoreApi = true)]
  [HttpGet]
  [ProducesResponseType(typeof(IEnumerable<ItProfessionalResource>), 200)]
  [SwaggerResponse(200, "All the stored iTProfessionals were retrieved successfully.", typeof(IEnumerable<ItProfessionalResource>))]
  public async Task<IEnumerable<ItProfessionalResource>> GetAll() {
    var iTProfessionals = await service.ListAll();
    return mapper.Map<IEnumerable<ItProfessional>, IEnumerable<ItProfessionalResource>>(iTProfessionals);
  }
  [ApiExplorerSettings(IgnoreApi = true)]
  [HttpPost]
  [ProducesResponseType(typeof(ItProfessionalResource), 200)]
  [ProducesResponseType(typeof(List<string>), 400)]
  [ProducesResponseType(500)]
  [SwaggerResponse(200, "The iTProfessional was created successfully", typeof(ItProfessionalResource))]
  [SwaggerResponse(400, "The iTProfessional data is invalid")]
  public async Task<IActionResult> Post([FromBody] ItProfessionalRequest resource) {
    if (!ModelState.IsValid)
      return BadRequest(ModelState.GetErrorMessages());

    var iTProfessional = mapper.Map<ItProfessionalRequest, ItProfessional>(resource);
    var result = await service.Create(iTProfessional);
    return result.ToResponse<ItProfessionalResource>(this, mapper);
  }
  [ApiExplorerSettings(IgnoreApi = true)]
  [HttpPut("{id:int}")]
  [ProducesResponseType(typeof(ItProfessionalResource), 200)]
  [ProducesResponseType(typeof(List<string>), 400)]
  [ProducesResponseType(500)]
  [SwaggerResponse(200, "The iTProfessional was updated successfully", typeof(ItProfessionalResource))]
  [SwaggerResponse(400, "The iTProfessional data is invalid")]
  public async Task<IActionResult> Put(
    [FromRoute][SwaggerParameter("ItProfessional identifier", Required = true)] int id,
    [FromBody] ItProfessionalRequest resource
  ) {
    if (!ModelState.IsValid)
      return BadRequest(ModelState.GetErrorMessages());

    var iTProfessional = mapper.Map<ItProfessionalRequest, ItProfessional>(resource);
    var result = await service.Update(id, iTProfessional);
    return result.ToResponse<ItProfessionalResource>(this, mapper);
  }
  [ApiExplorerSettings(IgnoreApi = true)]
  [HttpDelete("{id:int}")]
  [ProducesResponseType(typeof(NoContentResult), 204)]
  [ProducesResponseType(typeof(List<string>), 400)]
  [ProducesResponseType(500)]
  [SwaggerResponse(204, "The iTProfessional was deleted successfully", typeof(NoContentResult))]
  [SwaggerResponse(400, "The selected iTProfessional to delete does not exist")]
  public async Task<IActionResult> DeleteAsync(
    [FromRoute][SwaggerParameter("ItProfessional identifier", Required = true)] int id
  ) {
    await service.Delete(id);
    return NoContent();
  }

}
