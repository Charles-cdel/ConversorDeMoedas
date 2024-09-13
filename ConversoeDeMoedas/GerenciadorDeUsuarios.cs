using System;
using System.Collections.Generic;
using System.IO;

namespace ConversorDeMoedas;

public class GerenciadorDeUsuarios()
{
    private List<Usuario> usuarios = new List<Usuario>();
    private const string caminhoArquivo = "usuarios.txt";

}

public GerenciadorDeUsuarios()
{
    CarregarUsuariosDoArquvo();
}

public Usuario LoginOuCadastrar()
{
    Console.WriteLine("1-Login");
    Console.WriteLine("2-Cadastrar novo usuario");
    int escolha = int.Parse(Console.ReadLine());

    if(escolha == 1)
    {
        return Login();
    }
    else if(escolha == 2)
    {
        return Cadastrar();
    }

    return null;


}

public Usuario Login()
{
    Console.WriteLine("Digite o nome do usuario: ");
    string nome = Console.ReadLine();

    foreach (var usuario in usuarios)
    {
        if (Usuario.Nome == nome)
        {
            Console.WriteLine($"Bem-vindo de volta, {nome}!");
            return usuario;
        }
    }

    Console.WriteLine("Usuário não encontrado.");
    return null;
}

public string Usuário Cadastrar()
{
    Console.WriteLine("Digite o nome do novo usuário:");
    string nome = Console.ReadLine();

    Usuario novoUsuario = new Usuario(nome);
    usuarios.Add(novoUsuario);

    SalvarUsuariosNoArquivo();

    Console.WriteLine($"Usuário {nome} cadastrado com sucesso!");
    return novoUsuario;
}

  public void ListarUsuarios()
  {
    Console.WriteLine("Lista de Usuários Registrados:");

    foreach (var usuario in usuarios)
    {
       Console.WriteLine(usuario.Nome);
    }

  } 

  private void CarregarUsuariosDoArquivo()
  {

    if (File.Exists("usuarios.txt"))
    {
        var linhas = File.ReadAllLines("usuarios.txt");
        
        foreach (var usuario in usuarios)
        {
            var dados = linha.Split(',');

            if (dados.Length == 4)
            {
                string nome = dados[0];

                double saldoDolar = double.Parse(dados[1]);
                double saldoEuro = double.Parse(dados[2]);
                double saldoReal = double.Parse(dados[3]);

                Usuario usuario = new Usuario(nome)
                {
                    SaldoDolar = saldoDolar,
                    SaldoEuro = saldoEuro,
                    SaldoReal = saldoReal

                };
             usuarios.Add(usuario);

            }

            
        }

    }
}

private void SalvarUsuariosNoArquivo()
{
    using (StreamWriter writer = new StreamWriter("usuarios.txt"))
    {
        foreach (var usuario in usuarios)
        {
            writer.WriteLine($"{usuario.Nome},{usuario.SaldoDolar},{usuario.SaldoEuro},{usuario.SaldoReal}");

        }
    }
}