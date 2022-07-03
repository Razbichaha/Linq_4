using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq_4
{
    class Program
    {
        static void Main(string[] args)
        {
            ProgramCore programCore = new();
            programCore.Start();
            Console.ReadLine();
        }
    }

    class ProgramCore
    {
        private List<Player> _players = new List<Player>();

        internal ProgramCore()
        {
            GeneratePlayers();
        }

        internal void Start()
        {
            int numberTopPlayers = 3;
            Console.Clear();
            Console.WriteLine("Для продолжения нажмите Enter");

            GeneratePlayers();
            ShowAllPlayer();

            Console.WriteLine();
            Console.WriteLine($"Топ {numberTopPlayers} по Уровню");
            Console.WriteLine();

            SortlevelBestPlayers(numberTopPlayers);

            Console.WriteLine();
            Console.WriteLine($"Топ {numberTopPlayers} по Силе");
            Console.WriteLine();

            SortStrengthBestPlayers(numberTopPlayers);
        }

        private void SortStrengthBestPlayers(int numberTopPlayers)
        {
            var sorted = from player in _players orderby player.Strength descending select player;
            var topPlayers = sorted.Take(numberTopPlayers);

            ShowListPlayer(topPlayers.ToList());
        }

        private void SortlevelBestPlayers(int numberTopPlayers)
        {
            var sorted = from player in _players orderby player.Level descending select player;
            var topPlayers = sorted.Take(numberTopPlayers);

            ShowListPlayer(topPlayers.ToList());
        }

        private void ShowListPlayer(List<Player> players)
        {
            foreach (Player player in players)
            {
                ShowPlayer(player);
            }
        }

        private void ShowAllPlayer()
        {
            Console.Clear();

            foreach (Player player in _players)
            {
                ShowPlayer(player);
            }
        }

        private void ShowPlayer(Player player)
        {
            Console.WriteLine($" {player.Name} | Уровень - {player.Level} | Сила - {player.Strength}");
        }

        private void GeneratePlayers()
        {
            int quantityPlayers = 15;

            for (int i = 0; i < quantityPlayers; i++)
            {
                Player player = new Player();
                _players.Add(player);
            }
        }
    }

    class Player
    {
        internal string Name { get; private set; }
        internal int Level { get; private set; }
        internal int Strength { get; private set; }

        public Player()
        {
            GenerateName();
            GenerateLevel();
            GenerateStrength();
        }

        private void GenerateName()
        {
            string[] NameBase = { "Нестер", "Самиров"
                , "Рязанцев", "Геннадьевич", "Ксения"
                , "Романович", "Николай", "Петухина", "Вадим"
                , "Маргарита", "Точилкина", "Батраков", "Вязмитинова"
                , "Индейкина", "Колосюк", "Михаил", "Хорошилова"
                , "Павел", "Вероника", "Дмитрий", "Тельпугова"
                , "Биушкина", "Николай", "Александр", "Вероника"
                , "Ирина", "Тактаров", "Борис", "Полина"
                , "Спиридонов", "Лоринова", "Ряхин", "Юльева"
                , "Олег", "Глеб", "Тимофей", "Артур"};
            Random random = new Random();

            Name = NameBase[random.Next(NameBase.Length)];
        }

        private void GenerateLevel()
        {
            Random random = new();
            int maximumYaers = 90;
            Level = random.Next(maximumYaers);
        }

        private void GenerateStrength()
        {
            Random random = new();
            int maximumStrength = 1000;
            Strength = random.Next(maximumStrength);
        }
    }
}
