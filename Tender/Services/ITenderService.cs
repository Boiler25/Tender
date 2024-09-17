using TenderApi.Models;

namespace TenderApi.Services
{
    public interface ITenderService
    {
        IEnumerable<Tender> GetAllTenders();
    }
}
