using System;
using System.Collections.Generic;
using System.Linq;
using TestTasks.Models;
using TestTasks.Models.Enums;
using TestTasks.Tools;

namespace TestTasks.LearningTasks
{
    public class TaskPage24
    {
        private List<Table> tables { get; set; }

        public TaskPage24 ()
        {
            GenerateRandomTables(100);
        }

        private void GenerateRandomTables(int count)
        {
            ConsoleTool.WriteLineConsoleGreenMessage("Вывод сгенерированных случайным образом экземпляров объекта Table:");
            tables = new List<Table>();
            for (int i = 0; i < 100; i++)
            {
                tables.Add(new Table(GetRandomMaterial().ToString(), GetRandomNumberOfLegs(), GetRandomDate(), GetRandomSold()));
                Console.WriteLine(tables[i].ToString());
            }
        }


        private Material GetRandomMaterial()
        {
            Array values = Enum.GetValues(typeof(Material));
            Random random = new Random();
            Material randomMaterial = (Material)values.GetValue(random.Next(values.Length));
            return randomMaterial;
        }

        private int GetRandomNumberOfLegs()
        {
            Random random = new Random();
            return random.Next(1, 8);
        }

        private bool GetRandomSold()
        {
            Random random = new Random();
            int result = random.Next(0, 2);
            if (result==0) return false;
            else return true;
        }

        private DateTime GetRandomDate()
        {
            Random random = new Random();
            int year = random.Next(2010, 2021);
            int month = random.Next(1, 13);
            int day = random.Next(1, 29);
           return new DateTime(year, month, day);
        }

        private List<Table> GetSoldTables()
        {
            return
                tables.Where(table => table.Sold == true).ToList();
        }

        private List<Table> GetTablesOrderByCreatedDateDesc()
        {
            return
                tables.OrderByDescending(table=>table.CreateDate).ToList();
        }

        private IEnumerable<dynamic> GroupTablesByMaterial()
        {
            var result = tables.GroupBy(table => table.Material)
                .Select(group => new
                {
                    Material = group.Key,
                    Count = group.Count()
                });

            return result;
        }

        private bool CheckForAllTablesSold()
        {
            return tables.All(tables => tables.Sold);
        }

        private bool CheckForAnyTablesSold()
        {
            return tables.Any(tables => tables.Sold);
        }

        private int GetMinLegsCount()
        {
            return tables.Min(table => table.NumberOfLegs);
        }

        private int GetMaxLegsCount()
        {
            return tables.Max(table => table.NumberOfLegs);
        }

        private int GetSumLegsCount()
        {
            return tables.Sum(table => table.NumberOfLegs);
        }

        public void ConsoleSoldTables()
        {
            ConsoleTool.WriteLineConsoleGreenMessage("Проданные столы:");
            var soldTables = GetSoldTables();
            foreach (var table in soldTables)
            {
                Console.WriteLine(table.ToString());
            }
        }

        public void ConsoleTablesOrderByCreatedDateDesc()
        {
            ConsoleTool.WriteLineConsoleGreenMessage("Cтолы, отсортированные по дате создания, начиная с последнего:");
            var tables = GetTablesOrderByCreatedDateDesc();
            foreach (var table in tables)
            {
                Console.WriteLine(table.ToString());
            }
        }

        public void ConsoleGroupedTablesByMaterial()
        {
            ConsoleTool.WriteLineConsoleGreenMessage("Группировка столов по использованному материалу:");
            var materials = GroupTablesByMaterial();
            foreach (var material in materials)
            {
                Console.WriteLine($"{material.Material} : {material.Count}");
            }
        }

        public void ConsoleCheckingResultForAllTablesSold()
        {
            ConsoleTool.WriteLineConsoleGreenMessage($"Все столы проданы : {CheckForAllTablesSold()}");
        }

        public void ConsoleCheckingResultForAnyTablesSold()
        {
            ConsoleTool.WriteLineConsoleGreenMessage($"Хотябы один стол продан : {CheckForAnyTablesSold()}");
        }

        public void ConsoleAnalyzingLegsCount()
        {
            ConsoleTool.WriteLineConsoleGreenMessage("Анализ количества ножек у столов:");

            int minLegsCount = GetMinLegsCount();
            int maxLegsCount = GetMaxLegsCount();
            int sumLegsCount = GetSumLegsCount();

            
            Console.WriteLine($"Минимальное количество ножек у стола: {minLegsCount}");
            Console.WriteLine($"Максимальное количество ножек у стола: {maxLegsCount}");
            Console.WriteLine($"Общее количество ножек у всех столов вместе: {sumLegsCount}");
        }
    }
}
