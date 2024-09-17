using TenderApi.Models;

namespace TenderApi.Repositories
{
    public interface ITenderRepository
    {
        IEnumerable<Tender> GetTenders();
    }
}
