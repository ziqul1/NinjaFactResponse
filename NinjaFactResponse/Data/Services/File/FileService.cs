using System.Text;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace NinjaFactResponse.Data.Services.Files
{
	public class FileService : IFileService
	{
		private readonly IHostingEnvironment _environment;

		public FileService(IHostingEnvironment environment)
			=> _environment = environment;

		public async Task<bool> WriteFile(string response, string fileName)
		{
			var path = Path.Combine(_environment.ContentRootPath, @"TxtFiles\" + fileName);

			using (var writer = new StreamWriter(path, append: true, Encoding.UTF8))
			{
				await writer.WriteLineAsync(response);
			}

			return true;
		}

		public bool CreateTextFile(string fileName)
		{
			var filePath = Path.Combine(_environment.ContentRootPath, @"TxtFiles\" + fileName);

			using (FileStream fileStream = File.Create(filePath))
			{
				return true;
			}
		}
	}
}
