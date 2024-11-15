using System;
using System.Text;

namespace Decorator.Examples
{
    class MainApp
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            ChristmasTree tree = new ChristmasTree();
            DecorationsDecorator decoratedTree = new DecorationsDecorator();
            decoratedTree.SetComponent(tree);
            LightsDecorator lightedTree = new LightsDecorator();
            lightedTree.SetComponent(decoratedTree);
            lightedTree.Operation();
            Console.Read();
        }
    }

    abstract class Tree
    {
        public abstract void Operation();
    }
    class ChristmasTree : Tree
    {
        public override void Operation()
        {
            Console.WriteLine("Ялинка: Звичайна ялинка без прикрас.");
        }
    }
    abstract class TreeDecorator : Tree
    {
        protected Tree tree;

        public void SetComponent(Tree tree)
        {
            this.tree = tree;
        }

        public override void Operation()
        {
            if (tree != null)
            {
                tree.Operation();
            }
        }
    }
    class DecorationsDecorator : TreeDecorator
    {
        private string decorations;

        public override void Operation()
        {
            base.Operation();
            decorations = "Прикраси: Ялинкові кульки, гірлянди, зірка.";
            Console.WriteLine(decorations);
        }
    }
    class LightsDecorator : TreeDecorator
    {
        public override void Operation()
        {
            base.Operation();
            AddLights();
        }

        private void AddLights()
        {
            Console.WriteLine("Гірлянди: Ялинка світиться різнокольоровими вогниками.");
        }
    }
}
    