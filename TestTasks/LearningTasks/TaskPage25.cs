using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestTasks.Models;
using TestTasks.Tools;

namespace TestTasks.LearningTasks
{
    public class TaskPage25
    {
        public TaskPage25()
        {
            
        }

        public void ConsoleTestComparer()
        {
            ConsoleTool.WriteLineConsoleGreenMessage("Тетируем сориторвку через IComparable с использование реверса (по объему): ");

            List<Polygon> polygones = new List<Polygon>
            {
                new Polygon("Прямоугольник 1", 7),
                new Polygon("Прямоугольник 2", 12),
                new Polygon("Прямоугольник 3", 58),
                new Polygon("Прямоугольник 4", 11),
                new Polygon("Прямоугольник 5", 47),
                new Polygon("Прямоугольник 6", 36),
                new Polygon("Прямоугольник 7", 47),
                new Polygon("Прямоугольник 8", 25),
                new Polygon("Прямоугольник 9", 4),
                new Polygon("Прямоугольник 10", 5)
            };

            polygones.Sort();
            polygones.Reverse();

            foreach (var polygon in polygones)
            {
                Console.WriteLine(polygon.ToString());
            }

            ConsoleTool.WriteLineConsoleGreenMessage("Тетируем сориторвку через IComparator (по длине имени): ");
            polygones.Sort(new PolygonComparer());

            foreach (var polygon in polygones)
            {
                Console.WriteLine(polygon.ToString());
            }
        }
    }
}
