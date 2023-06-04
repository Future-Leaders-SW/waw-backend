using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;
using WAW.API.Auth.Authorization.Attributes;
using WAW.API.Shared.Extensions;
using WAW.API.Subscriptions.Domain.Models;
using WAW.API.Subscriptions.Domain.Services;
using WAW.API.Subscriptions.Resources;

namespace WAW.API.Subscriptions.Controllers;


[Authorize]
[ApiController]
[Route("[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Create, read, update and delete Plan Subscriptions")]
public class PlanSubscriptionController : ControllerBase {

  private readonly IPlanSubscriptionService service;
  private readonly IMapper mapper;

  public PlanSubscriptionController(IPlanSubscriptionService service, IMapper mapper) {
    this.service = service;
    this.mapper = mapper;
  }

  [HttpGet]
  [ProducesResponseType(typeof(IEnumerable<PlanSubscriptionResource>), 200)]
  [SwaggerResponse(200, "All the stored plans subscriptions were retrieved successfully.", typeof(IEnumerable<PlanSubscriptionResource>))]
  public async Task<IEnumerable<PlanSubscriptionResource>> GetAll() {
    var planSubscriptions = await service.ListAll();
    return mapper.Map<IEnumerable<PlanSubscription>, IEnumerable<PlanSubscriptionResource>>(planSubscriptions);
  }


  [HttpPost]
  [ProducesResponseType(typeof(PlanSubscriptionResource), 200)]
  [ProducesResponseType(typeof(List<string>), 400)]
  [ProducesResponseType(500)]
  [SwaggerResponse(200, "The plan subscription was created successfully", typeof(PlanSubscriptionResource))]
  [SwaggerResponse(400, "The plan subscription data is invalid")]
  public async Task<IActionResult> Post([FromBody] PlanSubscriptionRequest resource) {
    if (!ModelState.IsValid)
      return BadRequest(ModelState.GetErrorMessages());

    var planSubscription = mapper.Map<PlanSubscriptionRequest, PlanSubscription>(resource);
    var result = await service.Create(planSubscription);
    return result.ToResponse<PlanSubscriptionResource>(this, mapper);
  }

  [HttpPut("{id:int}")]
  [ProducesResponseType(typeof(PlanSubscriptionResource), 200)]
  [ProducesResponseType(typeof(List<string>), 400)]
  [ProducesResponseType(500)]
  [SwaggerResponse(200, "The plan subscription was updated successfully", typeof(PlanSubscriptionResource))]
  [SwaggerResponse(400, "The plan subscription data is invalid")]
  public async Task<IActionResult> Put(
    [FromRoute][SwaggerParameter("Plan Subscription identifier", Required = true)] int id,
    [FromBody] PlanSubscriptionRequest resource
  ) {
    if (!ModelState.IsValid)
      return BadRequest(ModelState.GetErrorMessages());

    var planSubscription = mapper.Map<PlanSubscriptionRequest, PlanSubscription>(resource);
    var result = await service.Update(id, planSubscription);
    return result.ToResponse<PlanSubscriptionResource>(this, mapper);
  }


  [HttpDelete("{id:int}")]
  [ProducesResponseType(typeof(NoContentResult), 204)]
  [ProducesResponseType(typeof(List<string>), 400)]
  [ProducesResponseType(500)]
  [SwaggerResponse(204, "The plan subscription was deleted successfully", typeof(NoContentResult))]
  [SwaggerResponse(400, "The selected plan subscription to delete does not exist")]
  public async Task<IActionResult> DeleteAsync(
   [FromRoute][SwaggerParameter("Plan Subscription identifier", Required = true)] int id
 ) {
    await service.Delete(id);
    return NoContent();
  }


}
