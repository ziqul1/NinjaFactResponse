using Microsoft.AspNetCore.Mvc;
using NinjaFactResponse.Data.Services.Files;
using NinjaFactResponse.Models;

namespace NinjaFactResponse.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FileController : ControllerBase
	{
		private readonly IFileService _fileService;

		public FileController(IFileService fileService) 
			=> _fileService = fileService;

		[HttpGet("CreateTextFile")]
		public ActionResult CreateTextFile(string fileNameWithTxtEnding)
		{
			if (_fileService.CreateTextFile(fileNameWithTxtEnding))
				return NoContent();

			return BadRequest();
		}
	}
}
