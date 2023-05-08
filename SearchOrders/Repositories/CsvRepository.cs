using CsvHelper;
using CsvHelper.Configuration;
using SearchOrders.Models;
using System.Globalization;
using System.Text;

namespace SearchOrders.Repositories
{
    public class CsvRepository
    {
        private readonly string csvFilePath;

        public CsvRepository(IConfiguration config)
        {
            csvFilePath = config.GetValue<string>("CsvFilePath");
        }

        public List<PurchaseOrder> GetOrders()
        {
            var orders = new List<PurchaseOrder>();

            CsvConfiguration config = new CsvConfiguration(CultureInfo.GetCultureInfo("en-US")
            {
                Delimiter = ",",
                Encoding = Encoding.UTF8,
                HasHeaderRecord = true
            };

            using (var reader = new StreamReader(csvFilePath, Encoding.UTF8))
            using (var csv = new CsvReader(reader, config))
            {
                orders = csv.GetRecords<PurchaseOrder>().ToList();
                return orders;
            }
        }
    }
}
