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
        private List<Plaer> _plaers = new List<Plaer>();

        internal ProgramCore()
        {
            GeneratePlaers();
        }

        internal void Start()
        {
            Console.Clear();
            Console.WriteLine("Для продолжения нажмите Enter");

            GeneratePlaers();
            ShowAllPlaer();

            Console.WriteLine();
            Console.WriteLine("Топ 3 по Уровню");

            SortedTop3Level();

            Console.WriteLine();
            Console.WriteLine("Топ 3 по Силе");
            Console.WriteLine();

            SortedTop3Strength();
        }

        private void SortedTop3Strength()
        {
            int skip = 3;
            var sorted = from Plaer in _plaers orderby Plaer.Strength descending select Plaer;
            var top3 = sorted.SkipLast(sorted.Count() - skip);

            foreach (Plaer plaer in top3)
            {
                ShowPlaer(plaer);
            }
        }

        private void SortedTop3Level()
        {
            int skip = 3;
            var sorted = from Plaer in _plaers orderby Plaer.Level descending select Plaer;
            var top3 = sorted.SkipLast(sorted.Count() - skip);

            foreach (Plaer plaer in top3)
            {
                ShowPlaer(plaer);
            }
        }

        private void ShowAllPlaer()
        {
            Console.Clear();

            foreach (Plaer plaer in _plaers)
            {
                ShowPlaer(plaer);
            }
        }

        private void ShowPlaer(Plaer plaer)
        {
            Console.WriteLine($" {plaer.Name} | Уровень - {plaer.Level} | Сила - {plaer.Strength}");
        }

        private void GeneratePlaers()
        {
            int quantityPlaers = 15;

            for (int i = 0; i < quantityPlaers; i++)
            {
                Plaer plaer = new Plaer();
                _plaers.Add(plaer);
            }
        }
    }

    class Plaer
    {
        internal string Name { get; private set; }
        internal int Level { get; private set; }
        internal int Strength { get; private set; }

        public Plaer()
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
