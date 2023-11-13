using Domain.Model;
using Application;
using CpfCnpjLibrary;
using Microsoft.Extensions.DependencyInjection;
using Repository;

internal class Program
{
    private static void Main(string[] args)
    {
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);
        var serviceProvider = serviceCollection.BuildServiceProvider();
        var clienteService = serviceProvider.GetService<IClienteRepository>();


        Console.Clear();
        Console.WriteLine("Seja bem vindo ao banco Framework");
        Console.WriteLine("Por favor, identifique-se");
        Console.WriteLine("");
        var cliente = Identificacao(clienteService);
        Menu(cliente, clienteService);
         
    }

    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<IClienteRepository, ClienteRepository>();
    }

    static void Menu(Cliente cliente, IClienteRepository clienteService)
    {
        Console.Clear();
        Console.WriteLine($"O que deseja fazer, {cliente.Nome}?");
        Console.WriteLine($"SALDO ATUAL => R${cliente.Saldo}");
        Console.WriteLine("");
        Console.WriteLine("--------------");
        Console.WriteLine("Menu");
        Console.WriteLine("--------------");
        Console.WriteLine("1 - Depósito");
        Console.WriteLine("2 - Saque");
        Console.WriteLine("Digite sua opção:");
        Console.WriteLine("");
        int opcao = int.Parse(Console.ReadLine());
        var calculo = new Calculo();

        float valor = 0;

        switch (opcao)
        {
            case 1:
                Console.Clear();
                Console.WriteLine("Digite o valor:");
                valor = float.Parse(Console.ReadLine());
                cliente.Saldo = calculo.Soma(cliente.Saldo, valor);
                clienteService.Update(cliente);
                Console.Clear();
                Menu(cliente, clienteService);
                break;

            case 2:
                Console.Clear();
                Console.WriteLine("Digite o valor:");
                valor = float.Parse(Console.ReadLine());
                cliente.Saldo = calculo.Subtracao(cliente.Saldo, valor);
                clienteService.Update(cliente);
                Console.Clear();
                Menu(cliente, clienteService);
                break;

            default:
                Console.Clear();
                Console.WriteLine("Digite uma opção válida");
                break;
        }

    }

    static Cliente Identificacao(IClienteRepository clienteService)
    {
        var cliente = new Cliente();

        List<string> erros = new List<string>
        {
            ""
        };

        while (erros.Count() != 0)
        {

            erros.Clear();


            Console.WriteLine("Seu número de identificação:");
            var id = Console.ReadLine();
            if (!int.TryParse(id, out _))
            {
                erros.Add("Identificador não é válido");
            }
            else
            {

                cliente.Id = int.Parse(id);

                var clienteExistente = clienteService.Get(cliente.Id);

                if(clienteExistente != null)
                {
                    return clienteExistente;
                }
            }
            Console.WriteLine("");

            Console.WriteLine("Seu nome:");
            cliente.Nome = Console.ReadLine();
            Console.WriteLine("");


            Console.WriteLine("Seu CPF:");
            var cpf = Console.ReadLine();
            if (Cpf.Validar(cpf) == false)
            {
                erros.Add("CPF digitado não é válido");
            }
            cliente.Cpf = cpf;
            Console.WriteLine("");


            Console.WriteLine("Seu saldo:");
            var saldo = Console.ReadLine();
            if (!float.TryParse(saldo, out _) || float.Parse(saldo) <= 0)
            {
                erros.Add("Saldo não é válido");
            }
            cliente.Saldo = float.Parse(saldo);

            if (erros.Count() > 0)
            {
                foreach (string mensagem in erros)
                {
                    Console.WriteLine(mensagem);
                }
                Console.ReadLine();
                Console.Clear();
            }
        }

        clienteService.Insert(cliente);

        return cliente;
    }
}