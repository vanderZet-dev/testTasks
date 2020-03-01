using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TestTasks.Models
{
    public class CarPark : IEnumerable
    {
        private List<Car> cars;

        public CarPark()
        {
            cars = new List<Car>();
            cars.Add(new Car("Обычный автомобиль", 120, 4, "Бензин", 90));
            cars.Add(new CarWithElectronic("Авто напичканное электроникой", 150, 2, "Газ", 70));
            cars.Add(new Car("Обычный автомобиль 2", 250, 1, "Дизель", 80));
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<Car> GetEnumerator()
        {
            return cars.GetEnumerator();
        }
    }
}
