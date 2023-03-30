using System.Data;
using System.Globalization;

namespace Xpto.Core.Customers
{
    public class CustomerService
    {
        public void List()
        {
            App.Clear();
            Console.WriteLine("Lista de Clientes");

            var repository = new CustomerRepository();

            var dt = repository.LoadDataTable();

            foreach (DataRow row in dt.Rows)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    Console.Write(row[i] + " ");
                }
                Console.WriteLine();
            }



            
            var list = repository.Find();
 
            if (list.Count == 1)
                Console.WriteLine("1 registro encontrado");
            else if (list.Count > 1)
                Console.WriteLine("{0} registros encontrados", list.Count);
            else
                Console.WriteLine("nenhum registro encontrado");

            Console.WriteLine();
            Console.WriteLine("Lista de Clientes");
            Console.WriteLine(("").PadRight(100, '-'));
            Console.WriteLine("CÓDIGO".PadRight(10, ' ') + "| NOME");

            foreach (var customer in list)
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

        public void Select()
        {
            App.Clear();
            Console.WriteLine("Consulta de Cliente");
            Console.WriteLine();
            Console.Write("Informe o código do cliente ou 0 para sair: ");

            while (true)
            {
                int.TryParse(Console.ReadLine(), out var code);

                if (code == 0)
                    return;

                var repository = new CustomerRepository();
                var customer = repository.Get(code);

                if (customer == null)
                {
                    App.Clear();
                    Console.WriteLine("Consulta de Cliente");
                    Console.WriteLine();
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Cliente não encontrato ou código inválido");
                    Console.ResetColor();
                }
                else
                {
                    App.Clear();
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


                    foreach (var item in customer.Addresses)
                    {
                        Console.WriteLine("Endereço: {0}", item);
                    }

                    foreach (var item in customer.Phones)
                    {
                        Console.WriteLine("Telefone: {0}", item);
                    }

                    foreach (var item in customer.Emails)
                    {
                        Console.WriteLine("E-mail: {0}", item);
                    }



                    Console.WriteLine("Observação: {0}", customer.Note);
                    Console.WriteLine(("").PadRight(100, '-'));
                }

                Console.Write("0 - Voltar | 1 - Endereço | 2 - Telefone | 3 - E-mail ");
                Console.WriteLine();
                Console.Write("Informe o código do cliente ou 0 para sair: ");
            }
        }

        public void Create()
        {
            App.Clear();

            Console.WriteLine("Novo Cliente");
            Console.WriteLine();

            var customer = new Customer();

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




            Console.Write("Observação:");
            customer.Note = Console.ReadLine();

            var repository = new CustomerRepository();
            repository.Insert(customer);

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

        public void Edit()
        {
            App.Clear();
            Console.WriteLine("Atualização de Cliente");
            Console.WriteLine();
            Console.Write("Informe o código do cliente ou 0 para sair: ");

            while (true)
            {
                int.TryParse(Console.ReadLine(), out var code);

                if (code == 0)
                    return;


                var repository = new CustomerRepository();
                var customer = repository.Get(code);


                if (customer == null)
                {
                    App.Clear();
                    Console.WriteLine("Atualização de Cliente");
                    Console.WriteLine();
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Cliente não encontrato ou código inválido");
                    Console.ResetColor();
                }
                else
                {
                    App.Clear();
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


                    Console.WriteLine("Observação: {0}", customer.Note);
                    text = Console.ReadLine();
                    if (text != "")
                        customer.Note = text;




                    repository.Update(customer);

                    Console.WriteLine();
                    Console.WriteLine("Cliente atualizado com sucesso");
                }

                Console.WriteLine();
                Console.Write("Informe o código do cliente ou 0 para sair: ");
            }
        }

        public void Delete()
        {
            App.Clear();
            Console.WriteLine("Excluir de Cliente");
            Console.WriteLine();
            Console.Write("Informe o código do cliente ou 0 para sair: ");

            while (true)
            {
                int.TryParse(Console.ReadLine(), out var code);

                if (code == 0)
                    return;

                var repository = new CustomerRepository();
                var customer = repository.Get(code);

                if (customer == null)
                {
                    App.Clear();
                    Console.WriteLine("Excluir de Cliente");
                    Console.WriteLine();
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Cliente não encontrato ou código inválido");
                    Console.ResetColor();
                }
                else
                {
                    App.Clear();
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

                        repository.Delete(customer.Id);

                        App.Clear();
                        Console.WriteLine("Excluir de Cliente");
                        Console.WriteLine();
                        Console.WriteLine("Cliente exluído com sucesso");
                    }
                }

                Console.WriteLine();
                Console.Write("Informe o código do cliente ou 0 para sair: ");
            }
        }
    }
}
