namespace Series
{
    public class Program
    {
        public static SerieRepository repo = new SerieRepository();
        public static void Main(string[] args)
        {
            var userOption = GetUserOption();

			while (userOption.ToUpper() != "X")
			{
				switch (userOption)
				{
					case "1":
						ShowSeries();
						break;
					case "2":
						AddSerie();
						break;
					case "3":
						UpdateSerie();
						break;
					case "4":
						RemoveSerie();
						break;
					case "5":
						ViewSerie();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				userOption = GetUserOption();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }

        private static void RemoveSerie()
		{
			Console.Write("Digite o id da série: ");
			int serieIndex = int.Parse(Console.ReadLine());

			repo.Remove(serieIndex);
		}

        private static void ViewSerie()
		{
			Console.Write("Digite o id da série: ");
			int serieIndex = int.Parse(Console.ReadLine());

			var serie = repo.GetForId(serieIndex);

			Console.WriteLine(serie);
		}

        private static void UpdateSerie()
		{
			Console.Write("Digite o id da série: ");
			int serieIndex = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genre)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int onGenre = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string onTitle = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int onYear = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string onDescription = Console.ReadLine();

			Serie updateSerie = new Serie(id: serieIndex,
										genre: (Genre)onGenre,
										title: onTitle,
										year: onYear,
										description: onDescription);

			repo.Update(serieIndex, updateSerie);
		}
        private static void ShowSeries()
		{
			Console.WriteLine("Listar séries");

			var repoList = repo.SerieList();

			if (repoList.Count == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");
				return;
			}

			foreach (var serie in repoList)
			{
                var removed = serie.IsRemoved();
                
				Console.WriteLine("#ID {0}: - {1} {2}", serie.GetId(), serie.GetTitle(), (removed ? "*Excluído*" : ""));
			}
		}

        private static void AddSerie()
		{
			Console.WriteLine("Inserir nova série");

			foreach (int i in Enum.GetValues(typeof(Genre)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int onGenre = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string onTitle = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int onYear = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string onDescription = Console.ReadLine();

			Serie newSerie = new Serie(id: repo.NextId(),
										genre: (Genre)onGenre,
										title: onTitle,
										year: onYear,
										description: onDescription);

			repo.Add(newSerie);
		}

        private static string GetUserOption()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Séries a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar séries");
			Console.WriteLine("2- Inserir nova série");
			Console.WriteLine("3- Atualizar série");
			Console.WriteLine("4- Excluir série");
			Console.WriteLine("5- Visualizar série");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string userOption = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return userOption;
		}
    }
}