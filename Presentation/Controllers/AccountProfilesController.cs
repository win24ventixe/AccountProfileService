using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;
using Presentation.Services;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountProfilesController(IAccountProfileService accountProfileService) : ControllerBase
{
    private readonly IAccountProfileService _accountProfileService = accountProfileService;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var accounts = await _accountProfileService.GetProfilesAsync();
        return Ok(accounts);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var curretnEvent = await _accountProfileService.GetProfileAsync(id);
        return curretnEvent != null ? Ok(curretnEvent) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProfileRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _accountProfileService.CreateProfileAsync(request);
        return result.Success ? Ok() : StatusCode(500, result.Error);
    }
}
