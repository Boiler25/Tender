using OfficeOpenXml;
using TenderApi.Models;
using TenderApi.Repositories;

namespace TenderApi.Services
{
    public class TenderService : ITenderService
    {
        private readonly ITenderRepository _tenderRepository;

        public TenderService(ITenderRepository tenderRepository)
        {
            _tenderRepository = tenderRepository;
        }

        public IEnumerable<Tender> GetAllTenders()
        {
            return _tenderRepository.GetTenders();
        }
    }
}
