using System;
using CadastroSeries.Classes;

namespace CadastroSeries
{
    class Program
    {
        static RepositorioSerie repositorio = new RepositorioSerie();
        static void Main(string[] args)
        {
            string opcao = Menu();
            while (opcao.ToUpper() != "X")
            {
                switch (opcao)
                {
                    case "1":
                        ListarSerie();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "6":
                        Console.Clear();

                        break;
                    default:
                        throw new ArgumentOutOfRangeException();

                }
                opcao = Menu();

            }
        }

        private static string Menu()
        {
            Console.WriteLine();
            Console.WriteLine("Escolha uma opção: ");
            Console.WriteLine("1 - Listar séries: ");
            Console.WriteLine("2 - Inserir nova série: ");
            Console.WriteLine("3 - Atualizar série: ");
            Console.WriteLine("4 - Excluir série: ");
            Console.WriteLine("5 - Visualizar série: ");
            Console.WriteLine("6 - limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcao = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcao;
        }
        private static void ListarSerie()
        {
            Console.WriteLine();
            Console.WriteLine("--- Listar Séries ---");
            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada!");
                return;

            }
            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                if (!excluido)
                {
                    Console.WriteLine("#ID {0}: - {1}", serie.retornaId(), serie.retornaTitulo());
                }
            }

        }

        private static void InserirSerie()
        {

            Console.WriteLine();
            Console.WriteLine("--- Inserir uma nova série ---");
            foreach (int i in Enum.GetValues(typeof(Genero))) //vai varrer todo o enum GetValue vai retornar as opcçoes e GetName vai mostrar
            {

                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o genero entre as opções acima: ");
            int genero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o titulo de série:");
            string titulo = Console.ReadLine();

            Console.WriteLine("Digite o ano da lançamento da série: ");
            int anoSerie = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da Série: ");
            string descricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(), genero: (Genero)genero, titulo: titulo, ano: anoSerie, descricao: descricao);


            repositorio.Insere(novaSerie);


        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o ID da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            foreach (int i in Enum.GetValues(typeof(Genero))) //vai varrer todo o enum GetValue vai retornar as opcçoes e GetName vai mostrar
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o genero entre as opções acima: ");
            int genero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o titulo de série:");
            string titulo = Console.ReadLine();

            Console.WriteLine("Digite o ano da lançamento da série: ");
            int anoSerie = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da Série: ");
            string descricao = Console.ReadLine();


            Serie atualizaSerie = new Serie(id: repositorio.ProximoId(), genero: (Genero)genero, titulo: titulo, ano: anoSerie, descricao: descricao);




            repositorio.Atualiza(indiceSerie, atualizaSerie);
        }
        private static void ExcluirSerie()
        {
            Console.WriteLine("Digite o ID da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            //colocar confirmação
            repositorio.Exclui(indiceSerie);

        }

        private static void VisualizarSerie()
        {
            Console.WriteLine("Digite o ID da Série: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            var serie = repositorio.RetornaPorId(indiceSerie);
            Console.WriteLine(serie);
        }
    }



}
