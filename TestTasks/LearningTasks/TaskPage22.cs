using System;
using System.Collections.Generic;
using System.Text;
using TestTasks.Models;
using TestTasks.Tools;

namespace TestTasks.LearningTasks
{
    public class TaskPage22
    {
        private CarPark carPark;

        private FoodBasket foodBasket;

        private DecartSpace decartSpace;

        public TaskPage22()
        {
            carPark = new CarPark();
            foodBasket = new FoodBasket();
            decartSpace = new DecartSpace();
        }

        public void ConsoleCarParkElementWithEnumerator()
        {
            ConsoleTool.WriteLineConsoleGreenMessage("Вывод авто из автопарка с использованием Enumerator: ");
            foreach (Car car in carPark)
            {
                Console.WriteLine(car.ToString());
            }
        }

        public void ConsoleFoodBasketItems()
        {
            ConsoleTool.WriteLineConsoleGreenMessage("Я сделал перечисления для каждого из классов на основе List. Собрал их всех в один список в классе FoodBasket. И через енумератор класса FoodBasket вывожу ниже: ");
            foreach (Food food in foodBasket)
            {
                Console.WriteLine(food.Name);
            }
        }

        public void ConsoleAllGeometricFiguresUsingForeach()
        {
            decartSpace.ConsoleAllGeometricFiguresUsingForeach();
        }

        public void ConsoleAllEllipsesUsingWhile()
        {
            decartSpace.ConsoleAllEllipsesUsingWhile();
        }
    }
}
