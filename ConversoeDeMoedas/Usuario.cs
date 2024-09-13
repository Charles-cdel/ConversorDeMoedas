namespace ConversorDeMoedas;

public class Usuario
{
    public string nome { get; set;};
    public double SaldoDolar{ get; set;};
    public double SaldoEuro{ get; set;};
    public double SaldoReal{ get; set;}

    public Usuario(string nome)

    {
        Nome = nome;

        SaldoDolar = 1200; //Exemplo de saldo inicial do usuario $1200
        SaldoEuro = 2000; //Exemplo de saldo inicial do usuario €2000
        SaldoReal = 4500;  //Exemplo de saldo inicial do usuario R$4500
    }   

    public void MostrarSaldo()
    {
        System.Console.WriteLine($"Saldo de {Nome}:");
        System.Console.WriteLine($"USD: {SaldoDolar:N2}");
        System.Console.WriteLine($"EUR: {SaldoEuro:N2}");
        System.Console.WriteLine($"BRL: {SaldoReal:N2}");
    }
}