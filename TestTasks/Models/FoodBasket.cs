using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TestTasks.Models
{
    public class FoodBasket: IEnumerable
    {
        private List<Food> foods = new List<Food>();

        private Mushrooms mushrooms = new Mushrooms();

        private Berries berries = new Berries();

        public FoodBasket()
        {
            foreach (Mushroom mushroom in mushrooms)
            {
                foods.Add(mushroom);
            }
            foreach (Berry berries in berries)
            {
                foods.Add(berries);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<Food> GetEnumerator()
        {
            return foods.GetEnumerator();
        }
    }
}
