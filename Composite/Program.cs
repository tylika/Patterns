using System;
using System.Collections;

namespace CompositeExample
{
    class MainApp
    {
        static void Main()
        {
            Component menu = new Composite("Меню");
            Component hotDrinks = new Composite("Гарячі Напої");
            hotDrinks.Add(new Leaf("Еспресо"));
            hotDrinks.Add(new Leaf("Капучіно"));
            hotDrinks.Add(new Leaf("Чай"));
            Component dishes = new Composite("Страви");
            dishes.Add(new Leaf("Піца Маргарита"));
            dishes.Add(new Leaf("Цезар Салат"));
            dishes.Add(new Leaf("Борщ"));
            Component desserts = new Composite("Десерти");
            desserts.Add(new Leaf("Тірамісу"));
            desserts.Add(new Leaf("Чізкейк"));
            menu.Add(hotDrinks);
            menu.Add(dishes);
            menu.Add(desserts);
            menu.Display(1);
            Console.Read();
        }
    }

    abstract class Component
    {
        protected string name;

       
        public Component(string name)
        {
            this.name = name;
        }

        public abstract void Add(Component c);
        public abstract void Remove(Component c);
        public abstract void Display(int depth);
    }

    class Composite : Component
    {
        private ArrayList children = new ArrayList();

        public Composite(string name)
            : base(name)
        {
        }

        public override void Add(Component component)
        {
            children.Add(component);
        }

        public override void Remove(Component component)
        {
            children.Remove(component);
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name);
 
            foreach (Component component in children)
            {
                component.Display(depth + 2);
            }
        }
    }

    class Leaf : Component
    {
       
        public Leaf(string name)
            : base(name)
        {
        }

        public override void Add(Component c)
        {
            Console.WriteLine("Не можна додати до листа");
        }

        public override void Remove(Component c)
        {
            Console.WriteLine("Не можна видалити з листа");
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name);
        }
    }
}
