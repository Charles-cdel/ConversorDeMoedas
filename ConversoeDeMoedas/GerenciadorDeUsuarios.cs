using System;
using System.Collections.Generic;
using System.IO;

namespace ConversorDeMoedas
{
    public class GerenciadorDeUsuarios
    {
        private List<Usuario> usuarios = new List<Usuario>();
        private const string caminhoArquivo = "usuarios.txt";

        public GerenciadorDeUsuarios()
        {
            CarregarUsuariosDoArquivo();
        }

        public Usuario LoginOuCadastrar()
        {
            Console.WriteLine("1 - Login");
            Console.WriteLine("2 - Cadastrar novo usuário");
            int escolha = int.Parse(Console.ReadLine());

            if (escolha == 1)
            {
                return Login();
            }
            else if (escolha == 2)
            {
                return Cadastrar();
            }

            return null;
        }

        public Usuario Login()
        {
            Console.WriteLine("Digite o nome do usuário:");
            string nome = Console.ReadLine();

            foreach (var usuario in usuarios)
            {
                if (usuario.Nome == nome)
                {
                    Console.WriteLine($"Bem-vindo de volta, {nome}!");
                    return usuario;
                }
            }

            Console.WriteLine("Usuário não encontrado.");
            return null;
        }

        public Usuario Cadastrar()
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
            Console.WriteLine("Lista de Usuários Registrados: ");
            foreach (var usuario in usuarios)
            {
                Console.WriteLine(usuario.Nome);
            }
        }

        public void AtualizarUsuario(string nome)
        {
            Usuario usuario = usuarios.Find(u => u.Nome == nome);

            if (usuario != null)
            {
                Console.WriteLine($"Atualizando o usuário: {nome}");

                Console.WriteLine("Digite o novo nome (ou deixe em branco para manter o atual):");
                string novoNome = Console.ReadLine();

                if (!string.IsNullOrEmpty(novoNome))
                {
                    usuario.Nome = novoNome;
                }

                Console.WriteLine("Digite o novo saldo em Dólares (ou deixe em branco para manter o atual):");
                string novoSaldoDolar = Console.ReadLine();

                if (!string.IsNullOrEmpty(novoSaldoDolar))
                {
                    usuario.SaldoDolar = double.Parse(novoSaldoDolar);
                }

                Console.WriteLine("Digite o novo saldo em Euros (ou deixe em branco para manter o atual):");
                string novoSaldoEuro = Console.ReadLine();

                if (!string.IsNullOrEmpty(novoSaldoEuro))
                {
                    usuario.SaldoEuro = double.Parse(novoSaldoEuro);
                }

                Console.WriteLine("Digite o novo saldo em Reais (ou deixe em branco para manter o atual):");
                string novoSaldoReal = Console.ReadLine();

                if (!string.IsNullOrEmpty(novoSaldoReal))
                {
                    usuario.SaldoReal = double.Parse(novoSaldoReal);
                }

                SalvarUsuariosNoArquivo();
                Console.WriteLine("Usuário atualizado com sucesso!");
            }
            else
            {
                Console.WriteLine("Usuário não encontrado.");
            }
        }

      
        public void ApagarUsuario(string nome)
        {
            Usuario usuario = usuarios.Find(u => u.Nome == nome);

            if (usuario != null)
            {
                usuarios.Remove(usuario);
                SalvarUsuariosNoArquivo();
                Console.WriteLine($"Usuário {nome} removido com sucesso!");
            }
            else
            {
                Console.WriteLine("Usuário não encontrado.");
            }
        }

        private void CarregarUsuariosDoArquivo()
        {
            if (File.Exists(caminhoArquivo))
            {
                var linhas = File.ReadAllLines(caminhoArquivo);

                foreach (var linha in linhas)
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
            using (StreamWriter writer = new StreamWriter(caminhoArquivo))
            {
                foreach (var usuario in usuarios)
                {
                    writer.WriteLine($"{usuario.Nome},{usuario.SaldoDolar},{usuario.SaldoEuro},{usuario.SaldoReal}");
                }
            }
        }
    }
}
