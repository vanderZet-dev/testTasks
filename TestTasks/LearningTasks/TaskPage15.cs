using System;
using System.Collections.Generic;
using System.Text;
using TestTasks.Models;
using TestTasks.Tools;

namespace TestTasks.LearningTasks
{
    public class TaskPage15
    {
        private List<Transport> transports;

        public TaskPage15 ()
        {
            Car car = new Car("Обычный автомобиль", 120, 4, "Бензин", 90);
            CarWithElectronic carWithElectronic = new CarWithElectronic("Авто напичканное электроникой", 150, 2, "Дизель", 70);
            Bicycle bicycle = new Bicycle("Велосипед", 40, 2);

            transports = new List<Transport>() { car, carWithElectronic, bicycle };

            ConsoleTool.WriteLineConsoleGreenMessage("Опробуем поверхностное клонирование объекта с использованием небезизвестного интерфейса.");
            var clonedBicycle = (Bicycle)bicycle.Clone();
            transports.Add(clonedBicycle);
            ConsoleTool.WriteLineConsoleGreenMessage("Выведем текущую инфомрацию по оригинальному и клонированному объектам. Она должна быть одинаковой: ");
            Console.WriteLine(bicycle.ToString());
            Console.WriteLine(clonedBicycle.ToString());

            ConsoleTool.WriteLineConsoleGreenMessage("А теперь изменим все три свойства для оригинального объекта. Эти изменения не должны затронуть клонированный. Затем повторим вывод: ");
            bicycle.Name = "Переименованный велосипед";
            bicycle.MaxSpeed = 10;
            bicycle.PassengerCapacity = 1;
            Console.WriteLine(bicycle.ToString());
            Console.WriteLine(clonedBicycle.ToString());

            ConsoleTool.WriteLineConsoleGreenMessage("Рассмотрим пример использования глубокого клонирования. Он используется, когда класс имеет в своей структер поле с сылочным типом данных. Добавим нового водителя к нашему велосипеду.");
            bicycle.TransportDriver = new Driver("Алексей");

            ConsoleTool.WriteLineConsoleGreenMessage("Клонируем наш велосипед еще раз.");
            var moreClonedBicycle = (Bicycle)bicycle.Clone();
            transports.Add(moreClonedBicycle);
            Console.WriteLine(moreClonedBicycle.ToString());

            ConsoleTool.WriteLineConsoleGreenMessage("Теперь переименуем водителя первого велосипеда и выведем все три имеющиеся у нас велосипеды новым способом: ");
            bicycle.TransportDriver.Name = "Александр";
            foreach (Transport transport in transports)
            {
                if (transport is Bicycle) Console.WriteLine(transport.ToString());
            }
        }
    }
}
