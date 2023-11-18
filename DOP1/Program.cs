using System;

public interface ICalculatable
{
    // Метод для сложения
    double Add(double a, double b);

    // Метод для вычитания
    double Subtract(double a, double b);

    // Метод для умножения
    double Multiply(double a, double b);

    // Метод для деления
    double Divide(double a, double b);
}

public class Calculator : ICalculatable
{
    public double Add(double a, double b)
    {
        return a + b;
    }

    public double Subtract(double a, double b)
    {
        return a - b;
    }

    public double Multiply(double a, double b)
    {
        return a * b;
    }

    public double Divide(double a, double b)
    {
        if (b != 0)
        {
            return a / b;
        }
        else
        {
            throw new ArgumentException("Невозможно делить на ноль.");
        }
    }
}

class Program
{
    static void Main()
    {
        ICalculatable calculator = new Calculator();

        double a = 10;
        double b = 5;

        Console.WriteLine($"Сложение: {a} + {b} = {calculator.Add(a, b)}");
        Console.WriteLine($"Вычитание: {a} - {b} = {calculator.Subtract(a, b)}");
        Console.WriteLine($"Умножение: {a} * {b} = {calculator.Multiply(a, b)}");

        try
        {
            Console.WriteLine($"Деление: {a} / {b} = {calculator.Divide(a, b)}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}
