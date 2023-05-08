using CsvHelper;
using SearchOrders.Models;
using System.Globalization;

namespace SearchOrders.Repositories
{
    public class CsvRepository
    {
        private readonly string csvFilePath;

        public CsvRepository(IConfiguration config)
        {
            csvFilePath = config.GetValue<string>(csvFilePath);
        }

        public List<PurchaseOrder> GetOrders()
        {
            using (var reader = new StreamReader(csvFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var orders = csv.GetRecords<PurchaseOrder>().ToList();
                return orders;
            }
        }
    }
}
