using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xpto.Core.Shared.Entities;

namespace Xpto.Core.Customers
{
    public class CustomerService
    {
        public void List()
        {
            App.Clear();
            Console.WriteLine("Lista de Clientes");

            if (App.Customers.Count == 1)
                Console.WriteLine("1 registro encontrado");
            else if (App.Customers.Count > 1)
                Console.WriteLine("{0} registros encontrados", App.Customers.Count);
            else
                Console.WriteLine("nenhum registro encontrado");

            Console.WriteLine();
            Console.WriteLine("Lista de Clientes");
            Console.WriteLine(("").PadRight(100, '-'));
            Console.WriteLine("CÓDIGO".PadRight(10, ' ') + "| NOME");

            foreach (var customer in App.Customers)
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

                var customer = App.Customers.FirstOrDefault(x => x.Code == code);

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

            var address = new Address();

            Console.Write("CEP:");
            address.ZipCode = Console.ReadLine();
            Console.Write("Logradouro:");
            address.Street = Console.ReadLine();
            Console.Write("Número:");
            address.Number = Console.ReadLine();
            Console.Write("Complemento:");
            address.Complement = Console.ReadLine();
            Console.Write("Bairro:");
            address.District = Console.ReadLine();
            Console.Write("Cidade:");
            address.City = Console.ReadLine();
            Console.Write("Estado:");
            address.State = Console.ReadLine();

            customer.Addresses.Add(address);


            Console.Write("Telefone com DDD:");

            var phone = new Phone();
            phone.Number = Convert.ToInt64(Console.ReadLine());
            customer.Phones.Add(phone);


            Console.Write("E-mail:");

            var email = new Email();
            email.Address = Console.ReadLine();
            customer.Emails.Add(email);



            Console.Write("Observação:");
            customer.Note = Console.ReadLine();

            customer.CreationDate = new DateTime();
            App.Customers.Add(customer);


            var customerRepository = new CustomerRepository();
            customerRepository.Save();

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

                var customer = App.Customers.FirstOrDefault(x => x.Code == code);

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

                    //Console.WriteLine("Endereço: {0}", customer.Address);
                    //text = Console.ReadLine();
                    //if (text != "")
                    //    customer.Address = text;

                    //Console.WriteLine("E-mail: {0}", customer.Email);
                    //text = Console.ReadLine();
                    //if (text != "")
                    //    customer.Email = text;

                    Console.WriteLine("Observação: {0}", customer.Note);
                    text = Console.ReadLine();
                    if (text != "")
                        customer.Note = text;


                    var customerRepository = new CustomerRepository();
                    customerRepository.Save();

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

                var customer = App.Customers.FirstOrDefault(x => x.Code == code);

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
                        App.Customers.Remove(customer);

                        var customerRepository = new CustomerRepository();
                        customerRepository.Save();

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
