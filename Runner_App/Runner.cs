using System;

public delegate void DrinkHandler();

public class Runner
{
    private static int DistancePerHalfHour = 5;
    private static int TotalDistance = 30;
    private static double MaxWaterLoss = 2.0;

    private Random random = new Random();
    private double totalWaterLoss = 0;
    private int totalDistanceRun = 0;

    public event DrinkHandler ?NeedToDrink;

    public bool HasFinished => totalDistanceRun >= TotalDistance;

    public void Run()
    {
        // Увеличиваем пройденную дистанцию
        totalDistanceRun += DistancePerHalfHour;

        // Рассчитываем потерю влаги за полчаса
        double waterLoss = random.NextDouble() * (1.0 - 0.5) + 0.5;
        totalWaterLoss += waterLoss;

        
        Console.WriteLine($"Пройдено: {totalDistanceRun} км, потеря влаги: {waterLoss:F2} л, всего потеряно: {totalWaterLoss:F2} л");

        
        if (totalWaterLoss >= MaxWaterLoss)
        {
            Console.WriteLine("Требуется пить!");
            NeedToDrink?.Invoke();
            totalWaterLoss = 0; 
        }
    }
}

