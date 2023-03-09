// ReSharper disable All

using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using Xpto.Core.Customers;

#pragma warning disable CS8601

namespace Xpto.Core
{
    public static class App
    {
        public static int ActionKey = -1;
        public static IList<Customer> Customers = new List<Customer>();
        public static Dictionary<int, string> Actions = new Dictionary<int, string>
        {
            { 1, "Listar Cliente" },
            { 2, "Selecionar Cliente" },
            { 3, "Criar Cliente " },
            { 4, "Editar Cliente" },
            { 5, "Excluir Cliente" },
            { 0, "Voltar" }
        };

        public static void Init()
        {

            //var cep = "4844220";

            //var zipCode = Convert.ToInt64(cep);
            //var zipCodeFormat = zipCode.ToString("00000-000");

            //var value = 56.3;
            //var valueFormat = value.ToString("###,000.00");
 

            var customerRepository = new CustomerRepository();
            //customerRepository.Load();

            while (true)
            {
                Clear();

                ActionKey = GetAction();
                if (ActionKey == 0)
                    return;

                Clear();
                Console.WriteLine($"{Actions[ActionKey]}");

                var customerService = new CustomerService();
 
                if (ActionKey == 1)
                    customerService.List();
                else if (ActionKey == 2)
                    customerService.Select();
                else if (ActionKey == 3)
                    customerService.Create();
                else if (ActionKey == 4)
                    customerService.Edit();
                else if (ActionKey == 5)
                    customerService.Delete();
            }
        }

        public static int GetAction()
        {
            Console.WriteLine("Informe a ação que deseja executar");
            Console.WriteLine();

            foreach (var item in Actions)
                Console.WriteLine($"{item.Key} - {item.Value}");

            Console.WriteLine();

            var success = int.TryParse(Console.ReadLine(), out var action);

            while (!success)
            {
                Console.WriteLine("Ação inválida");
                success = int.TryParse(Console.ReadLine(), out action);
            }

            return action;
        }
 
        public static void PrintHeader()
        {
            Console.WriteLine(("").PadRight(100, '+'));
            Console.WriteLine(" Xpto - V1");
            Console.WriteLine(("").PadRight(100, '+'));
            Console.WriteLine();
        }

        public static void Clear()
        {
            Console.Clear();
            PrintHeader();
        }
    }
}
