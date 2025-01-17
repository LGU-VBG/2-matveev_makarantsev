namespace Runner;
class Runner
{
    static void Main(string[] args)
    {
        Runner runner = new Runner();
        Trainer trainer = new Trainer
        ();

        runner.NeedToDrink += trainer.ProvideWater;

        while (!runner.Finish)
        {
            runner.Run();
        }

        Console.WriteLine("Бег завершен!");
    }
    public static void ProvideWater(String)
}

class Runner
{
    private static int DistancePerHalfHour = 5;
    private static int TotalDistance = 30;
    private static double MaxWaterLoss = 2.0;

    private Random random = new Random();
    private double totalWaterLoss = 0;
    private int totalDistanceRun = 0;

    public event Action NeedToDrink;

    public bool Finish => totalDistanceRun >= TotalDistance;

    public void Run()
    {
        // Увеличиваем пройденную дистанцию
        totalDistanceRun += DistancePerHalfHour;

        // Рассчитываем потерю влаги за полчаса
        double waterLoss = random.NextDouble() * (1.0 - 0.5) + 0.5;
        totalWaterLoss += waterLoss;

        // Выводим состояние бегуна
        Console.WriteLine($"Пройдено: {totalDistanceRun} км, потеря влаги: {waterLoss:F2} л, всего потеряно: {totalWaterLoss:F2} л");

        // Если потеря влаги достигла порога, генерируем событие
        if (totalWaterLoss >= MaxWaterLoss)
        {
            Console.WriteLine("Требуется пить!");
            NeedToDrink?.Invoke();
            totalWaterLoss = 0; // Сбрасываем уровень влаги после питья
        }
    }
}

class Trainer
{
    public void ProvideWater()
    {
        System.Console.WriteLine("Тренер: Пьём воду!");
    }
}
