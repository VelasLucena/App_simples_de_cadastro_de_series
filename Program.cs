using System;

namespace Projeto01
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();

        static void Main(string[] args)
        {
            string opcaoEscolhida = OpcaoDoUsuario();

            while (opcaoEscolhida.ToUpper() != "X")
            {
                switch (opcaoEscolhida)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizaSerie();
                        break;
                    case "4":
                        ExcuirSerie();
                        break;
                    case "5":
                        VizualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoEscolhida = OpcaoDoUsuario();
            }

            Console.WriteLine("Obrigado or utilizar nossos serviços");
            Console.WriteLine();
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar Séries");
            var lista = repositorio.Lista();
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.RetornaExcluido();
                if (!excluido)
                {
                    Console.WriteLine("#ID {0}: - {1}", serie.RetornaId(), serie.RetornaTitulo());
                }
            }
        }

        private static void InserirSerie()
        {
            foreach (int i in Enum.GetValues(typeof(Categorias)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Categorias), i));
            }
            Console.WriteLine("Digite o genêro entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Titulo da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Series novaSerie = new Series(id: repositorio.ProximoId(), categorias: (Categorias)entradaGenero, titulo: entradaTitulo, ano: entradaAno, descricao: entradaDescricao);

            repositorio.Insere(novaSerie);
        }

        private static void AtualizaSerie()
        {
            Console.WriteLine("Qual ID da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Categorias)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Categorias), i));
            }
            Console.WriteLine("Digite o genêro entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Titulo da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Series atualizaSerie = new Series(id: indiceSerie, categorias: (Categorias)entradaGenero, titulo: entradaTitulo, ano: entradaAno, descricao: entradaDescricao);

            repositorio.Atualiza(indiceSerie, atualizaSerie);
        }

        private static void ExcuirSerie()
        {
            Console.WriteLine("Digite o id da série:");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);

        }

        private static void VizualizarSerie()
        {
            Console.WriteLine("Digite o id da série:");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
        }

        private static string OpcaoDoUsuario()
        {
                Console.WriteLine();
                Console.WriteLine("Projeto01 Séries!");
                Console.WriteLine("Informe a opção desejada:");

                Console.WriteLine("1 - Listar séries");
                Console.WriteLine("2 - Inserir nova série");
                Console.WriteLine("3 - Atualizar série");
                Console.WriteLine("4 - Excluir série");
                Console.WriteLine("5 - Vizualizar série");
                Console.WriteLine("C - Limpar tela");
                Console.WriteLine("X - Sair");

                string OpcaoEscolhida = Console.ReadLine().ToUpper();
                Console.WriteLine();
                return OpcaoEscolhida;
        }


    }
}
