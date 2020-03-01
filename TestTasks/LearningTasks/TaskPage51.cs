using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using TestTasks.Models;
using TestTasks.Tools;

namespace TestTasks.LearningTasks
{
    public class TaskPage51
    {
        public TaskPage51()
        {
            ConsoleTool.WriteLineConsoleGreenMessage("Создадим экземпляр объекта Triangle по строковому наименованию и вызовем метод с параметром: ");

            Triangle triangle = new Triangle("Прямоугольный");
            Type myType = triangle.GetType();

            string typeName = myType.FullName;

            Type myTypeFromString = Type.GetType(typeName, false, true);

            
            var constructors = myTypeFromString.GetConstructors().Where(x=>x.GetParameters().Length>0).ToList();

            foreach (var constructor in constructors)
            {
                Triangle obj = (Triangle)constructor.Invoke(new object[] {"Равнобедренный"});
                var methods = myTypeFromString.GetMethods().Where(x => x.IsPublic && x.GetParameters().Length == 1 && !x.IsVirtual).ToList();
                foreach (var method in methods)
                {
                    if (method.Name == "TestMethodWithParamm")
                        method.Invoke(obj, new object[] { "Это : " });
                }

                ConsoleTool.WriteLineConsoleGreenMessage("Получим доступ к приватному свойству. Зададим его и потом отправим в консоль: ");
                var privateInt = obj.GetType().GetProperty("privateString", BindingFlags.Instance | BindingFlags.NonPublic);
                privateInt.SetValue(obj, "5"); 
                string value = (string)privateInt.GetValue(obj);
                Console.WriteLine(value);
            }

            










        }
    }
}
