using System.Text.Json;

namespace Xpto.Core.Customers
{
    public class CustomerRepository
    {
        public void Load()
        {
            App.Customers = new List<Customer>();

            var dir = Directory.GetCurrentDirectory() + "\\db";
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            var path = dir + "\\customer.json";

            string json = File.ReadAllText(path);
            App.Customers = JsonSerializer.Deserialize<IList<Customer>>(json)!;
        }

        public void Save()
        {
            var dir = Directory.GetCurrentDirectory() + "\\db";
            var path = dir + "\\customer.json";

            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(App.Customers, options);
            File.WriteAllText(path, json);
        }
    }
}
