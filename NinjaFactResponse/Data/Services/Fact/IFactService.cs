
namespace NinjaFactResponse.Data.Services.Fact
{
    public interface IFactService
    {
        Task<bool> GetSingleFact(string fileName);
    }
}
