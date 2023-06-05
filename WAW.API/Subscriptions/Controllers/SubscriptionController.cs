using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;
using WAW.API.Shared.Extensions;
using WAW.API.Subscriptions.Domain.Models;
using WAW.API.Subscriptions.Domain.Services;
using WAW.API.Subscriptions.Resources;
using WAW.API.Auth.Authorization.Attributes;

namespace WAW.API.Subscriptions.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Create, read, update and delete Subscriptions")]
public class SubscriptionController : ControllerBase{

  private readonly ISubscriptionService service;
  private readonly IMapper mapper;

  public SubscriptionController(ISubscriptionService service, IMapper mapper) {
    this.service = service;
    this.mapper = mapper;
  }

  [HttpGet]
  [ProducesResponseType(typeof(IEnumerable<SubscriptionResource>), 200)]
  [SwaggerResponse(200, "All the stored subscriptions were retrieved successfully.", typeof(IEnumerable<SubscriptionResource>))]
  public async Task<IEnumerable<SubscriptionResource>> GetAll() {
    var subscriptions = await service.ListAll();
    return mapper.Map<IEnumerable<Subscription>, IEnumerable<SubscriptionResource>>(subscriptions);
  }

  [HttpPost]
  [ProducesResponseType(typeof(SubscriptionResource), 200)]
  [ProducesResponseType(typeof(List<string>), 400)]
  [ProducesResponseType(500)]
  [SwaggerResponse(200, "The subscription was created successfully", typeof(SubscriptionResource))]
  [SwaggerResponse(400, "The subscription data is invalid")]
  public async Task<IActionResult> Post([FromBody] SubscriptionRequest resource) {
    if (!ModelState.IsValid)
      return BadRequest(ModelState.GetErrorMessages());

    var subscription = mapper.Map<SubscriptionRequest, Subscription>(resource);
    var result = await service.Create(subscription);
    return result.ToResponse<SubscriptionResource>(this, mapper);
  }

  [HttpPut("{id:int}")]
  [ProducesResponseType(typeof(SubscriptionResource), 200)]
  [ProducesResponseType(typeof(List<string>), 400)]
  [ProducesResponseType(500)]
  [SwaggerResponse(200, "The subscription was updated successfully", typeof(SubscriptionResource))]
  [SwaggerResponse(400, "The subscription data is invalid")]
  public async Task<IActionResult> Put(
    [FromRoute][SwaggerParameter("Subscription identifier", Required = true)] int id,
    [FromBody] SubscriptionRequest resource
  ) {
    if (!ModelState.IsValid)
      return BadRequest(ModelState.GetErrorMessages());

    var subscription = mapper.Map<SubscriptionRequest, Subscription>(resource);
    var result = await service.Update(id, subscription);
    return result.ToResponse<SubscriptionResource>(this, mapper);
  }

  [HttpDelete("{id:int}")]
  [ProducesResponseType(typeof(NoContentResult), 204)]
  [ProducesResponseType(typeof(List<string>), 400)]
  [ProducesResponseType(500)]
  [SwaggerResponse(204, "The subscription was deleted successfully", typeof(NoContentResult))]
  [SwaggerResponse(400, "The selected subscription to delete does not exist")]
  public async Task<IActionResult> DeleteAsync(
    [FromRoute][SwaggerParameter("Subscription identifier", Required = true)] int id
  ) {
    await service.Delete(id);
    return NoContent();
  }

}
