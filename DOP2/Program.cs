using System;

public interface ICalculatable
{
    double Add(double a, double b);
    double Subtract(double a, double b);
    double Multiply(double a, double b);
    double Divide(double a, double b);
}

public class SimpleCalculator : ICalculatable
{
    public double Add(double a, double b)
    {
        double result = a + b;
        PrintResult(a, b, "+", result);
        return result;
    }

    public double Subtract(double a, double b)
    {
        double result = a - b;
        PrintResult(a, b, "-", result);
        return result;
    }

    public double Multiply(double a, double b)
    {
        double result = a * b;
        PrintResult(a, b, "*", result);
        return result;
    }

    public double Divide(double a, double b)
    {
        if (b == 0)
        {
            Console.WriteLine("Ошибка: деление на ноль.");
            return double.NaN;
        }

        double result = a / b;
        PrintResult(a, b, "/", result);
        return result;
    }

    private void PrintResult(double operand1, double operand2, string operation, double result)
    {
        Console.WriteLine($"{operand1} {operation} {operand2} = {result}");
    }
}

class Program
{
    static void Main()
    {
        SimpleCalculator calculator = new SimpleCalculator();

        double a = 10;
        double b = 5;

        calculator.Add(a, b);
        calculator.Subtract(a, b);
        calculator.Multiply(a, b);
        calculator.Divide(a, b);

        Console.ReadLine(); 
    }
}
