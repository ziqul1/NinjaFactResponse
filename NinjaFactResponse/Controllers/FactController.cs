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
		private readonly IFileService _fileService;

		public FactController(IFactService factService, IFileService fileService)
		{
			_factService = factService;
			_fileService = fileService;
		}

		[HttpGet]
		public async Task<ActionResult> GetSingleFact(string fileNameWithTxtEnding)
		{
			if (await _factService.GetSingleFact(fileNameWithTxtEnding))
				return Ok();

			return BadRequest();
		}
	}
}
