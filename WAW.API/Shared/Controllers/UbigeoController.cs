using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;
using WAW.API.Auth.Authorization.Attributes;
using WAW.API.Shared.Domain.Model;
using WAW.API.Shared.Domain.Service;
using WAW.API.Shared.Extensions;
using WAW.API.Shared.Resources;

namespace WAW.API.Shared.Controllers;
[Authorize]
[ApiController]
[Route("[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Create, read, update and delete Ubigeos")]
public class UbigeoController : ControllerBase {

  private readonly IUbigeoService service;
  private readonly IMapper mapper;

  public UbigeoController(IUbigeoService service, IMapper mapper) {
    this.service = service;
    this.mapper = mapper;
  }

  [HttpGet]
  [ProducesResponseType(typeof(IEnumerable<UbigeoResource>), 200)]
  [SwaggerResponse(200, "All the stored ubigeos were retrieved successfully.", typeof(IEnumerable<UbigeoResource>))]
  public async Task<IEnumerable<UbigeoResource>> GetAll() {
    var ubigeos = await service.ListAll();
    return mapper.Map<IEnumerable<Ubigeo>, IEnumerable<UbigeoResource>>(ubigeos);
  }

  [HttpPost]
  [ProducesResponseType(typeof(UbigeoResource), 200)]
  [ProducesResponseType(typeof(List<string>), 400)]
  [ProducesResponseType(500)]
  [SwaggerResponse(200, "The ubigeo was created successfully", typeof(UbigeoResource))]
  [SwaggerResponse(400, "The ubigeo data is invalid")]
  public async Task<IActionResult> Post([FromBody] UbigeoRequest resource) {
    if (!ModelState.IsValid)
      return BadRequest(ModelState.GetErrorMessages());

    var ubigeo = mapper.Map<UbigeoRequest, Ubigeo>(resource);
    var result = await service.Create(ubigeo);
    return result.ToResponse<UbigeoResource>(this, mapper);
  }

  [HttpPut("{id:int}")]
  [ProducesResponseType(typeof(UbigeoResource), 200)]
  [ProducesResponseType(typeof(List<string>), 400)]
  [ProducesResponseType(500)]
  [SwaggerResponse(200, "The ubigeo was updated successfully", typeof(UbigeoResource))]
  [SwaggerResponse(400, "The ubigeo data is invalid")]
  public async Task<IActionResult> Put(
    [FromRoute][SwaggerParameter("Ubigeo identifier", Required = true)] int id,
    [FromBody] UbigeoRequest resource
  ) {
    if (!ModelState.IsValid)
      return BadRequest(ModelState.GetErrorMessages());

    var ubigeo = mapper.Map<UbigeoRequest, Ubigeo>(resource);
    var result = await service.Update(id, ubigeo);
    return result.ToResponse<UbigeoResource>(this, mapper);
  }

  [HttpDelete("{id:int}")]
  [ProducesResponseType(typeof(NoContentResult), 204)]
  [ProducesResponseType(typeof(List<string>), 400)]
  [ProducesResponseType(500)]
  [SwaggerResponse(204, "The ubigeo was deleted successfully", typeof(NoContentResult))]
  [SwaggerResponse(400, "The selected ubigeo to delete does not exist")]
  public async Task<IActionResult> DeleteAsync(
    [FromRoute][SwaggerParameter("Ubigeo identifier", Required = true)] int id
  ) {
    await service.Delete(id);
    return NoContent();
  }

}
