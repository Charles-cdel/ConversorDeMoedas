﻿using System;

namespace ConversorDeMoedas
{
    class Program
    {
        static void Main(string[] args)
        {
            GerenciadorDeUsuarios gerenciadorDeUsuarios = new GerenciadorDeUsuarios();
            Usuario usuarioLogado = null;

            // Menu inicial
            bool continuarMenu = true;
            while (continuarMenu)
            {
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1 - Login ou Cadastrar Usuário");
                Console.WriteLine("2 - Listar Usuários");
                Console.WriteLine("3 - Atualizar Usuário");
                Console.WriteLine("4 - Apagar Usuário");
                Console.WriteLine("5 - Sair");
                int escolha = int.Parse(Console.ReadLine());

                switch (escolha)
                {
                    case 1:
                        // Autenticação (login ou cadastro)
                        while (usuarioLogado == null)
                        {
                            usuarioLogado = gerenciadorDeUsuarios.LoginOuCadastrar();
                        }

                        string continuarConversao;
                        do
                        {
                            Console.WriteLine($"\nBem-vindo ao Conversor de Moedas, {usuarioLogado.Nome}!");
                            usuarioLogado.MostrarSaldo(); // Exibe o saldo inicial do usuário

                            Console.WriteLine("\nEscolha a moeda de origem:");
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

                            // Perguntar se o usuário deseja continuar
                            Console.WriteLine("Deseja fazer outra conversão? (S/N)");
                            continuarConversao = Console.ReadLine().ToUpper();

                        } while (continuarConversao == "S");
                        break;

                    case 2:
                        gerenciadorDeUsuarios.ListarUsuarios();
                        break;

                    case 3:
                        Console.WriteLine("Digite o nome do usuário que deseja atualizar:");
                        string nomeParaAtualizar = Console.ReadLine();
                        gerenciadorDeUsuarios.AtualizarUsuario(nomeParaAtualizar);
                        break;

                    case 4:
                        Console.WriteLine("Digite o nome do usuário que deseja apagar:");
                        string nomeParaApagar = Console.ReadLine();
                        gerenciadorDeUsuarios.ApagarUsuario(nomeParaApagar);
                        break;

                    case 5:
                        continuarMenu = false;
                        Console.WriteLine("Encerrando o programa...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
        }
    }
}
