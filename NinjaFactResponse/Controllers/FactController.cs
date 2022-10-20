using Microsoft.AspNetCore.Mvc;
using NinjaFactResponse.Data.Services.Fact;
using NinjaFactResponse.Data.Services.Files;
using NinjaFactResponse.Models;

namespace NinjaFactResponse.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FactController : ControllerBase
	{
		private readonly IFactService _factService;

		public FactController(IFactService factService) 
			=> _factService = factService;

		[HttpGet]
		public async Task<ActionResult> GetSingleFact(string fileNameWithTxtEnding)
		{
			if (await _factService.GetSingleFact(fileNameWithTxtEnding))
				return Ok();

			return BadRequest();
		}
	}
}
