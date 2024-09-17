using OfficeOpenXml;
using TenderApi.Models;

namespace TenderApi.Repositories
{
    public class ExcelTenderRepository : ITenderRepository
    {
        private readonly string _filePath;

        public ExcelTenderRepository(string filePath)
        {
            _filePath = filePath;
        }

        public IEnumerable<Tender> GetTenders()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            List<Tender> tenders = new List<Tender>();

            using (var package = new ExcelPackage(new FileInfo(_filePath)))
            {
                var worksheet = package.Workbook.Worksheets.First();
                var rowCount = worksheet.Dimension.Rows;

                for (int row = 2; row <= rowCount; row++)
                {
                    var tender = new Tender
                    {
                        Name = worksheet.Cells[row, 1].Value?.ToString(),
                        StartDate = ParseDateFromExcel(worksheet.Cells[row, 2].Value),
                        EndDate = ParseDateFromExcel(worksheet.Cells[row, 3].Value),
                        Url = worksheet.Cells[row, 4].Value?.ToString()
                    };
                    tenders.Add(tender);
                }
            }

            return tenders;
        }

        private DateTime ParseDateFromExcel(object value)
        {
            if (value is double numericDate)
            {
                return DateTime.FromOADate(numericDate);
            }
            else if (DateTime.TryParse(value?.ToString(), out DateTime parsedDate))
            {
                return parsedDate;
            }

            throw new FormatException($"Неверный формат даты: {value}");
        }
    }
}
