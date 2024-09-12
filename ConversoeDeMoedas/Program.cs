using System;

namespace ConversorDeMoedas
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // Taxas de conversão fictícias (USD -> BRL, EUR -> BRL, e vice-versa)
            const double usdToBrl = 5.25;
            const double eurToBrl = 6.18;
            const double brlToUsd = 1 / usdToBrl;
            const double brlToEur = 1 / eurToBrl;

            Console.WriteLine("Bem-vindo ao Conversor de Moedas!");

            Console.WriteLine("Escolha a moeda de origem:");
            Console.WriteLine("1 - Dólar (USD)");
            Console.WriteLine("2 - Euro (EUR)");
            Console.WriteLine("3 - Real (BRL)");

            int moedaOrigem = int.Parse(Console.ReadLine());

            Console.WriteLine("Escolha a moeda de destino:");
            Console.WriteLine("1 - Dólar (USD)");
            Console.WriteLine("2 - Euro (EUR)");
            Console.WriteLine("3 - Real (BRL)");

            int moedaDestino = int.Parse(Console.ReadLine());

            Console.WriteLine("Insira o valor a ser convertido:");
            double valor = double.Parse(Console.ReadLine());

            double resultado = ConversorDeMoedas.ConverterMoeda(moedaOrigem, moedaDestino, valor);

            Console.WriteLine($"Valor convertido: {resultado:N2}");
        }

       
        
    }
}
