using System;

namespace CadastroDeSeries
{
    class Program
    {

        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUser = ObterOpcaoUsuario();

            while (opcaoUser.ToUpper() != "X")
            {
                switch (opcaoUser)
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
                        VisualisarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                        // default:
                        //throw new Exception;

                }
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Séries a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir séries");
            Console.WriteLine("5- Visualizar séries");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUser = Console.ReadLine().ToUpper();
            Console.WriteLine();

            return opcaoUser;

        }

        private static void ListarSerie()
        {
            Console.WriteLine("Listar séries");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach(var serie in lista)
            {
                bool excluido = serie.RetornaExcluido();
                if(!excluido)
                    Console.WriteLine("#ID {0}: - {1}", serie.retornaId(), serie.retornaTitulo());

            }
        }

        private static void InserirSerie()
        {

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));

            }

            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano de Inicio da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.proximoId(),
                genero: (Genero)entradaGenero,
                titulo: entradaTitulo,
                descricao: entradaDescricao,
                ano: entradaAno);

            repositorio.Insere(novaSerie);
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o id da Série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            //melhoria fazer metodo para reaproveitar
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));

            }

            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano de Inicio da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie,
                genero: (Genero)entradaGenero,
                titulo: entradaTitulo,
                descricao: entradaDescricao,
                ano: entradaAno);

            repositorio.Atualiza(indiceSerie, atualizaSerie);
        }


        private static void ExcluirSerie()
        {
            //melhorar mostrar qual e confirmar
            Console.WriteLine("Digite o id da Série: ");
            int id  = int.Parse(Console.ReadLine());

            repositorio.Exclui(id);
        }


        private static void VisualisarSerie()
        {
            Console.WriteLine("Digite o id da Série: ");
            int id = int.Parse(Console.ReadLine());

            Serie serie = repositorio.RetornaPorId(id);

            Console.WriteLine(serie);
        }

    }
}
