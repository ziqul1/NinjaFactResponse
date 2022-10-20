namespace NinjaFactResponse.Data.Services.Files
{
	public interface IFileService
	{
		Task<bool> WriteFile(string response, string fileName);
		bool CreateTextFile(string fileName);
	}
}
