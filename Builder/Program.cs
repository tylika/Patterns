using System;

namespace Builder
{
    class Program
    {
        class Pizza
        {
            private string dough;
            private string sauce;
            private string topping;
            private PizzaBox box; 

            public Pizza() { }

            public void SetDough(string d) { dough = d; }
            public void SetSauce(string s) { sauce = s; }
            public void SetTopping(string t) { topping = t; }
            public void SetBox(PizzaBox b) { box = b; } 

            public void Info()
            {
                Console.WriteLine("Dough: {0}\nSauce: {1}\nTopping: {2}", dough, sauce, topping);
                if (box != null)
                {
                    Console.WriteLine("Box size: {0}", box.Size);
                }
            }
        }

        class PizzaBox
        {
            public string Size { get; private set; }

            public PizzaBox(string size)
            {
                Size = size;
            }
        }
        abstract class PizzaBuilder
        {
            protected Pizza pizza;
            public PizzaBuilder() { }

            public Pizza GetPizza() { return pizza; }
            public void CreateNewPizza() { pizza = new Pizza(); }

            public abstract void BuildDough();
            public abstract void BuildSauce();
            public abstract void BuildTopping();
            public abstract void BuildBox(); 
        }
        class HawaiianPizzaBuilder : PizzaBuilder
        {
            public override void BuildDough() { pizza.SetDough("cross"); }
            public override void BuildSauce() { pizza.SetSauce("mild"); }
            public override void BuildTopping() { pizza.SetTopping("ham+pineapple"); }
            public override void BuildBox() { pizza.SetBox(new PizzaBox("Large")); } 
        }
        class SpicyPizzaBuilder : PizzaBuilder
        {
            public override void BuildDough() { pizza.SetDough("pan baked"); }
            public override void BuildSauce() { pizza.SetSauce("hot"); }
            public override void BuildTopping() { pizza.SetTopping("pepparoni+salami"); }
            public override void BuildBox() { pizza.SetBox(new PizzaBox("Medium")); } 
        }
        class MargaritaPizzaBuilder : PizzaBuilder
        {
            public override void BuildDough() { pizza.SetDough("cross"); }
            public override void BuildSauce() { pizza.SetSauce("tomatoes"); }
            public override void BuildTopping() { pizza.SetTopping("mozzarella+olives"); }
            public override void BuildBox() { pizza.SetBox(new PizzaBox("Small")); } 
        }
        class Waiter
        {
            private PizzaBuilder pizzaBuilder;

            public void SetPizzaBuilder(PizzaBuilder pb) { pizzaBuilder = pb; }
            public Pizza GetPizza() { return pizzaBuilder.GetPizza(); }
            public void ConstructPizza()
            {
                pizzaBuilder.CreateNewPizza();
                pizzaBuilder.BuildDough();
                pizzaBuilder.BuildSauce();
                pizzaBuilder.BuildTopping();
                pizzaBuilder.BuildBox(); 
            }
        }

        class BuilderExample
        {
            public static void Main(string[] args)
            {
                Waiter waiter = new Waiter();

                PizzaBuilder hawaiianPizzaBuilder = new HawaiianPizzaBuilder();
                PizzaBuilder spicyPizzaBuilder = new SpicyPizzaBuilder();
                PizzaBuilder margaritaPizzaBuilder = new MargaritaPizzaBuilder();

                waiter.SetPizzaBuilder(hawaiianPizzaBuilder);
                waiter.ConstructPizza();
                Pizza pizza1 = waiter.GetPizza();
                pizza1.Info();
                Console.WriteLine();

                waiter.SetPizzaBuilder(spicyPizzaBuilder);
                waiter.ConstructPizza();
                Pizza pizza2 = waiter.GetPizza();
                pizza2.Info();
                Console.WriteLine();

                waiter.SetPizzaBuilder(margaritaPizzaBuilder);
                waiter.ConstructPizza();
                Pizza pizza3 = waiter.GetPizza();
                pizza3.Info();

                Console.ReadKey();
            }
        }
    }
}
