﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;
using WAW.API.Recruiters.Domain.Models;
using WAW.API.Recruiters.Domain.Services;
using WAW.API.Recruiters.Resources;
using WAW.API.Auth.Authorization.Attributes;
using WAW.API.Shared.Extensions;

namespace WAW.API.Recruiters.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Create, read, update and delete Recruiters")]
public class RecruiterController : ControllerBase{

  private readonly IRecruiterService service;
  private readonly IMapper mapper;

  public RecruiterController(IRecruiterService service, IMapper mapper) {
    this.service = service;
    this.mapper = mapper;
  }

  [HttpGet]
  [ProducesResponseType(typeof(IEnumerable<RecruiterResource>), 200)]
  [SwaggerResponse(200, "All the stored recruiters were retrieved successfully.", typeof(IEnumerable<RecruiterResource>))]
  public async Task<IEnumerable<RecruiterResource>> GetAll() {
    var recruiters = await service.ListAll();
    return mapper.Map<IEnumerable<Recruiter>, IEnumerable<RecruiterResource>>(recruiters);
  }

  [HttpPost]
  [ProducesResponseType(typeof(RecruiterResource), 200)]
  [ProducesResponseType(typeof(List<string>), 400)]
  [ProducesResponseType(500)]
  [SwaggerResponse(200, "The recruiter was created successfully", typeof(RecruiterResource))]
  [SwaggerResponse(400, "The recruiter data is invalid")]
  public async Task<IActionResult> Post([FromBody] RecruiterRequest resource) {
    if (!ModelState.IsValid)
      return BadRequest(ModelState.GetErrorMessages());

    var recruiter = mapper.Map<RecruiterRequest, Recruiter>(resource);
    var result = await service.Create(recruiter);
    return result.ToResponse<RecruiterResource>(this, mapper);
  }

  [HttpPut("{id:int}")]
  [ProducesResponseType(typeof(RecruiterResource), 200)]
  [ProducesResponseType(typeof(List<string>), 400)]
  [ProducesResponseType(500)]
  [SwaggerResponse(200, "The recruiter was updated successfully", typeof(RecruiterResource))]
  [SwaggerResponse(400, "The recruiter data is invalid")]
  public async Task<IActionResult> Put(
    [FromRoute][SwaggerParameter("Recruiter identifier", Required = true)] int id,
    [FromBody] RecruiterRequest resource
  ) {
    if (!ModelState.IsValid)
      return BadRequest(ModelState.GetErrorMessages());

    var recruiter = mapper.Map<RecruiterRequest, Recruiter>(resource);
    var result = await service.Update(id, recruiter);
    return result.ToResponse<RecruiterResource>(this, mapper);
  }

  [HttpDelete("{id:int}")]
  [ProducesResponseType(typeof(NoContentResult), 204)]
  [ProducesResponseType(typeof(List<string>), 400)]
  [ProducesResponseType(500)]
  [SwaggerResponse(204, "The recruiter was deleted successfully", typeof(NoContentResult))]
  [SwaggerResponse(400, "The selected recruiter to delete does not exist")]
  public async Task<IActionResult> DeleteAsync(
    [FromRoute][SwaggerParameter("Recruiter identifier", Required = true)] int id
  ) {
    await service.Delete(id);
    return NoContent();
  }

}
