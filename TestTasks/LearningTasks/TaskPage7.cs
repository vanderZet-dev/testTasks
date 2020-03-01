using System;
using System.Collections.Generic;
using System.Text;
using TestTasks.Exceptions;
using TestTasks.Models;
using TestTasks.Tools;

namespace TestTasks.LearningTasks
{
    public class TaskPage7
    {
        private List<Transport> transports;

        public TaskPage7 ()
        {
            Car car = new Car("Обычный автомобиль", 120, 4, "Бензин", 90);
            CarWithElectronic carWithElectronic = new CarWithElectronic("Авто напичканное электроникой", 150, 2, "Дизель", 70);
            Bicycle bicycle = new Bicycle("Велосипед", 40, 2);

            ConsoleTool.WriteLineConsoleGreenMessage("Ниже представлены экземпляры объектов разных типов, но все они объединены одним базовым типом Transport через наследование.");
            ConsoleTool.WriteLineConsoleGreenMessage("Car и Bicycle унаследованы от Transport. CarWithElectronic унаследован от Car.");
            ConsoleTool.WriteLineConsoleGreenMessage("Вывожу о них данные я через foreach. И тут мне помогает полиморфизм, потому что я добавил все эти три экземпляра разных объектов в одну коллекцию под их общим типом.");

            transports = new List<Transport>() { car, carWithElectronic, bicycle };
            Console.WriteLine();
            foreach (Transport transport in transports)
            {
                Console.WriteLine(transport.ToString());
            }

            ConsoleTool.WriteLineConsoleGreenMessage("В качестве примера инкапсуляции можно рассмотреть метод StartEngine объекта CarWithElectronic, который сначало проверяет работают ли все системы должным образом, а только потом запускает базовый метод запуска мотора от класса Car.");
            ConsoleTool.WriteLineConsoleGreenMessage("Метод класса Car StartEngine сначало проверит, есть ли в баке авто топливо для запуска. Есть есть - мотор будет запущен. Если нет, выводится текст исключения. Это также пример инкапсуляции.");

            try
            {
                carWithElectronic.StartEngine();
            }
            catch (TransportException ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                carWithElectronic.ForcedStartEngine();
            }
            catch (TransportException ex)
            {
                Console.WriteLine(ex.Message);
            }

            ConsoleTool.WriteLineConsoleGreenMessage("Давайте заправим этого зверя. Могли бы это сделать через метод. Но тут я хочу продемонстрировать инкапсуляцию на примере свойства. Перед присвоением здесь мы сначало сравним новое значение с максимальным, чтобы не переполнить топливный бак. И выставим то, что будет больше. Дальше попробуем снова запустить мотор.");

            try
            {
                carWithElectronic.AvailFuel = 100;
            }
            catch (TransportException ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                carWithElectronic.ForcedStartEngine();
            }
            catch (TransportException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
