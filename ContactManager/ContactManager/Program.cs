using System;
using System.Collections.Generic;
using ContactManager.Model;
using ContactManager.Data;

namespace ContactManager
{
    class Program
    {
        static GerenciadorDeContatos gerenciador = new GerenciadorDeContatos();
        static List<Contato> contatos = new List<Contato>();

        static void Main(string[] args)
        {
            contatos = gerenciador.CarregarContatos();
            while (true)
            {
                MostrarMenu();
            }
        }

        static void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("Gerenciamento de Contatos");
            Console.WriteLine("1. Cadastrar Novo Contato");
            Console.WriteLine("2. Consultar Contatos");
            Console.WriteLine("3. Atualizar Contato");
            Console.WriteLine("4. Excluir Contato");
            Console.WriteLine("5. Sair");
            Console.Write("Escolha uma opção: ");

            switch (Console.ReadLine())
            {
                case "1":
                    CadastrarContato();
                    break;
                case "2":
                    ConsultarContatos();
                    break;
                case "3":
                    AtualizarContato();
                    break;
                case "4":
                    ExcluirContato();
                    break;
                case "5":
                    gerenciador.SalvarContatos(contatos);
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opção inválida! Pressione qualquer tecla para tentar novamente.");
                    Console.ReadKey();
                    break;
            }
        }

        static void CadastrarContato()
        {
            Console.Clear();
            Contato novoContato = new Contato();

            Console.Write("Nome Completo: ");
            novoContato.NomeCompleto = Console.ReadLine();

            Console.Write("Telefone: ");
            novoContato.Telefone = Console.ReadLine();

            Console.Write("Email: ");
            novoContato.Email = Console.ReadLine();

            Console.Write("Endereço: ");
            novoContato.Endereco = Console.ReadLine();

            Console.Write("Data de Nascimento (yyyy-MM-dd): ");
            novoContato.DataNascimento = DateTime.Parse(Console.ReadLine());

            Console.Write("Grupo: ");
            novoContato.Grupo = Console.ReadLine();

            contatos.Add(novoContato);
            Console.WriteLine("Contato cadastrado com sucesso! Pressione qualquer tecla para voltar ao menu.");
            Console.ReadKey();
        }

        static void ConsultarContatos()
        {
            Console.Clear();
            Console.WriteLine("1. Todos os Contatos");
            Console.WriteLine("2. Buscar por Nome");
            Console.WriteLine("3. Buscar por Grupo");
            Console.Write("Escolha uma opção: ");

            switch (Console.ReadLine())
            {
                case "1":
                    ListarContatos(contatos);
                    break;
                case "2":
                    BuscarPorNome();
                    break;
                case "3":
                    BuscarPorGrupo();
                    break;
                default:
                    Console.WriteLine("Opção inválida! Pressione qualquer tecla para tentar novamente.");
                    Console.ReadKey();
                    break;
            }
        }

        static void ListarContatos(List<Contato> contatos)
        {
            Console.Clear();
            foreach (var contato in contatos)
            {
                ExibirContato(contato);
            }
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
            Console.ReadKey();
        }

        static void ExibirContato(Contato contato)
        {
            Console.WriteLine($"Nome: {contato.NomeCompleto}");
            Console.WriteLine($"Telefone: {contato.Telefone}");
            Console.WriteLine($"Email: {contato.Email}");
            Console.WriteLine($"Endereço: {contato.Endereco}");
            Console.WriteLine($"Data de Nascimento: {contato.DataNascimento.ToShortDateString()}");
            Console.WriteLine($"Grupo: {contato.Grupo}");
            Console.WriteLine(new string('-', 20));
        }

        static void BuscarPorNome()
        {
            Console.Clear();
            Console.Write("Digite o nome para buscar: ");
            string nome = Console.ReadLine().ToLower();
            List<Contato> resultados = contatos.FindAll(c => c.NomeCompleto.ToLower().Contains(nome));
            ListarContatos(resultados);
        }

        static void BuscarPorGrupo()
        {
            Console.Clear();
            Console.Write("Digite o grupo para buscar: ");
            string grupo = Console.ReadLine().ToLower();
            List<Contato> resultados = contatos.FindAll(c => c.Grupo.ToLower().Contains(grupo));
            ListarContatos(resultados);
        }

        static void AtualizarContato()
        {
            Console.Clear();
            Console.Write("Digite o nome do contato a ser atualizado: ");
            string nome = Console.ReadLine().ToLower();
            Contato contato = contatos.Find(c => c.NomeCompleto.ToLower().Contains(nome));

            if (contato != null)
            {
                Console.Write("Novo Telefone: ");
                contato.Telefone = Console.ReadLine();

                Console.Write("Novo Email: ");
                contato.Email = Console.ReadLine();

                Console.Write("Novo Endereço: ");
                contato.Endereco = Console.ReadLine();

                Console.Write("Nova Data de Nascimento (yyyy-MM-dd): ");
                contato.DataNascimento = DateTime.Parse(Console.ReadLine());

                Console.Write("Novo Grupo: ");
                contato.Grupo = Console.ReadLine();

                Console.WriteLine("Contato atualizado com sucesso! Pressione qualquer tecla para voltar ao menu.");
            }
            else
            {
                Console.WriteLine("Contato não encontrado! Pressione qualquer tecla para voltar ao menu.");
            }
            Console.ReadKey();
        }

        static void ExcluirContato()
        {
            Console.Clear();
            Console.Write("Digite o nome do contato a ser excluído: ");
            string nome = Console.ReadLine().ToLower();
            Contato contato = contatos.Find(c => c.NomeCompleto.ToLower().Contains(nome));

            if (contato != null)
            {
                contatos.Remove(contato);
                Console.WriteLine("Contato excluído com sucesso! Pressione qualquer tecla para voltar ao menu.");
            }
            else
            {
                Console.WriteLine("Contato não encontrado! Pressione qualquer tecla para voltar ao menu.");
            }
            Console.ReadKey();
        }
    }
}
