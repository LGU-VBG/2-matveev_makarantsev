using System;

class Program
{
    static void Main(string[] args)
    {
        Runner runner = new Runner();
        Trainer trainer = new Trainer();

        // Подписываем тренера на событие "Пить"
        runner.NeedToDrink += trainer.ProvideWater;

        while (!runner.HasFinished)
        {
            runner.Run();
        }

        Console.WriteLine("Бег завершен!");
    }
}
