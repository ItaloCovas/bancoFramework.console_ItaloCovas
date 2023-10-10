using Domain.Model;
using Application;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Seja bem vindo ao banco Framework");
        Console.WriteLine("Por favor, identifique-se");
        Console.WriteLine("");
        var cliente = Identificacao();
    }

    static void Menu(Cliente cliente) {
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
             Console.WriteLine("");
             Console.WriteLine($"==> Saldo atual é R${cliente.Saldo}");
             Menu(cliente);
             break;

             case 2:
             Console.Clear();
             Console.WriteLine("Digite o valor:");
             valor = float.Parse(Console.ReadLine());
             cliente.Saldo = calculo.Subtracao(cliente.Saldo, valor);
             Console.WriteLine("");
             Console.WriteLine($"==> Saldo atual é R${cliente.Saldo}");
             Menu(cliente);
             break;
            
            default:
            Console.Clear();
            Console.WriteLine("Digite uma opção válida");
            break;
        }

    }

    static Cliente Identificacao()
    {
        var cliente = new Cliente();

        Console.WriteLine("Seu saldo:");
        cliente.Saldo = float.Parse(Console.ReadLine());

        Menu(cliente);
        
        return cliente;
    }
}