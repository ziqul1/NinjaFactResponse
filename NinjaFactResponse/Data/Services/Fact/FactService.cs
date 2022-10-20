using Newtonsoft.Json;
using NinjaFactResponse.Data.Services.Files;

namespace NinjaFactResponse.Data.Services.Fact
{
	public class FactService : IFactService
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly IFileService _fileService;

		public FactService(IHttpClientFactory httpClientFactory, IFileService fileService)
		{
			_httpClientFactory = httpClientFactory;
			_fileService = fileService;
		}

		public async Task<bool> GetSingleFact(string fileName)
		{
			var httpClientFactory = _httpClientFactory.CreateClient("ResponseFromExternalAPI");
			var response = await httpClientFactory.GetAsync($"/fact");

			var isTXTFile = fileName.Substring(fileName.Length - 3);

			if (isTXTFile == "txt")
			{
				if (response.IsSuccessStatusCode)
				{
					var readResponse = await response.Content.ReadAsStringAsync();

					var factDetails = JsonConvert.DeserializeObject<Models.Fact>(readResponse);
					var serializedFact = JsonConvert.SerializeObject(factDetails);

					await _fileService.WriteFile(serializedFact, fileName);

					return true;
				}
			}
			
			return false;
		}
	}
}
