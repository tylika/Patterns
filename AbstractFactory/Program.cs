using System;

namespace AbstractFactory
{
    // AbstractProductA
    public abstract class Car
    {
        public abstract void Info();
        public void Interact(Engine engine)
        {
            Info();
            Console.WriteLine("Set Engine: ");
            engine.GetPower();
        }

        public void SetWheels(Wheel wheel)
        {
            Console.WriteLine("Set Wheel: ");
            wheel.GetSize();
        }
    }

    // ConcreteProductA1
    public class Ford : Car
    {
        public override void Info()
        {
            Console.WriteLine("Ford");
        }
    }

    // ConcreteProductA2
    public class Toyota : Car
    {
        public override void Info()
        {
            Console.WriteLine("Toyota");
        }
    }

    // ConcreteProductA3
    public class Mersedes : Car
    {
        public override void Info()
        {
            Console.WriteLine("Mersedes");
        }
    }

    // AbstractProductB
    public abstract class Engine
    {
        public virtual void GetPower() { }
    }

    // ConcreteProductB1
    public class FordEngine : Engine
    {
        public override void GetPower()
        {
            Console.WriteLine("Ford Engine");
        }
    }

    // ConcreteProductB2
    public class ToyotaEngine : Engine
    {
        public override void GetPower()
        {
            Console.WriteLine("Toyota Engine");
        }
    }

    // ConcreteProductB3
    public class MersedesEngine : Engine
    {
        public override void GetPower()
        {
            Console.WriteLine("Mersedes Engine 3.5");
        }
    }

    // AbstractProductC - Wheel
    public abstract class Wheel
    {
        public virtual void GetSize() { }
    }

    // ConcreteProductC1
    public class FordWheel : Wheel
    {
        public override void GetSize()
        {
            Console.WriteLine("Ford Wheel size 16");
        }
    }

    // ConcreteProductC2
    public class ToyotaWheel : Wheel
    {
        public override void GetSize()
        {
            Console.WriteLine("Toyota Wheel size 17");
        }
    }

    // ConcreteProductC3
    public class MersedesWheel : Wheel
    {
        public override void GetSize()
        {
            Console.WriteLine("Mersedes Wheel size 18");
        }
    }

    // AbstractFactory
    public interface ICarFactory
    {
        Car CreateCar();
        Engine CreateEngine();
        Wheel CreateWheel();
    }

    // ConcreteFactory1
    public class FordFactory : ICarFactory
    {
        public Car CreateCar()
        {
            return new Ford();
        }

        public Engine CreateEngine()
        {
            return new FordEngine();
        }

        public Wheel CreateWheel()
        {
            return new FordWheel();
        }
    }

    // ConcreteFactory2
    public class ToyotaFactory : ICarFactory
    {
        public Car CreateCar()
        {
            return new Toyota();
        }

        public Engine CreateEngine()
        {
            return new ToyotaEngine();
        }

        public Wheel CreateWheel()
        {
            return new ToyotaWheel();
        }
    }

    // ConcreteFactory3
    public class MersedesFactory : ICarFactory
    {
        public Car CreateCar()
        {
            return new Mersedes();
        }

        public Engine CreateEngine()
        {
            return new MersedesEngine();
        }

        public Wheel CreateWheel()
        {
            return new MersedesWheel();
        }
    }

    public class ClientFactory
    {
        private Car car;
        private Engine engine;
        private Wheel wheel;

        public ClientFactory(ICarFactory factory)
        {
            car = factory.CreateCar();
            engine = factory.CreateEngine();
            wheel = factory.CreateWheel();
        }

        public void Run()
        {
            car.Interact(engine);
            car.SetWheels(wheel);
        }
    }

    class AbstractFactoryApp
    {
        static void Main(string[] args)
        {
            ICarFactory carFactory = new ToyotaFactory();
            ClientFactory client = new ClientFactory(carFactory);
            client.Run();

            carFactory = new FordFactory();
            client = new ClientFactory(carFactory);
            client.Run();

            carFactory = new MersedesFactory();
            client = new ClientFactory(carFactory);
            client.Run();

            Console.ReadKey();
        }
    }
}
