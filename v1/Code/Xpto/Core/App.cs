// ReSharper disable All

using System.Globalization;
using System.Text;
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
            LoadCustomers();
 
            while (true)
            {
                Clear();

                ActionKey = GetAction();
                if (ActionKey == 0)
                    return;

                Clear();
                Console.WriteLine($"{Actions[ActionKey]}");

                if (ActionKey == 1)
                    CustomerList();
                else if (ActionKey == 2)
                    CustomerSelect();
                else if (ActionKey == 3)
                    CustomerCreate();
                else if (ActionKey == 4)
                    CustomerEdit();
                else if (ActionKey == 5)
                    CustomerDelete();
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

        public static void CustomerList()
        {
            Clear();

            Console.WriteLine("Lista de Clientes");
           

            if (Customers.Count == 1)
                Console.WriteLine("1 registro encontrado");
            else if (Customers.Count > 1)
                Console.WriteLine("{0} registros encontrados", Customers.Count);
            else
                Console.WriteLine("nenhum registro encontrado");

            Console.WriteLine();

            Console.WriteLine("Lista de Clientes");

            Console.WriteLine(("").PadRight(100, '-'));
            Console.WriteLine("CÓDIGO".PadRight(10, ' ') + "| NOME");

            foreach (var customer in Customers)
            {
                Console.WriteLine(("").PadRight(100, '-'));
                Console.WriteLine($"{customer.Code.ToString().PadRight(10, ' ')}| {customer.Name}");
            }

            Console.WriteLine(("").PadRight(100, '-'));

            Console.WriteLine();
            Console.WriteLine("0 - Voltar");
            Console.WriteLine();

            int.TryParse(Console.ReadLine(), out var action);

            while (action != 0)
            {
                Console.WriteLine("Comando inválido");
                int.TryParse(Console.ReadLine(), out action);
            }
        }

        public static void CustomerSelect()
        {
            Clear();
            Console.WriteLine("Consulta de Cliente");
            Console.WriteLine();
            Console.Write("Informe o código do cliente ou 0 para sair: ");

            while (true)
            {
                int.TryParse(Console.ReadLine(), out var code);

                if (code == 0)
                    return;

                var customer = Customers.FirstOrDefault(x => x.Code == code);

                if (customer == null)
                {
                    Clear();
                    Console.WriteLine("Consulta de Cliente");
                    Console.WriteLine();
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Cliente não encontrato ou código inválido");
                    Console.ResetColor();
                }
                else
                {
                    Clear();
                    Console.WriteLine("Consulta de Cliente");
                    Console.WriteLine();


                    Console.WriteLine(("").PadRight(100, '-'));
                    Console.WriteLine("Cliente Selecionado");
                    Console.WriteLine(("").PadRight(100, '-'));

                    Console.WriteLine("Código: {0}", customer.Code);
                    Console.WriteLine("Nome: {0}", customer.Name);
                    Console.WriteLine("Tipo de Pessoa: {0}", customer.PersonType);

                    if (customer.PersonType?.ToUpper() == "PJ")
                    {
                        Console.WriteLine("Nome Fantasia:: {0}", customer.Nickname);
                    }

                    Console.WriteLine("CPF/CNPJ: {0}", customer.Identity);

                    if (customer.PersonType?.ToUpper() == "PF" && customer.BirthDate != null)
                    {
                        Console.WriteLine("Data de Nascimento: {0}", ((DateTime)customer.BirthDate).ToString("dd/MM/yyyy"));
                    }

                    Console.WriteLine("Endereço: {0}", customer.Address);
                    Console.WriteLine("Telefone: {0}", customer.Phone);
                    Console.WriteLine("E-mail: {0}", customer.Email);
                    Console.WriteLine("Observação: {0}", customer.Note);
                    Console.WriteLine(("").PadRight(100, '-'));
                }

                Console.WriteLine();
                Console.Write("Informe o código do cliente ou 0 para sair: ");
            }
        }

        public static void CustomerCreate()
        {
            Clear();

            Console.WriteLine("Novo Cliente");
            Console.WriteLine();

            var customer = new Customer();

            Console.Write("Código (Número inteiro):");
            customer.Code = Convert.ToInt32(Console.ReadLine());

            Console.Write("Tipo de Pessoa (PF ou PJ):");
            customer.PersonType = Console.ReadLine();

            Console.Write("Nome:");
            customer.Name = Console.ReadLine();

            if (customer.PersonType?.ToUpper() == "PJ")
            {
                Console.Write("Nome Fantasia:");
                customer.Nickname = Console.ReadLine();
            }

            Console.Write("CPF/CNPJ:");
            customer.Identity = Console.ReadLine();

            if (customer.PersonType?.ToUpper() == "PF")
            {
                Console.Write("Data de Nascimento (dd/mm/aaaa):");

                while (true)
                {
                    if (DateTime.TryParseExact(
                            Console.ReadLine(),
                            "d/M/yyyy",
                            CultureInfo.InvariantCulture,
                            DateTimeStyles.None,
                            out var dt))
                    {
                        customer.BirthDate = dt;
                        break;
                    }
                    else
                    {
                        Console.Write("Data de Nascimento inválida:");
                    }
                }
            }

            Console.Write("Endereço:");
            customer.Address = Console.ReadLine();
            Console.Write("Telefone:");
            customer.Phone = Console.ReadLine();
            Console.Write("E-mail:");
            customer.Email = Console.ReadLine();
            Console.Write("Observação:");
            customer.Note = Console.ReadLine();

            customer.CreationDate = new DateTime();
            Customers.Add(customer);

            SaveCustomers();
            Console.WriteLine();
            Console.WriteLine("Cliente cadastrado com sucesso");

            Console.WriteLine();
            Console.WriteLine("0 - Voltar");
            Console.WriteLine();

            int.TryParse(Console.ReadLine(), out var action);

            while (action != 0)
            {
                Console.WriteLine("Comando inválido");
                int.TryParse(Console.ReadLine(), out action);
            }
        }

        public static void CustomerEdit()
        {
            Clear();
            Console.WriteLine("Atualização de Cliente");
            Console.WriteLine();
            Console.Write("Informe o código do cliente ou 0 para sair: ");

            while (true)
            {
                int.TryParse(Console.ReadLine(), out var code);

                if (code == 0)
                    return;

                var customer = Customers.FirstOrDefault(x => x.Code == code);

                if (customer == null)
                {
                    Clear();
                    Console.WriteLine("Atualização de Cliente");
                    Console.WriteLine();
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Cliente não encontrato ou código inválido");
                    Console.ResetColor();
                }
                else
                {
                    Clear();
                    Console.WriteLine("Atualização de Cliente");
                    Console.WriteLine();


                    Console.WriteLine("Cliente Selecionado");
                    Console.WriteLine(("").PadRight(100, '-'));

                    Console.WriteLine("Código: {0}", customer.Code);
                    var text = Console.ReadLine();
                    if (text != "")
                        customer.Code = Convert.ToInt32(text);

                    Console.WriteLine("Nome: {0}", customer.Name);
                    text = Console.ReadLine();
                    if (text != "")
                        customer.Name = text;

                    Console.WriteLine("Tipo de Pessoa: {0}", customer.PersonType);
                    text = Console.ReadLine();
                    if (text != "")
                        customer.PersonType = text;

                    if (customer.PersonType?.ToUpper() == "PJ")
                    {
                        Console.WriteLine("Nome Fantasia:: {0}", customer.Nickname);
                        text = Console.ReadLine();
                        if (text != "")
                            customer.Nickname = text;
                    }

                    Console.WriteLine("CPF/CNPJ: {0}", customer.Identity);
                    text = Console.ReadLine();
                    if (text != "")
                        customer.Identity = text;

                    if (customer.PersonType?.ToUpper() == "PF" && customer.BirthDate != null)
                    {
                        Console.WriteLine("Data de Nascimento: {0}", ((DateTime)customer.BirthDate).ToString("dd/MM/yyyy"));
                        text = Console.ReadLine();
                        if (text != "")
                        {
                            while (true)
                            {
                                if (DateTime.TryParseExact(
                                        text,
                                        "d/M/yyyy",
                                        CultureInfo.InvariantCulture,
                                        DateTimeStyles.None,
                                        out var dt))
                                {
                                    customer.BirthDate = dt;
                                    break;
                                }
                                else
                                {
                                    Console.Write("Data de Nascimento inválida:");
                                }
                            }
                        }
                    }

                    Console.WriteLine("Endereço: {0}", customer.Address);
                    text = Console.ReadLine();
                    if (text != "")
                        customer.Address = text;

                    Console.WriteLine("Telefone: {0}", customer.Phone);
                    text = Console.ReadLine();
                    if (text != "")
                        customer.Phone = text;

                    Console.WriteLine("E-mail: {0}", customer.Email);
                    text = Console.ReadLine();
                    if (text != "")
                        customer.Email = text;

                    Console.WriteLine("Observação: {0}", customer.Note);
                    text = Console.ReadLine();
                    if (text != "")
                        customer.Note = text;


                    SaveCustomers();
                    Console.WriteLine();
                    Console.WriteLine("Cliente atualizado com sucesso");
                }

                Console.WriteLine();
                Console.Write("Informe o código do cliente ou 0 para sair: ");
            }
        }

        public static void CustomerDelete()
        {
            Clear();
            Console.WriteLine("Excluir de Cliente");
            Console.WriteLine();
            Console.Write("Informe o código do cliente ou 0 para sair: ");

            while (true)
            {
                int.TryParse(Console.ReadLine(), out var code);

                if (code == 0)
                    return;

                var customer = Customers.FirstOrDefault(x => x.Code == code);

                if (customer == null)
                {
                    Clear();
                    Console.WriteLine("Excluir de Cliente");
                    Console.WriteLine();
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Cliente não encontrato ou código inválido");
                    Console.ResetColor();
                }
                else
                {
                    Clear();
                    Console.WriteLine("Excluir de Cliente");
                    Console.WriteLine();

                    Console.WriteLine(("").PadRight(100, '-'));
                    Console.WriteLine("Código: {0}", customer.Code);
                    Console.WriteLine("Nome: {0}", customer.Name);
                    Console.WriteLine(("").PadRight(100, '-'));
                    Console.WriteLine();
                    Console.Write("Deseja excluir o cliente? (S - Sim, N - Não):");
                    var result = Console.ReadLine();
                    if (result?.ToUpper() == "S")
                    {
                        Customers.Remove(customer);

                        SaveCustomers();

                        Clear();
                        Console.WriteLine("Excluir de Cliente");
                        Console.WriteLine();
                        Console.WriteLine("Cliente exluído com sucesso");
                    }
                }

                Console.WriteLine();
                Console.Write("Informe o código do cliente ou 0 para sair: ");
            }
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

        public static void LoadCustomers()
        {
            Customers = new List<Customer>();

            var dir = Directory.GetCurrentDirectory() + "\\db";
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            var path = dir + "\\customer.txt";

            using (var file = File.Open(path, FileMode.OpenOrCreate))
            {
                using (var reader = new StreamReader(file))
                {
                    string line = reader.ReadLine();
                    line = reader.ReadLine();

                    while (line != null)
                    {
                        var fields = line.Split(';');

                        var c = new Customer();
                        c.Id = new Guid(fields[0]);
                        c.Code = Convert.ToInt32(fields[1]);
                        c.Name = fields[2];
                        c.Nickname = fields[3];
                        c.BirthDate = GetIsoDateTime(fields[4]);
                        c.PersonType = fields[5];
                        c.Identity = fields[6];
                        c.Address = fields[7];
                        c.Phone = fields[8];
                        c.Email = fields[9];
                        c.Note = fields[10];
                        c.CreationDate = GetIsoDateTime(fields[11]);
                        c.CreationUserId = GetGuid(fields[12]);
                        c.CreationUserName = fields[13];
                        c.ChangeDate = GetIsoDateTime(fields[14]);
                        c.ChangeUserId = GetGuid(fields[15]);
                        c.ChangeUserName = fields[16];

                        Customers.Add(c);

                        line = reader.ReadLine();
                    }
                }
            }
        }

        public static void SaveCustomers()
        {
            var dir = Directory.GetCurrentDirectory() + "\\db";
            var path = dir + "\\customer.txt";

            var header = "id;code;name;nickname;birth_date;person_type;identity;street;phone;email;note;creation_date;creation_user_id;creation_user_name;change_date;change_user_id;change_user_name;";

            using (var file = File.Open(path, FileMode.Create))
            {
                using (var writer = new StreamWriter(file))
                {
                    writer.WriteLine(header);
 
                    foreach (var c in Customers)
                    {
                        var line = new StringBuilder();

                        AppendField(line, c.Id);
                        AppendField(line, c.Code);
                        AppendField(line, c.Name);
                        AppendField(line, c.Nickname);
                        AppendField(line, c.BirthDate);
                        AppendField(line, c.PersonType);
                        AppendField(line, c.Identity);
                        AppendField(line, c.Address);
                        AppendField(line, c.Phone);
                        AppendField(line, c.Email);
                        AppendField(line, c.Note);
                        AppendField(line, c.CreationDate);
                        AppendField(line, c.CreationUserId);
                        AppendField(line, c.CreationUserName);
                        AppendField(line, c.ChangeDate);
                        AppendField(line, c.ChangeUserId);
                        AppendField(line, c.ChangeUserName);

                        writer.WriteLine(line.ToString());
                    }
                }
            }
        }

        public static DateTime? GetIsoDateTime(string text)
        {
            if (DateTime.TryParseExact(text, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out var dt))
                return dt;
            else
                return null;
        }

        public static Guid GetGuid(string text)
        {
            if (Guid.TryParse(text, out var result))
                return result;
            else
                return Guid.Empty;
        }

        public static void AppendField(StringBuilder sb, string value)
        {
            if (value != null)
            {
                value = value.Replace(";", "##$$##");
                sb.Append(value);
            }

            sb.Append(';');
        }

        public static void AppendField(StringBuilder sb, Guid value)
        {
            sb.Append(value);
            sb.Append(';');
        }

        public static void AppendField(StringBuilder sb, DateTime? value)
        {
            if (value != null)
            {
                sb.Append(((DateTime)value).ToString("yyyy-MM-dd HH:mm:ss"));
            }

            sb.Append(';');
        }

        public static void AppendField(StringBuilder sb, int value)
        {
            sb.Append(value);
            sb.Append(';');
        }

    }
}
