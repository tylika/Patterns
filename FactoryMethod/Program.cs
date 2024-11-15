using System;
namespace FactoryMethodExample
{   
    public abstract class DrinkFactory
    {
        public abstract Drink CreateDrink(int type);
    }

    public class ConcreteDrinkFactory : DrinkFactory
    {
        public override Drink CreateDrink(int type)
        {
            switch (type)
            {
               
                case 1: return new Tea();
             
                case 2: return new Coffee();
             
                case 3: return new Juice();
                default: throw new ArgumentException("Invalid type.", "type");
            }
        }
    }

  
    public abstract class Drink
    {
        public abstract void Serve();
    }

  
    public class Tea : Drink
    {
        public override void Serve()
        {
            Console.WriteLine("Подається гарячий чай із лимоном.");
        }
    }

    // Конкретний продукт - Кава
    public class Coffee : Drink
    {
        public override void Serve()
        {
            Console.WriteLine("Подається гаряча кава з молоком.");
        }
    }

  
    public class Juice : Drink
    {
        public override void Serve()
        {
            Console.WriteLine("Подається свіжовичавлений апельсиновий сік.");
        }
    }

    class MainApp
    {
        static void Main()
        {
         
            DrinkFactory factory = new ConcreteDrinkFactory();

            for (int i = 1; i <= 3; i++)
            {
             
                var drink = factory.CreateDrink(i);
                Console.Write($"Тип {i}: ");
                drink.Serve();
            }

            Console.ReadKey();
        }
    }
}

