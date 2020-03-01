using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TestTasks.Tools;

namespace TestTasks.Models
{
    public class DecartSpace : IEnumerable
    {
        private GeometricFigures geometricFigures = new GeometricFigures();
        private Triangles triangles = new Triangles();
        private Polygones polygones = new Polygones();
        private Elipses elipses = new Elipses();

        public DecartSpace()
        {
            FillGeometricFigures();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<GeometricFigure> GetEnumerator()
        {
            return geometricFigures.GetEnumerator();
        }

        private void FillGeometricFigures()
        {
            foreach (var triangle in triangles)
            {
                geometricFigures.AddItem(triangle);
            }
            foreach (var polygone in polygones)
            {
                geometricFigures.AddItem(polygone);
            }
            foreach (var elipse in elipses)
            {
                geometricFigures.AddItem(elipse);
            }
        }

        public void ConsoleAllGeometricFiguresUsingForeach()
        {
            ConsoleTool.WriteLineConsoleGreenMessage("Выведем все фигуры с использованием foreach: ");
            foreach (var geometricFigure in geometricFigures)
            {
                Console.WriteLine(geometricFigure.Name);
            }
        }

        public void ConsoleAllEllipsesUsingWhile()
        {
            ConsoleTool.WriteLineConsoleGreenMessage("Выведем все элипсы с использованием While и реализованного IEnumerator: ");
            IEnumerator iEnumerator = elipses.GetEnumerator();
            while (iEnumerator.MoveNext())
            {
                Elipse elipseItem = iEnumerator.Current as Elipse;
                Console.WriteLine(elipseItem.Name);
            }
        }
    }
}
