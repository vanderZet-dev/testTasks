using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using TestTasks.Exceptions;
using TestTasks.Models;
using TestTasks.LearningTasks;

namespace TestTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            //Принципы ООП
            //TaskPage7 taskPage7 = new TaskPage7();

            //ICloneable (поверхностное и глубокое клонирование)
            //TaskPage15 taskPage15 = new TaskPage15();

            //Явное и неявное преобрахование. Тестирование сравнений через Equals() или ==
            //TaskPage18 taskPage18 = new TaskPage18();

            //Тестируем скорость упаковки и распаковки
            //TaskPage20 taskPage20 = new TaskPage20();

            //Работа с множествами. Вывод через IEnumerator. Тест foreach и while.
            //TaskPage22 taskPage22 = new TaskPage22();
            //taskPage22.ConsoleCarParkElementWithEnumerator();
            //taskPage22.ConsoleFoodBasketItems();
            //taskPage22.ConsoleAllGeometricFiguresUsingForeach();
            //taskPage22.ConsoleAllEllipsesUsingWhile();

            //Работа с LINQ по выборкам
            //TaskPage24 taskPage24 = new TaskPage24();
            //taskPage24.ConsoleSoldTables();
            //taskPage24.ConsoleTablesOrderByCreatedDateDesc();
            //taskPage24.ConsoleGroupedTablesByMaterial();
            //taskPage24.ConsoleCheckingResultForAllTablesSold();
            //taskPage24.ConsoleCheckingResultForAnyTablesSold();
            //taskPage24.ConsoleAnalyzingLegsCount();

            //Демонстрируем работу IComparable и IComparator
            //TaskPage25 taskPage25 = new TaskPage25();
            //taskPage25.ConsoleTestComparer();

            //Переопределение и тестирование Equal() и GetHashCode()
            //TaskPage31 taskPage31 = new TaskPage31();
            //taskPage31.ConsoleTestStringComparer();
            //taskPage31.ConsoleTestPersonEqual();
            //taskPage31.ConsoleTestPersonGetHashCode();

            //Справочник места о работе. Поиск объектов, которые есть точно в словаре. Поиск объекта, которого в словаре точно нет.
            //TaskPage33 taskPage33 = new TaskPage33();
            //taskPage33.ConsoleFindPersonWorkPlaceByPersonData();

            //Коллекция с уникальными объектами
            //TaskPage36 taskPage36 = new TaskPage36();

            //Демонстрация работы INotifyPropertyChanged. Умная очередь. Анализатор потока чисел.
            //TaskPage40 taskPage40 = new TaskPage40();
            //taskPage40.ConsoleTestINotifyPropertyChanged();
            //taskPage40.ConsoleTestStackWithNotify();
            //taskPage40.ConsoleTestNumberAnalyzer();

            //Метод расширения для int
            //TaskPage49 taskPage49 = new TaskPage49();

            //Рефлексия
            //TaskPage51 taskPage51 = new TaskPage51();

            //Сериализация/Десериализация
            //TaskPage55 taskPage55 = new TaskPage55();
            //taskPage55.ConsoleBinaryTest();
            //taskPage55.ConsoleBinaryRecursionTest();

            //Регулярки
            //TaskPage58 taskPage58 = new TaskPage58();
            //taskPage58.ConsoleGetNumbersFromText();
            //taskPage58.ConsoleGetParamsFromURL();
            //taskPage58.ConsoleRemoveRepeatableSpaces();
            //taskPage58.ConsoleCheckForCorrectNumber();

            //Сравнение скорости последовательного и праллельного вычисления для разных объекмов данных
            //TaskPage63 taskPage63 = new TaskPage63();
            //taskPage63.ConsoleAverageDecimal10Mb();
            //taskPage63.ConsoleParallelAverageDecimal10Mb();
            //taskPage63.ConsoleAverageDecimal100Mb();
            //taskPage63.ConsoleParallelAverageDecimal100Mb();
            //taskPage63.ConsoleAverageDecimal1000Mb();
            //taskPage63.ConsoleParallelAverageDecimal1000Mb();
            //taskPage63.ConsoleResultDescription();

            

            //Работа с управлением списком задач через параллельные потоки. Не удалось реализовать только выставление статуса IsCanceled при отмене задачи.
            TaskPage63_2_Alter taskPage632Alter = new TaskPage63_2_Alter();
        }

    }
}
