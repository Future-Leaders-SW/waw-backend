using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WAW.API.Auth.Authorization.Attributes;
using WAW.API.Auth.Domain.Models;
using WAW.API.Auth.Domain.Services;
using WAW.API.Auth.Resources;

namespace WAW.API.Auth.Controllers {
  [Authorize]
  [ApiController]
  [Route("users/me/education")]
  [SwaggerTag("Create, read, update and delete the current User education info")]
  public class UserEducationsController : ControllerBase {
    private readonly IUserEducationService service;
    private readonly IMapper mapper;

    public UserEducationsController(IUserEducationService service, IMapper mapper) {
      this.service = service;
      this.mapper = mapper;
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    [HttpGet("hidden-endpoint")]
    public async Task<IEnumerable<UserEducationResource>> ListAll() {
      var user = (User) HttpContext.Items["User"]!;
      var results = await service.ListByUserId(user.Id);
      return mapper.Map<IEnumerable<UserEducation>, IEnumerable<UserEducationResource>>(results);
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UserEducationRequest request) {
      var user = (User) HttpContext.Items["User"]!;
      var mapped = mapper.Map<UserEducationRequest, UserEducation>(request);
      mapped.UserId = user.Id;
      var result = await service.Add(mapped);
      return result.ToResponse<UserEducationResource>(this, mapper);
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    [HttpPut("{id:long}")]
    public async Task<IActionResult> Update([FromRoute] long id, [FromBody] UserEducationRequest request) {
      var user = (User) HttpContext.Items["User"]!;
      var mapped = mapper.Map<UserEducationRequest, UserEducation>(request);
      mapped.UserId = user.Id;
      var result = await service.Update(id, mapped);
      return result.ToResponse<UserEducationResource>(this, mapper);
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete([FromRoute] long id) {
      var user = (User) HttpContext.Items["User"]!;
      var result = await service.Remove(id, user.Id);
      if (!result)
        return BadRequest("Unable to remove request entity");

      return NoContent();
    }
  }
}
