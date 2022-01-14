using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            //Serie meuObjeto = new Serie ();
            
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                        ListaSeries();
                        break;
                    case "2":
                        InserirSeries();
                        break;
                    case "3":
                        AtualizarSeries();
                        break;
                    case "4":
                        ExcluirSeries();
                        break;
                    case "5":
                        VisualizarSeries();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default :
                        throw new ArgumentOutOfRangeException();    
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }       

            Console.Write("Obrigado por utlizar nossos serviços");
            Console.ReadLine();    
        }

        private static void ListaSeries()
        {
            Console.Write("Listar serie: ");
            var  lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.Write("Nenhuma seria cadastrada.");
                return;
            }

            foreach( var serie in lista)
            {
                var excluido = serie.retornaExcluido();

                Console.Write("#ID {0}: - {1} - {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "Excluido" : ""));
            }
        }

        private static void InserirSeries()
        {
            Console.Write("Inserir nova serie: ");

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i , Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o Genero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Titulo da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano de Inicio da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();
            
            Serie novaSerie = new Serie(id: repositorio.ProximoId(), 
                                        genero: (Genero)entradaGenero, 
                                        titulo: entradaTitulo, 
                                        descricao: entradaDescricao,
                                        ano: entradaAno);
            repositorio.Insere(novaSerie);
        }

        private static void AtualizarSeries()
        {
            Console.WriteLine("Digite o id da serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i , Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o genero entre as opções acima:");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Titul da serie");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano da serie: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição da serie: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie, 
                                        genero: (Genero)entradaGenero, 
                                        titulo: entradaTitulo, 
                                        descricao: entradaDescricao,
                                        ano: entradaAno);
            repositorio.Atualizar(indiceSerie, atualizaSerie);

            }
        private static void ExcluirSeries()
        {
            Console.WriteLine("Digite o id da serie");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
        }

        private static void VisualizarSeries()
        {
            Console.WriteLine("Digite o id da serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);
             Console.WriteLine(serie);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Series a seu dispor !!!");
            Console.WriteLine("Informe a opção desejada: ");
            Console.WriteLine("1- Listar series");
            Console.WriteLine("2- Inserir nova serie");
            Console.WriteLine("3- Atualizar serie");
            Console.WriteLine("4- Excluir serie");
            Console.WriteLine("5- Visualizar serie");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaUsuario;
        }
    }
}
